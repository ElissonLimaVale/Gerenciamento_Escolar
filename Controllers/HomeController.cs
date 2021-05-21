using Microsoft.AspNetCore.Mvc;
using SGIEscolar.Data.Interface;
using System.Threading.Tasks;

namespace SGIEscolar.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(INotificador notificador) : base(notificador)
        {
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> Privacy()
        {
            return View();
        }
    }
}
