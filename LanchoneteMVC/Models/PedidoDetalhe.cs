using System.ComponentModel.DataAnnotations.Schema;

namespace LanchoneteMVC.Models
{
    public class PedidoDetalhe
    {
        public int PedidoDetalheId { get; set; }
        public int PedidoId { get; set; }
        public int LancheId { get; set; }
        public int Quantidade { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Preco { get ; set; }

        //Definindo um relacionamento direto entre pedidoDetalhe e Lanche
        public virtual Lanche Lanche { get; set; }
        public virtual Pedido Pedido { get; set; }
    }
}
