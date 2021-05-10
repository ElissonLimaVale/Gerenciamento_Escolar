using Microsoft.AspNetCore.Mvc;
using SGIEscolar.Data.Interface;
using System.Threading.Tasks;

namespace SGIEscolar.Data.Extensions
{
    public class SummaryViewComponent : ViewComponent
    {
        private readonly INotificador _notificador;
        public SummaryViewComponent(INotificador notificador)
        {
            this._notificador = notificador;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var notifcacoes = await Task.FromResult(this._notificador.ListarNotificacoes());
            notifcacoes.ForEach((x) => {
                if (x.State) {
                    ViewBag.Sucesso = x.Mensagem;
                } else {
                    ViewData.ModelState.AddModelError(string.Empty, x.Mensagem);
                }
            });

            return View();
        }
    }
}
