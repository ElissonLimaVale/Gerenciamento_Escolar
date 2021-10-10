using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SGIEscolar.Data.Interface;
using SGIEscolar.Data.Notificacoes;
using SGIEscolar.Data.Service;
using SGIEscolar.ViewModels;
using System;
using System.Threading.Tasks;

namespace SGIEscolar.Controllers
{
    [Authorize]
    public class TurmasController : BaseController
    {
        private readonly TurmaService _service;
        private string[] _includes;
        public TurmasController(INotificador notificador, TurmaService service) : base(notificador)
        {
            _service = service;
            _includes = new string[] { nameof(TurmaViewModel.Alunos), nameof(TurmaViewModel.Professores) };
        }

        public async Task<IActionResult> Index()
        {
            return View(await _service.ListarTodos());
        }

        public IActionResult Cadastrar()
        {
            ViewBag.Action = nameof(Cadastrar);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar(TurmaViewModel entity)
        {
            if (ModelState.IsValid)
            {
                await _service.Adicionar(entity);
                if (OperacaoValida())
                {
                    _notificador.Handle(new Notificacao("Turma cadastrada com sucesso!", true));
                    return View("Index", await _service.ListarTodos());
                }
            }
            ViewBag.Action = nameof(Cadastrar);
            return View();
        }

        public async Task<IActionResult> Editar(Guid id)
        {
            ViewBag.Action = nameof(Editar);
            return View(await _service.BuscarPorId(id, _includes));
        }

        [HttpPost]
        public async Task<IActionResult> Editar(TurmaViewModel entity)
        {
            if (ModelState.IsValid)
            {
                await _service.Atualizar(entity, _includes);
                if (OperacaoValida())
                {
                    _notificador.Handle(new Notificacao("Turma atualizada com sucesso!", true));
                    return View("Index", await _service.ListarTodos());
                }
            }
            ViewBag.Action = nameof(Editar);
            return View(entity);
        }

        public async Task<IActionResult> Excluir(Guid id)
        {
            await _service.DeletarPorId(id, _includes);
            if (OperacaoValida())
                _notificador.Handle(new Notificacao("Turma deletada com sucesso!", true));

            return View("Index", await _service.ListarTodos());
        }
    }
}
