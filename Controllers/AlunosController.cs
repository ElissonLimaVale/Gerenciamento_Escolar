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
    public class AlunosController : BaseController
    {
        private readonly AlunoService _service;
        private string[] _includes;
        public AlunosController(
            INotificador notificador,
            AlunoService service
            ) : base(notificador)
        {
            this._service = service;
            this._includes = new string[]
            {
                nameof(AlunoViewModel.Endereco),
                nameof(AlunoViewModel.Turma)
            };
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
        public async Task<IActionResult> Cadastrar(AlunoViewModel aluno)
        {
            if (ModelState.IsValid)
            {
                await _service.Adicionar(aluno);
                if (OperacaoValida())
                {
                    _notificador.Handle(new Notificacao("Aluno atualizado com sucesso!", true));
                    return View("Index", await _service.ListarTodos());
                }
            }
            ViewBag.Action = nameof(Cadastrar);
            return View();
        }

        public IActionResult Editar()
        {
            ViewBag.Action = nameof(Editar);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Editar(AlunoViewModel aluno)
        {
            if (ModelState.IsValid)
            {
                await _service.Atualizar(aluno);
                if (OperacaoValida())
                {
                    _notificador.Handle(new Notificacao("Aluno atualizado com sucesso!", true));
                    return View("Index", await _service.ListarTodos());
                }
            }
            ViewBag.Action = nameof(Editar);
            return View(aluno);
        }

        public async Task<IActionResult> Deletar(Guid id)
        {
            await _service.DeletarPorId(id, _includes);
            if(OperacaoValida())
                _notificador.Handle(new Notificacao("Aluno deletado com sucesso!", true));
            return View("Index");
        }

        public async Task<IActionResult> ListarTodos()
        {
            return Json(await _service.ListarTodos());
        }
    }
}
