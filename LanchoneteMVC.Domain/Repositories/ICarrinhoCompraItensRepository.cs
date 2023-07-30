using LanchoneteMVC.Domain.Models;

namespace LanchoneteMVC.Domain.Repositories
{
    public interface ICarrinhoCompraItensRepository : IRepository
    {
        void Add(CarrinhoCompraItem item);
        void Remove(CarrinhoCompraItem item);
        List<CarrinhoCompraItem> GetCarrinhoCompraItems(string carrinhoCompraId);
        void LimparCarrinho(string carrinhoCompraId);
        decimal GetCarrinhoCompraTotal(string carrinhoCompraId);
        CarrinhoCompraItem GetCarrinhoCompraItemByLancheIdAndCarrinhoId(int lancheId, string carrinhoCompraId);
    }
}
