using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SGIEscolar.Data.Interface;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace SGIEscolar.Controllers
{
    [Authorize]
    public class WebServiceController : BaseController
    {
        public WebServiceController(INotificador notificador) : base(notificador)
        {
        }

        public async Task<IActionResult> ConsultarCep(string cep)
        {
            var webRequest = WebRequest.CreateHttp($"http://viacep.com.br/ws/{cep}/json/");
            webRequest.Method = "Get";
            var result = await webRequest.GetResponseAsync();
            StreamReader reader = new StreamReader(result.GetResponseStream());
            object response = reader.ReadToEnd();
            return Json(response);
        }
    }
}
