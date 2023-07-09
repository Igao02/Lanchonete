using LanchoneteMVC.Models;

namespace LanchoneteMVC.Repositories.Interfaces
{
    public interface ICatgoriaRepository
    {
        IEnumerable<Categoria> Categorias { get; }
    }
}
