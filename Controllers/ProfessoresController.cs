using Microsoft.AspNetCore.Mvc;
using SGIEscolar.Data.Interface;
using SGIEscolar.Data.Service;
using SGIEscolar.ViewModels;
using SGIEscolar.Utils;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Authorization;
using SGIEscolar.Data.Notificacoes;

namespace SGIEscolar.Controllers
{
    [Authorize]
    public class ProfessoresController : BaseController
    {
        private readonly ProfessorService _service;
        private readonly TurmaService _turma;
        private readonly string[] _includes;
        public ProfessoresController(INotificador notificador, ProfessorService service, TurmaService turma) : base(notificador)
        {
            _service = service;
            _turma = turma;
            _includes = new string[] { nameof(ProfessorViewModel.Endereco), nameof(ProfessorViewModel.Turmas) };
        }

        public async Task<IActionResult> Index()
        {
            return View(await _service.ListarTodos());
        }

        public async Task<IActionResult> Cadastrar()
        {
            await CarregarDrops();
            ViewBag.Action = nameof(this.Cadastrar);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar(ProfessorViewModel entity)
        {
            if (ModelState.IsValid)
            {
                await _service.Adicionar(entity);
                if (OperacaoValida())
                {
                    _notificador.Handle(new Notificacao("Professor cadastrado com sucesso!", true));
                    return View("Index", await _service.ListarTodos());
                }
            }
            await CarregarDrops();
            ViewBag.Action = nameof(this.Cadastrar);
            return View(entity);
        }

        public async Task<IActionResult> Editar(Guid Id)
        {
            await CarregarDrops();
            ViewBag.Action = nameof(this.Editar);
            return View(await _service.BuscarPorId(Id));
        }

        [HttpPost]
        public async Task<IActionResult> Editar(ProfessorViewModel entity)
        {
            if (ModelState.IsValid)
            {
                await _service.Atualizar(entity, _includes);
                if (OperacaoValida())
                {
                    _notificador.Handle(new Notificacao("Dados do professor atualizados com sucesso!", true));
                    return View("Index", await _service.ListarTodos());
                }
            }
            ViewBag.Action = nameof(this.Editar);
            return View(entity);
        }

        public async Task<IActionResult> Excluir(Guid Id)
        {
            await _service.DeletarPorId(Id, _includes);
            if (OperacaoValida())
            {
                _notificador.Handle(new Notificacao("Professor Removido/Excluido Com Sucesso!", true));
            }
            return View("Index", await _service.ListarTodos());
        }

        public async Task CarregarDrops()
        {
            var turmas = await _turma.ListarTodos();
            ViewBag.Turmas = turmas.ToSelectList(x => x.Nome, x => x.Id.ToString(), "", search: true);
        }
    }
}
