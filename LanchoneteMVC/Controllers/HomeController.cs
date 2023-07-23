using LanchoneteMVC.Models;
using LanchoneteMVC.Repositories;
using LanchoneteMVC.Repositories.Interfaces;
using LanchoneteMVC.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LanchoneteMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILancheRepository _lancheRepository;
        

        public HomeController(ILancheRepository lancheRepository)
        {
            //Acessa o repositório de lanches, através do código daquela classe,
            //consegue acessar o banco de dados com as informações dos lanches preferidos
            _lancheRepository = lancheRepository;
        }


        public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel
            {
                LanchesPreferidos = _lancheRepository.LanchesPreferidos
            };
            return View(homeViewModel);
        }

       

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}