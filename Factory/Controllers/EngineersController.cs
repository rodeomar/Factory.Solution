using Factory.Models;
using Microsoft.AspNetCore.Mvc;

namespace Factory.Controllers
{
    public class EngineersController : Controller
    {

        private static List<Engineer> Engineers = new() { new Engineer("Raed", "raed@example.com", "(555) 123-4567", "ASDU1312736", 1), new Engineer("Ammar", "ammar@example.com", "(555) 987-6543", "YAGD12837912", 2) };

        public IActionResult Index()
        {

            return View(Engineers);
        }
    }
}
