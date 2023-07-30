using LanchoneteMVC.Application.Contracts;

namespace LanchoneteMVC.Application.Commands
{
    public class GetCarrinhaCommand : ICommand
    {
        public string SessionId { get; set; }
    }
}
