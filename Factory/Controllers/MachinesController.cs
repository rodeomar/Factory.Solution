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

        public IActionResult Details(int id)
        {
            Machine? machine = Machines.FirstOrDefault(m => m.MachineId == id);

            if (machine == null)
            {
                return NotFound();
            }
            return View(machine);
        }

        public IActionResult Create(string Name, string Description)
        {
            int newId = Machines.Max(e => e.MachineId) + 1;
            Machine newMachine = new Machine(newId, Name, Description);
            Machines.Add(newMachine);

            return RedirectToAction("Index");
        }

    }
}

