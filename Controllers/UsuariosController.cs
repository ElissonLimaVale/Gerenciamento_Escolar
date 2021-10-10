using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SGIEscolar.Data.Interface;
using SGIEscolar.Data.Notificacoes;
using SGIEscolar.Data.Service;
using SGIEscolar.Utils;
using SGIEscolar.ViewModels;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SGIEscolar.Controllers
{
    [Authorize]
    public class UsuariosController : BaseController
    {
        private readonly UsuarioService _service;
        private readonly InstituicaoService _insttuto;
        private readonly AutenticacaoService _autenticator;
        private string[] _includes;
        public UsuariosController(INotificador notificador, UsuarioService service, InstituicaoService instituto, AutenticacaoService autenticator) : base(notificador)
        {
            _service = service;
            _insttuto = instituto;
            _autenticator = autenticator;
            this._includes = new string[] { nameof(UsuarioViewModel.Permissoes), nameof(UsuarioViewModel.Instituicao) };
        }

        public async  Task<IActionResult> Index()
        {
            return View(await _service.ListarTodos(_includes));
        }

        public async Task<IActionResult> Cadastrar()
        {
            await CarregarDropDown(nameof(Cadastrar));
            return View(new UsuarioViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar(UsuarioViewModel entity)
        {
            if (ModelState.IsValid)
            {
                await _service.Adicionar(entity);
                if (OperacaoValida())
                {
                    _notificador.Handle(new Notificacao("Usuário cadastrado com sucesso!", true));
                    return View("Index", await _service.ListarTodos());
                }
            }
            await CarregarDropDown(nameof(Cadastrar));
            return View(entity);
        }

        public async Task<IActionResult> Editar(Guid id)
        {
            await CarregarDropDown(nameof(Editar));
            return View(await _service.BuscarPorId(id, _includes));
        }

        [HttpPost]
        public async Task<IActionResult> Editar(UsuarioViewModel entity)
        {
            if (ModelState.IsValid)
            {
                await _service.Atualizar(entity, _includes);
                if (OperacaoValida())
                {
                    _notificador.Handle(new Notificacao("Usuário atualizado com sucesso!", true));
                    return View("Index", await _service.ListarTodos());
                }
            }
            await CarregarDropDown(nameof(Editar));
            return View(entity);
        }

        public async Task<IActionResult> Excluir(Guid id)
        {
            await _service.DeletarPorId(id, _includes);
            if (OperacaoValida())
                _notificador.Handle(new Notificacao("Usuário deletado com sucesso!", true));
            return View("Index", await _service.ListarTodos());
        }


        private async Task CarregarDropDown(string action)
        {
            var listaInstituicoes = await _insttuto.BuscarLista(x => x.Usuarios.Select(x => x.Id).Contains(_autenticator.RetornaUsuarioId()));

            ViewBag.Instituicoes = listaInstituicoes.ToSelectList(x => x.Nome, x => x.Id.ToString(), "", search: true);
            ViewBag.Action = action;
        }
    }
}
