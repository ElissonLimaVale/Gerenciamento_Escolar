using Microsoft.AspNetCore.Mvc;
using SGIEscolar.Data.Service;
using System.Threading.Tasks;

namespace SGIEscolar.Data.Extensions
{
    public class UserLogViewComponent : ViewComponent
    {
        private readonly AutenticacaoService _user;
        public UserLogViewComponent(AutenticacaoService user)
        {
            this._user = user;
        }

        public IViewComponentResult Invoke()
        {
            ViewData["UserLog"] = _user.RetornaUsuarioEmail();
            return View();
        }
    }
}
