using Microsoft.AspNetCore.Mvc;
using SGIEscolar.Data.Interface;
using SGIEscolar.ViewModels;
using System.Threading.Tasks;

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

        public async Task<IActionResult> Cadastrar()
        {
            ViewBag.Action = nameof(this.Cadastrar);
            await CarregarDrops();
           return View();
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar(ProfessorViewModel entity)
        {
            return View("Index");
        }

        public async Task CarregarDrops()
        {

        }
    }
}
