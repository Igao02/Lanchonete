using LanchoneteMVC.Application.Contracts;
using LanchoneteMVC.Domain.Models;

namespace LanchoneteMVC.Application.Commands
{
    public class RemoverDoCarrinhoCommand : ICommand
    {
        public Lanche Lanche { get; set; }
        public string CarrinhoCompraId { get; set; }
    }
}
