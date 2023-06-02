using Microsoft.AspNetCore.Mvc;

namespace Venta_Real.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
