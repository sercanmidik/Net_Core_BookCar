using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class CarController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
