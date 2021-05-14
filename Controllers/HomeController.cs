using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SGIEscolar.Data.Interface;

namespace SGIEscolar.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, INotificador notificador) : base(notificador)
        {
            _logger = logger;
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
