﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SGIEscolar.Data.Interface;
using System.Threading.Tasks;

namespace SGIEscolar.Controllers
{
    [Authorize]
    public class GerenciamentoController : BaseController
    {
        public GerenciamentoController(INotificador notificador) : base(notificador)
        {
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task CarregarDrops()
        {

        }
    }
}
