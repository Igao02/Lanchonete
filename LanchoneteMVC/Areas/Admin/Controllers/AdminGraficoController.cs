using LanchoneteMVC.Areas.Admin.Services;
using Microsoft.AspNetCore.Mvc;

namespace LanchoneteMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminGraficoController : Controller
    {
        private readonly GraficoVendasService graficoVendasService;

        public AdminGraficoController(GraficoVendasService graficoVendasService)
        {
            this.graficoVendasService = graficoVendasService ?? throw
                new ArgumentException(nameof(graficoVendasService));
        }

        public JsonResult VendasLanches(int dias)
        {
            var lanchesVendasTotais = graficoVendasService.GetVendasLanches(dias);
            return Json(lanchesVendasTotais);
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult VendasMensal()
        {
            return View();
        }

        public IActionResult VendasSemanal()
        {
            return View();
        }
    }
}
