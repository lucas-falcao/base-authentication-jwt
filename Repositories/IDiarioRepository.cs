using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autenticacao01.Authentication;
using Autenticacao01.Models;

namespace Autenticacao01.Repositories
{
    public interface IDiarioRepository
    {
        Task Add(Diario Diario, string userId);
        Task<List<Diario>> GetDiarios(string userId);
        Task Update(Diario Diario, string userId);
        Task<Diario> GetDiarioById(int id, string userId);
        Task Delete(int id, string userId);

    }
}