using LanchoneteMVC.Domain.Models;

namespace LanchoneteMVC.Domain.Repositories;

public interface ILancheRepository : IRepository
{
    IEnumerable<Lanche> Lanches { get; }
    IEnumerable<Lanche> LanchesPreferidos { get; }
    Lanche GetLancheById(int lancheId);
}