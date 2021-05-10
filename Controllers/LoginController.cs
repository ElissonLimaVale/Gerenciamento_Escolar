using Microsoft.AspNetCore.Mvc;
using SGIEscolar.Data.Interface;
using SGIEscolar.Data.Notificacoes;
using SGIEscolar.ViewModels;

namespace SGIEscolar.Controllers
{
    public class LoginController : BaseController
    {
        public LoginController(
            INotificador notificador
            ) : base(notificador)
        {
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(UsuarioViewModel user)
        {
            if (!ModelState.IsValid)
            {
                _notificador.Handle(new Notificacao("Preecha os campos obrigatório!"));
                return View("Index", user);
            } 
            return RedirectToAction("Index","Home");
        }
        public IActionResult Logout()
        {
            return RedirectToAction("Index");
        }
    }
}
