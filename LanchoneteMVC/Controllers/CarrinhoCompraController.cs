using LanchoneteMVC.Application.ViewModel;
using LanchoneteMVC.Domain.Repositories;
using LanchoneteMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace LanchoneteMVC.Controllers
{
    public class CarrinhoCompraController : Controller
    {
        private readonly ILancheRepository _lancheRepository;
        private readonly ICarrinhoCompraItensRepository _carrinhoCompraItensRepository;
        private readonly CarrinhoCompra _carrinhoCompra;

        public CarrinhoCompraController(
            ILancheRepository lancheRepository,
            ICarrinhoCompraItensRepository carrinhoCompraItensRepository,
            CarrinhoCompra carrinhocompra
        )
        {
            _lancheRepository = lancheRepository;
            _carrinhoCompraItensRepository = carrinhoCompraItensRepository;
            _carrinhoCompra = carrinhocompra;
        }

        public IActionResult Index()
        {
            var itens = _carrinhoCompraItensRepository.GetCarrinhoCompraItems(_carrinhoCompra.CarrinhoCompraId);
            _carrinhoCompra.CarrinhoCompraItems = itens;

            var carrinhoCompraVM = new CarrinhoCompraViewModel
            {
                CarrinhoCompra = _carrinhoCompra,
                CarrinhoCompraTotal = _carrinhoCompraItensRepository.GetCarrinhoCompraTotal(_carrinhoCompra.CarrinhoCompraId),

            };


            return View(carrinhoCompraVM);
        }

        public RedirectToActionResult AdicionarItemNoCarrinhoCompra(int lancheid)
        {
            var lancheSelecionado = _lancheRepository.Lanches.FirstOrDefault(p => p.LancheId == lancheid);


            if (lancheSelecionado != null)
            {
                _carrinhoCompra.AdicionarAoCarrinho(lancheSelecionado);
            }

            return RedirectToAction("Index");
        }


        public IActionResult RemoverItemDoCarrinhoCompra(int lancheId)
        {
            var lancheSelecionado = _lancheRepository.Lanches.FirstOrDefault(p => p.LancheId == lancheId);

            if (lancheSelecionado != null)
            {
                _carrinhoCompra.RemoverDoCarrinho(lancheSelecionado);
            }

            return RedirectToAction("Index");


        }


    }
}
