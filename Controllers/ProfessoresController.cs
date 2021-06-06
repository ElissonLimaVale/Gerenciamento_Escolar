using Microsoft.AspNetCore.Mvc;
using SGIEscolar.Data.Interface;
using SGIEscolar.ViewModels;

namespace SGIEscolar.Controllers
{
    public class ProfessoresController : BaseController
    {
        public ProfessoresController(INotificador notificador) : base(notificador)
        {

        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Cadastro()
        {
            ViewBag.Action = "Cadastrar";
           return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(ProfessorViewModel entity)
        {
            return View("Index");
        }
    }
}
