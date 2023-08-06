using Factory.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Factory.Controllers
{
    public class MachinesController : Controller
    {
        public static List<Machine> Machines = new()
        {
            new Machine(1, "Dreamweaver", "A machine that creates dreams."),
            new Machine(2, "Bubblewrappinator", "A machine that wraps everything in bubbles."),
            new Machine(3, "Laughbox", "A machine that generates endless laughter.")
        };

        public IActionResult Index()
        {
            return View(Machines);
        }
    }
}
