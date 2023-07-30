using LanchoneteMVC.Domain.Models;
using LanchoneteMVC.Domain.Repositories;
using LanchoneteMVC.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace LanchoneteMVC.Persistence.Repositories
{
    public class CarrinhoCompraItensRepository : ICarrinhoCompraItensRepository
    {
        private readonly AppDbContext _context;
        public CarrinhoCompraItensRepository(AppDbContext context) => this._context = context;

        public void Add(CarrinhoCompraItem item)
        {
            _context.CarrinhoCompraItens.Add(item);
        }

        public void Remove(CarrinhoCompraItem item)
        {
            _context.CarrinhoCompraItens.Remove(item);
        }

        public CarrinhoCompraItem GetCarrinhoCompraItemByLancheIdAndCarrinhoId(int lancheId, string carrinhoCompraId)
        {
            return _context.CarrinhoCompraItens
                .SingleOrDefault(s => s.Lanche.LancheId == lancheId
                                      && s.CarrinhoCompraId == carrinhoCompraId);
        }

        public List<CarrinhoCompraItem> GetCarrinhoCompraItems(string carrinhoCompraId)
        {
            return _context.CarrinhoCompraItens
                .Where(c => c.CarrinhoCompraId == carrinhoCompraId)
                .Include(s => s.Lanche)
                .ToList();
        }

        public decimal GetCarrinhoCompraTotal(string carrinhoCompraId)
        {
            var total = _context.CarrinhoCompraItens
                .Where(c => c.CarrinhoCompraId == carrinhoCompraId)
                .Select(c => c.Lanche.Preco * c.Quantidade)
                .Sum();

            return total;
        }

        public void LimparCarrinho(string carrinhoCompraId)
        {
            var carrinhoItens = _context.CarrinhoCompraItens.Where(carrinho => carrinho.CarrinhoCompraId == CarrinhoCompraId);
            _context.CarrinhoCompraItens.RemoveRange(carrinhoItens);
            _context.SaveChanges();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
