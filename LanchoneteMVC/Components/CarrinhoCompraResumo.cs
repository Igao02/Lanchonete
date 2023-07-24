using LanchoneteMVC.Models;
using LanchoneteMVC.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace LanchoneteMVC.Components
{
    public class CarrinhoCompraResumo : ViewComponent
    {
        //Chamando a classe model Carrinho Compra (Instanciando a classe)
        private readonly CarrinhoCompra _carrinhoCompra;

        public CarrinhoCompraResumo(CarrinhoCompra carrinhoCompra)
        {
            _carrinhoCompra = carrinhoCompra;
        }

        public IViewComponentResult Invoke()
        {
            var itens = _carrinhoCompra.GetCarrinhoCompraItens();
           /* var itens = new List<CarrinhoCompraItem>()
            
                new CarrinhoCompraItem(),
                new CarrinhoCompraItem()
            };
           */

            _carrinhoCompra.CarrinhoCompraItems = itens;

            var carrinhoCompraVM = new CarrinhoCompraViewModel
            {
                CarrinhoCompra = _carrinhoCompra,
                CarrinhoCompraTotal = _carrinhoCompra.GetCarrinhoCompraTotal(),

            };

            return View(carrinhoCompraVM);
        }



    }
}
