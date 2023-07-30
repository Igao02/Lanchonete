using LanchoneteMVC.Application.Commands;
using LanchoneteMVC.Application.Contracts;
using LanchoneteMVC.Domain.Models;
using LanchoneteMVC.Domain.Repositories;

namespace LanchoneteMVC.Application.CommandHandlers
{
    public class CarrinhoCompraCommandHandler : ICommandHandler
    {
        private readonly ICarrinhoCompraItensRepository _carrinhoCompraItensRepository;

        public CarrinhoCompraCommandHandler(
            ICarrinhoCompraItensRepository carrinhoCompraItensRepository
        ) =>
            this._carrinhoCompraItensRepository = carrinhoCompraItensRepository;

        public dynamic Handle(AdicionarAoCarrinhoCommand command)
        {
            var carrinhoCompraItem = _carrinhoCompraItensRepository
                .GetCarrinhoCompraItemByLancheIdAndCarrinhoId(command.Lanche.LancheId, command.CarrinhoCompraId);

            if (carrinhoCompraItem == null)
            {
                carrinhoCompraItem = new CarrinhoCompraItem
                {
                    CarrinhoCompraId = command.CarrinhoCompraId,
                    Lanche = command.Lanche,
                    Quantidade = 1
                };

                _carrinhoCompraItensRepository.Add(carrinhoCompraItem);
            }
            else
            {
                carrinhoCompraItem.Quantidade++;
            }

            _carrinhoCompraItensRepository.SaveChanges();

            return command;
        }

        public int Handle(RemoverDoCarrinhoCommand command)
        {
            var carrinhoCompraItem = _carrinhoCompraItensRepository
                .GetCarrinhoCompraItemByLancheIdAndCarrinhoId(command.Lanche.LancheId, command.CarrinhoCompraId);

            var quantidadeLocal = 0;

            if (carrinhoCompraItem != null)
            {
                if (carrinhoCompraItem.Quantidade > 1)
                {
                    carrinhoCompraItem.Quantidade--;
                    quantidadeLocal = carrinhoCompraItem.Quantidade;
                }
                else
                {
                    _carrinhoCompraItensRepository.Remove(carrinhoCompraItem);
                }
            }
            _carrinhoCompraItensRepository.SaveChanges();

            return quantidadeLocal;
        }

        public dynamic Handle(LimparCarrinhoCommand command)
        {
            _carrinhoCompraItensRepository.LimparCarrinho(command.CarrinhoCompraId);

            return command;
        }
    }
}
