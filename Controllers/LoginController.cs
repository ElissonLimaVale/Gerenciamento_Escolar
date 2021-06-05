using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using SGIEscolar.Data.Interface;
using SGIEscolar.Data.Notificacoes;
using SGIEscolar.Data.Service;
using SGIEscolar.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGIEscolar.Controllers
{
    public class LoginController : BaseController
    {
        private readonly UsuarioService _service;
        private Dictionary<int, ErrorViewModel> _errors;
        public LoginController(
            UsuarioService service,
            INotificador notificador
            ) : base(notificador)
        {
            this._service = service;
            this._errors = this.GetErrors();
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UsuarioViewModel user)
        {
            if (ModelState.IsValid)
            {
                await _service.Authenticar(user, this.ControllerContext);
                if (OperacaoValida())
                    return RedirectToAction("Index", "Home");
            } 
            else
                _notificador.Handle(new Notificacao("Preecha os campos obrigatório!"));
            return View("Index", user);
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index");
        }


        [Route("error/{id:length(3,3)}")]
        public IActionResult Error(int id)
        {
            id = !new int[] { 403, 404, 500 }.Contains(id) ? 500 : id;
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
