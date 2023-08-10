using Factory.Models;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;


namespace Factory.Controllers
{
    public class EngineersController : Controller
    {

        private static MySqlConnection GetConnection()
        {
            return new MySqlConnection(DBConfiguration.ConnectionString);
        }


        private Engineer GetEngineerById(int engineerId)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();

                string sql = "SELECT * FROM Engineers WHERE EngineerID = @EngineerID";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@EngineerID", engineerId);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Engineer(
                            reader.GetString("Name"),
                            reader.GetString("Email"),
                            reader.GetString("Phone"),
                            reader.GetString("LicenseID"),
                            reader.GetInt32("EngineerID")
                        );
                    }
                }
            }

            return null;
        }

        public static List<Engineer> GetAllEngineers()
        {
            List<Engineer> Engineers = new List<Engineer>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();

                string sql = "SELECT * FROM Engineers";
                MySqlCommand cmd = new MySqlCommand(sql, conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Engineer engineer = new Engineer(
                            reader.GetString("Name"),
                            reader.GetString("Email"),
                            reader.GetString("Phone"),
                            reader.GetString("LicenseID"),
                            reader.GetInt32("EngineerID")
                        );

                        Engineers.Add(engineer);
                    }
                }
            }

            return Engineers;
        }

        public IActionResult Index()
        {
            return View(GetAllEngineers());
        }

        public IActionResult Details(int id)
        {
            Engineer? engineer = GetEngineerById(id);

            if (engineer != null)
            {
                return View(engineer);
            }

            return NotFound();
        }

        public IActionResult Create(string Name, string Email, string Phone, string LicenseID)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();

                string insertSql = "INSERT INTO Engineers (Name, Email, Phone, LicenseID) VALUES (@Name, @Email, @Phone, @LicenseID)";
                MySqlCommand cmd = new MySqlCommand(insertSql, conn);
                cmd.Parameters.AddWithValue("@Name", Name);
                cmd.Parameters.AddWithValue("@Email", Email);
                cmd.Parameters.AddWithValue("@Phone", Phone);
                cmd.Parameters.AddWithValue("@LicenseID", LicenseID);
                cmd.ExecuteNonQuery();

                return RedirectToAction("Index");
            }
        }

        public IActionResult Edit(int EngineerID, string Name, string Email, string Phone, string LicenseID)
        {
            Engineer? engineer = GetEngineerById(EngineerID);

            if (engineer != null)
            {
                engineer.Update(Name, Email, Phone, LicenseID);
            }

            return RedirectToAction("Details", new { id = EngineerID });
        }


        public IActionResult Delete(int EngineerId)
        {
            Engineer? engineer = GetEngineerById(EngineerId);

            if(engineer != null)
            {
                engineer.Delete();
            }

            return RedirectToAction("Index");
        }




        public IActionResult RemoveMachine(int engineerId, int machineId)
        {
            Engineer? engineer = GetEngineerById(engineerId);

            if (engineer == null)
            {
                return NotFound();
            }

            engineer.RemoveMachine(machineId);
            
            return RedirectToAction("Details", new { id = engineerId });
        }

        public IActionResult AddMachine(int engineerId, int machineId)
        {
            Engineer? engineer = GetAllEngineers().FirstOrDefault(e => e.EngineerID == engineerId);

            if (engineer != null)
            {
                engineer.AddMachine(machineId);
            }

            return RedirectToAction("Details", new { id = engineerId });
        }
    }
}