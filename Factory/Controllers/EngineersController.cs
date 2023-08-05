using Factory.Models;
using Microsoft.AspNetCore.Mvc;

namespace Factory.Controllers
{
    public class EngineersController : Controller
    {

        private static List<Engineer> Engineers = new (){ new Engineer("Raed", "ASDU1312736"), new Engineer("Ammar", "YAGD12837912") };

       public IActionResult Index()
        {

            return View(Engineers);
        }
    }
}
