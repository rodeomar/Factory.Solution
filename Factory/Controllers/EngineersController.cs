using Factory.Models;
using Microsoft.AspNetCore.Mvc;

namespace Factory.Controllers
{
    public class EngineersController : Controller
    {

        private static List<Engineer> Engineers = new (){ new Engineer("Raed", "ASDU1312736", 1), new Engineer("Ammar", "YAGD12837912", 2) };

       public IActionResult Index()
        {

            return View(Engineers);
        }
    }
}
