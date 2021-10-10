using Microsoft.AspNetCore.Http;
using System;
using System.Security.Claims;

namespace SGIEscolar.Data.Service
{
    public class AutenticacaoService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AutenticacaoService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public Guid RetornaUsuarioId()
        {
            Guid retorno = new Guid();
            try
            {
                retorno = Guid.Parse(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Sid)?.Value);
            }
            catch (Exception ex)
            {

            }
            return retorno;
        }
        public string RetornaUsuarioEmail()
        {
            return _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Email)?.Value;
        }
        public string RetornaUsuarioNome()
        {
            return _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Name)?.Value;
        }

        public Guid RetornaInstituicaoId()
        {
            return Guid.Parse(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.GivenName)?.Value);
        }
    }
}
