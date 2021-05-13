using Microsoft.AspNetCore.Mvc;
using SGIEscolar.Data.Interface;
using SGIEscolar.Data.Notificacoes;
using SGIEscolar.ViewModels;
using System.Collections.Generic;

namespace SGIEscolar.Controllers
{
    public class LoginController : BaseController
    {
        private Dictionary<int, ErrorViewModel> _errors;
        public LoginController(
            INotificador notificador
            ) : base(notificador)
        {
            this._errors = this.GetErrors();
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


        [Route("error/{id:length(3,3)}")]
        public IActionResult Error(int id)
        {
            var error = _errors[id];
            return View("Error", error);
        }



        public Dictionary<int, ErrorViewModel> GetErrors()
        {
            var response = new Dictionary<int, ErrorViewModel>();
            response.Add(500, new ErrorViewModel { 
                Mensagem = "Tente novamente mais tarde ou entre em contato com o nosso suporte!",
                Titulo = "Ocorreu um erro inesperado!",
                ErrorCode = 500
            });
            response.Add(404, new ErrorViewModel { 
                Mensagem = "A págna que está procurando não existe!",
                Titulo = "Página não encontrada!",
                ErrorCode = 404
            });
            response.Add(403, new ErrorViewModel { 
                Mensagem = "Seu usuário não tem permissão para executar esta ação!",
                Titulo = "Acesso negado!",
                ErrorCode = 403
            });
            return response;
        }
    }
}
