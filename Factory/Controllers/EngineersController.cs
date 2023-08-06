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

        public IActionResult Details(int id)
        {
            Engineer? engineer = Engineers.FirstOrDefault(e => e.EngineerID == id);

            if (engineer != null)
            {
                return View(engineer);
            }

            return NotFound();
        }


        public IActionResult Create(string Name, string Email, string Phone, string LicenseID)
        {

            int newId = Engineers.Max(e => e.EngineerID) + 1;
            Engineer newEngineer = new Engineer(Name, Email, Phone, LicenseID, newId);
            Engineers.Add(newEngineer);
            return RedirectToAction("Index");

        }

    }


}
