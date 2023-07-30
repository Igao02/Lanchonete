using LanchoneteMVC.Domain.Models;

namespace LanchoneteMVC.Domain.Repositories;

public interface ICategoriaRepository : IRepository
{
    IEnumerable<Categoria> Categorias { get; }
}
