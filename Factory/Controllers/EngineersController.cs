using Microsoft.AspNetCore.Mvc;

namespace Factory.Controllers
{
    public class EngineersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
