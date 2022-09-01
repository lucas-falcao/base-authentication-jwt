using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autenticacao01.Models;
using Microsoft.AspNetCore.Identity;

namespace Autenticacao01.Authentication
{
    public class ApplicationUser : IdentityUser
    {
        public virtual List<Diario>? Diarios { get; set; }
    }
}