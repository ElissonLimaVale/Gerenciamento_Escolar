using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SGIEscolar.Data.Interface;
using SGIEscolar.Data.Service;
using SGIEscolar.ViewModels;
using System.Threading.Tasks;

namespace SGIEscolar.Controllers
{
    [Authorize]
    public class UsuariosController : BaseController
    {
        private readonly UsuarioService _service;
        private string[] _includes;
        public UsuariosController(INotificador notificador, UsuarioService service) : base(notificador)
        {
            this._service = service;
            this._includes = new string[] { nameof(UsuarioViewModel.Permissoes) };
        }

        public async  Task<IActionResult> Index()
        {
            return View(await _service.ListarTodos());
        }
    }
}
