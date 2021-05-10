using Microsoft.AspNetCore.Mvc;
using SGIEscolar.Data.Interface;

namespace SGIEscolar.Controllers
{
    public class BaseController : Controller
    {
        public readonly INotificador _notificador;
        public BaseController(INotificador notificador)
        {
            this._notificador = notificador;
        }

        protected bool OperacaoValida()
        {
            return !this._notificador.ExisteNotifcacoes();
        }
    }
}
