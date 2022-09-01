using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Autenticacao01.Authentication;

namespace Autenticacao01.Services
{
    public interface IUserService
    {
        public Task<string> GetUser(ClaimsPrincipal userAuthenticate);
    }
}