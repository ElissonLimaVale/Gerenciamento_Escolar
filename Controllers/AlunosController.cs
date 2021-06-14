using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SGIEscolar.Data.Interface;
using SGIEscolar.Data.Notificacoes;
using SGIEscolar.Data.Service;
using SGIEscolar.Utils;
using SGIEscolar.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace SGIEscolar.Controllers
{
    [Authorize]
    public class AlunosController : BaseController
    {
        private readonly AlunoService _service;
        private readonly TurmaService _turma;
        private string[] _includes;
        public AlunosController(
            INotificador notificador,
            AlunoService service,
            TurmaService turma
            ) : base(notificador)
        {
            this._service = service;
            this._turma = turma;
            this._includes = new string[]
            {
                nameof(AlunoViewModel.Endereco),
                nameof(AlunoViewModel.Turma)
            };
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        public IActionResult InformacoesPeriodo()
        {
            return View();
        }

        public async Task<IActionResult> Cadastrar()
        {
            await CarregarDropDown(nameof(Cadastrar));
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
                    _notificador.Handle(new Notificacao("Aluno cadastrado com sucesso!", true));
                    return View("Index");
                }
            }
            await CarregarDropDown(nameof(Cadastrar));
            return View();
        }

        public async Task<IActionResult> Editar(Guid id)
        {
            await CarregarDropDown(nameof(Editar));
            return View(await _service.BuscarPorId(id, _includes));
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
                    return View("Index");
                }
            }
            await CarregarDropDown(nameof(Editar));
            return View(aluno);
        }

        public async Task<IActionResult> Deletar(Guid id)
        {
            await _service.DeletarPorId(id, _includes);
            if(OperacaoValida())
                _notificador.Handle(new Notificacao("Aluno deletado com sucesso!", true));
            return View("Index", await _service.ListarTodos());
        }

        public async Task<IActionResult> Buscar(string filtro)
        {
            if (string.IsNullOrEmpty(filtro))
                return Json(await _service.ListarTodos());
            else
                return Json(await _service.BuscarPorFiltro(filtro, new string[] { "Id", "Nome", "CPF", "NomeDaMae", "NomeDoPai" }));
        }

        private async Task CarregarDropDown(string action)
        {
            var listaTurmas = await _turma.ListarTodos() as List<TurmaViewModel>;

            if (string.Equals(action, nameof(Cadastrar)))
                ViewBag.Title = "Matricular Aluno";
            else
                ViewBag.Title = "Atualizar Matricula do Aluno";

            ViewBag.Action = action;
            ViewBag.Turmas = listaTurmas.ToSelectList(x => x.Nome, x => x.Id.ToString(), "", search: true);
        }
    }
}
