using LanchoneteMVC.Domain.Models;

namespace LanchoneteMVC.Models
{
    public class CarrinhoCompra
    {
        public string CarrinhoCompraId { get; set; }
        public List<CarrinhoCompraItem> CarrinhoCompraItems { get; set; }

        public static CarrinhoCompra GetCarrinho(IServiceProvider services)
        {
            //Define uma Sessão
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            //Obtem ou gera o Id do carrinho
            string carrinhoId = session.GetString("CarrinhoId") ?? Guid.NewGuid().ToString();

            //Atribui o Id do carrinho na sessão
            session.SetString("CarrinhoId", carrinhoId);

            return new CarrinhoCompra()
            {
                CarrinhoCompraId = carrinhoId
            };
        }
    }
}
