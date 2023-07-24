using Microsoft.AspNetCore.Mvc;

namespace LanchoneteMVC.Controllers
{
    public class ContatoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
