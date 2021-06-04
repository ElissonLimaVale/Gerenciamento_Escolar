using KissLog;
using Microsoft.AspNetCore.Mvc;
using SGIEscolar.Data.Interface;

namespace SGIEscolar.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(INotificador notificador) : base(notificador)
        {
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
