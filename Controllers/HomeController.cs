using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SGIEscolar.Data.Interface;

namespace SGIEscolar.Controllers
{
    [Authorize]
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
