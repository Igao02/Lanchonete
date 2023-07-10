using LanchoneteMVC.Models;

namespace LanchoneteMVC.ViewModel
{
    public class LancheListViewModel
    {
        public IEnumerable<Lanche> Lanches { get; set; }
        public string CategoriaAtual { get; set; }


    }
}
