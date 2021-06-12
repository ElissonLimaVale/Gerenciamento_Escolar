using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SGIEscolar.Data.Interface;
using SGIEscolar.Data.Notificacoes;
using SGIEscolar.Data.Service;
using SGIEscolar.ViewModels;
using System.Threading.Tasks;

namespace SGIEscolar.Controllers
{
    [Authorize]
    public class ProfessoresController : BaseController
    {
        private readonly ProfessorService _service;
        private string[] _includes;
        public ProfessoresController(INotificador notificador, ProfessorService service) : base(notificador)
        {
            this._service = service;
            this._includes = new string[] { 
                nameof(ProfessorViewModel.Endereco)
            };
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Cadastrar()
        {
            ViewBag.Action = "Cadastrar";
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
                    View("Index");
                }
            }
           
            return View();
        }

        public async Task<IActionResult> ListarTodos()
        {
            return Json(await  _service.ListarTodos(_includes));
        }
    }
}
