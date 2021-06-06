using AutoMapper;
using KissLog;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using SGIEscolar.Data.Interface;
using SGIEscolar.Data.Models;
using SGIEscolar.Data.Repository;
using SGIEscolar.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SGIEscolar.Data.Service
{
    public class UsuarioService : BaseService<Usuario, UsuarioViewModel>
    {
        private readonly UsuarioRepository _usuario;
        
        public UsuarioService(
            UsuarioRepository repository, 
            INotificador notificador,  
            IMapper mapper, 
            ILogger logger,
            IDapper dapper,
            
        AutenticacaoService autenticacao) : base(repository, notificador, mapper, logger, dapper, autenticacao)
        {
            this._usuario = repository;
            
        }

        public override async Task<int> Adicionar(UsuarioViewModel usuario)
        {
            if (!await ExisteUsuario(usuario))
            {
                usuario.Senha = Encryptar(usuario.Senha);
                await base.Adicionar(usuario);
            }
            else
                Notificar("Já existe um usuário cadastrado com este email!");
            return 0;
        }
        
        public override async Task<int> Atualizar(UsuarioViewModel usuario)
        {
            if (!await ExisteUsuario(usuario))
                await base.Atualizar(usuario);
            else
                Notificar("Já existe um usuário cadastrado com este email!");
            return 0;
        }

        public async Task Authenticar(UsuarioViewModel usuario, Microsoft.AspNetCore.Mvc.ControllerContext context)
        {
            var login = await BuscarObjeto(x => x.Email == usuario.Email && x.Id != new Guid());
            if(login == null || !BCrypt.Net.BCrypt.Verify(usuario.Senha, login.Senha))
            {
                Notificar("Usuário ou senha inválidos!");
                return;
            }
            var Claims = new List<Claim>();
            Claims.Add(new Claim(ClaimTypes.Sid, login.Id.ToString()));
            Claims.Add(new Claim(ClaimTypes.Email, login.Email));
            Claims.Add(new Claim(ClaimTypes.Name, login.Nome));

            login.Permissoes?.ToList().ForEach((data) => {
                Claims.Add(new Claim(ClaimTypes.Role, data.Id.ToString()));
            });

            var ClaimsIdentity = new ClaimsIdentity(Claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await context.HttpContext.SignInAsync( new ClaimsPrincipal(ClaimsIdentity), new AuthenticationProperties
            {
                IsPersistent = true,
                ExpiresUtc = DateTime.Now.AddDays(1)
            });
            // Salvar logs

            return;
        }
        private string Encryptar(string senha)
        {
            return BCrypt.Net.BCrypt.HashPassword(senha);
        }

        private async Task<bool> ExisteUsuario(UsuarioViewModel usuario)
        {
            var registro = await BuscarObjeto(x => x.Email == usuario.Email && x.Id != new Guid() && x.Id != usuario.Id);
            return (registro != null);
        }
    }
}
