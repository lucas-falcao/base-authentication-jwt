using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Autenticacao01.Authentication;
using Microsoft.AspNetCore.Identity;

namespace Autenticacao01.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> userManager;

        public UserService(UserManager<ApplicationUser> userManager )
        {
            this.userManager = userManager;
        }
        public async Task<string> GetUser(ClaimsPrincipal userAuthenticate)
        {
            var user = await userManager.FindByNameAsync(userAuthenticate.Identity.Name);
            string id = await userManager.GetUserIdAsync(user);
            return id;
        }
    }
}