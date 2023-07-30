using LanchoneteMVC.Domain.Models;
using LanchoneteMVC.Domain.Repositories;
using LanchoneteMVC.Persistence.Context;

namespace LanchoneteMVC.Persistence.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly AppDbContext _context;

        public CategoriaRepository(AppDbContext context) => _context = context;

        public IEnumerable<Categoria> Categorias => _context.Categorias;

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
