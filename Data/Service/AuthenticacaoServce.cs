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
            return Guid.Parse(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Sid)?.Value);
        }
        public string RetornaUsuarioEmail()
        {
            return _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Email)?.Value;
        }
        public string RetornaUsuarioNome()
        {
            return _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Name)?.Value;
        }
    }
}
