using LanchoneteMVC.Models;

namespace LanchoneteMVC.ViewModel
{
    public class HomeViewModel
    {
        //O objetivo é exibir os lanches preferidos nesta View

        public IEnumerable<Lanche> LanchesPreferidos { get; set; }

    }
}
