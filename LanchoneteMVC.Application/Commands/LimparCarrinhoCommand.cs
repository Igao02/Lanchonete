using LanchoneteMVC.Application.Contracts;

namespace LanchoneteMVC.Application.Commands
{
    public class LimparCarrinhoCommand : ICommand
    {
        public string CarrinhoCompraId { get; set; }
    }
}
