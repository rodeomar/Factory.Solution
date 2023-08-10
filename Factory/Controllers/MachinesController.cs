using Factory.Models;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;

namespace Factory.Controllers
{
    public class MachinesController : Controller
    {
        private static MySqlConnection GetConnection()
        {
            return new MySqlConnection(DBConfiguration.ConnectionString);
        }

        public static List<Machine> GetAllMachines()
        {
            List<Machine> Machines = new List<Machine>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();

                string sql = "SELECT * FROM Machines";
                MySqlCommand cmd = new MySqlCommand(sql, conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Machine machine = new Machine(
                            reader.GetInt32("MachineID"),
                            reader.GetString("Name"),
                            reader.GetString("Description")
                        );

                        Machines.Add(machine);
                    }
                }
            }

            return Machines;
        }

        public IActionResult Index()
        {
            return View(GetAllMachines());
        }

        private Machine GetMachineByID(int id)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();

                string sql = "SELECT * FROM Machines WHERE MachineID = @ID";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ID", id);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Machine(
                            reader.GetInt32("MachineID"),
                            reader.GetString("Name"),
                            reader.GetString("Description")
                        );
                    }
                }
            }

            return null; // Return null only when no machine is found
        }


        public IActionResult Details(int id)
        {
            Machine? machine = GetMachineByID(id);

            if (machine != null)
            {
                return View(machine);
            }

            return NotFound();
        }

        public IActionResult Create(string Name, string Description)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();

                string insertSql = "INSERT INTO Machines (Name, Description) VALUES (@Name, @Description)";
                MySqlCommand cmd = new MySqlCommand(insertSql, conn);
                cmd.Parameters.AddWithValue("@Name", Name);
                cmd.Parameters.AddWithValue("@Description", Description);
                cmd.ExecuteNonQuery();

                return RedirectToAction("Index");
            }
        }

        public IActionResult Edit(int MachineID, string Name, string Description)
        {
            Machine? machine= GetMachineByID(MachineID);

            if (machine != null)
            {
                machine.Update(Name, Description);
            }

            return RedirectToAction("Details", new { id = MachineID });
        }

        public IActionResult Delete(int MachineId)
        {
            Machine? machine = GetMachineByID(MachineId);

            if (machine != null)
            {
                machine.Delete();
            }

            return RedirectToAction("Index");
        }



        public IActionResult RemoveEngineer(int engineerId, int machineId)
        {
            Machine? machine = GetMachineByID(machineId);

            if (machine != null)
            {
                machine.RemoveEngineer(engineerId);
            }

            return RedirectToAction("Details", new { id = machineId });
        }


        public IActionResult AddEngineer(int machineId, int engineerId)
        {
            Machine? machine = GetMachineByID(machineId);

            if (machine != null)
            {
                machine.AddEngineer(engineerId);
            }

            return RedirectToAction("Details", new { id = machineId });
        }
    }
}

