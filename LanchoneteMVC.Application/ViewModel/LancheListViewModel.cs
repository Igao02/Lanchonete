using LanchoneteMVC.Domain.Models;

namespace LanchoneteMVC.Application.ViewModel
{
    public class LancheListViewModel
    {
        public IEnumerable<Lanche> Lanches { get; set; }
        public string CategoriaAtual { get; set; }


    }
}
