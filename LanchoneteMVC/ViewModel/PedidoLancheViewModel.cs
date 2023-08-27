using LanchoneteMVC.Models;

namespace LanchoneteMVC.ViewModel
{
    public class PedidoLancheViewModel
    {
        public Pedido Pedido { get; set; }
        public IEnumerable<PedidoDetalhe> PedidoDetalhe { get; set; }
    }
}
