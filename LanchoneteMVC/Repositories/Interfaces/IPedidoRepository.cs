using LanchoneteMVC.Models;

namespace LanchoneteMVC.Repositories.Interfaces
{

    //Uma interface descreve "o que fazer", mas não "como fazer".
    //Isso permite que várias classes diferentes implementem a mesma interface, desde que forneçam a
    //funcionalidade necessária de acordo com o contrato definido.

    public interface IPedidoRepository
    {

        void CriarPedido(Pedido pedido);

    }
}
