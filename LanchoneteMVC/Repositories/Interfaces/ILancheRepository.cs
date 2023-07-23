using LanchoneteMVC.Models;

namespace LanchoneteMVC.Repositories.Interfaces
{
    public interface ILancheRepository
    {
        //Pasta Repository separa os códigos que acessam os dados do SQL

        IEnumerable<Lanche> Lanches { get; }
        IEnumerable<Lanche> LanchesPreferidos { get; }
        Lanche GetLancheById(int lancheId);

    }
}
