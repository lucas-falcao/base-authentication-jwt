using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autenticacao01.Authentication;
using Autenticacao01.Models;
using Microsoft.EntityFrameworkCore;

namespace Autenticacao01.Repositories
{
    public class DiarioRepository : IDiarioRepository
    {
        private readonly ApplicationContext _context;

        public DiarioRepository(ApplicationContext context)
        {
            _context = context;
        }
        public async Task Add(Diario Diario, string userId)
        {
            Diario.UserId = userId;
            await _context.Diarios.AddAsync(Diario);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id, string userId)
        {
            var Diario = await GetDiarioById(id,userId);
            _context.Diarios.Remove(Diario);
            await _context.SaveChangesAsync();
        }

        public async Task<Diario> GetDiarioById(int id, string userId)
        {
            var Diario = await _context.Diarios.AsNoTracking().FirstOrDefaultAsync(d => d.Id == id && d.UserId == userId);
            return Diario;
        }

        public async Task<List<Diario>> GetDiarios(string userId)
        {
            var Diarios = await _context.Diarios.Where(d => d.UserId == userId).ToListAsync();
            return Diarios;
        }

        public async Task Update(Diario Diario, string userId)
        {
            var DiarioDb = await _context.Diarios.Where(d => d.Id == Diario.Id && d.UserId == userId).FirstOrDefaultAsync();
            DiarioDb.Text = Diario.Text;
            DiarioDb.Title = Diario.Title;
            _context.Diarios.Update(DiarioDb);
            await _context.SaveChangesAsync();
        }
    }
}