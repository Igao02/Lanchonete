using LanchoneteMVC.Domain.Models;
using LanchoneteMVC.Domain.Repositories;
using LanchoneteMVC.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace LanchoneteMVC.Persistence.Repositories
{
    public class LancheRepository : ILancheRepository
    {
        private readonly AppDbContext _context;

        public LancheRepository(AppDbContext contexto) => _context = contexto;

        public IEnumerable<Lanche> Lanches => _context.Lanches.Include(c => c.Categoria);

        public IEnumerable<Lanche> LanchesPreferidos => _context.Lanches.Where(l => l.IsLanchePreferido).Include(c => c.Categoria);

        public Lanche GetLancheById(int LancheId)
        {
            return _context.Lanches.FirstOrDefault(l => l.LancheId == LancheId);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
