using MySqlConnector;

namespace Factory.Models
{
    public class Machine
    {
        public int MachineId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Machine(int ID, string Name, string description)
        {
            this.MachineId = ID;
            this.Name = Name;
            this.Description = description;
        }

        public List<Engineer> GetEngineers()
        {
            List<Engineer> engineers = new List<Engineer>();

            using (MySqlConnection conn = new  MySqlConnection(DBConfiguration.ConnectionString))
            {
                conn.Open();

                string sql = "SELECT e.* FROM Engineers AS e INNER JOIN EngineerMachine AS em ON e.EngineerID = em.EngineerID WHERE em.MachineID = @MachineID";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MachineID", MachineId);

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

                        engineers.Add(engineer);
                    }
                }
            }

            return engineers;
        }

        public void AddEngineer(int engineerId)
        {
            using (MySqlConnection conn = new MySqlConnection(DBConfiguration.ConnectionString))
            {
                conn.Open();

                string insertSql = "INSERT INTO EngineerMachine (EngineerID, MachineID) VALUES (@EngineerID, @MachineID)";
                MySqlCommand cmd = new MySqlCommand(insertSql, conn);
                cmd.Parameters.AddWithValue("@EngineerID", engineerId);
                cmd.Parameters.AddWithValue("@MachineID", MachineId);
                try
                {
                    cmd.ExecuteNonQuery();
                }catch (MySqlException)
                {

                }
            }
        }

        public void RemoveEngineer(int engineerId)
        {
            using (MySqlConnection conn = new MySqlConnection(DBConfiguration.ConnectionString))
            {
                conn.Open();

                string deleteSql = "DELETE FROM EngineerMachine WHERE EngineerID = @EngineerID AND MachineID = @MachineID";
                MySqlCommand deleteCmd = new MySqlCommand(deleteSql, conn);
                deleteCmd.Parameters.AddWithValue("@EngineerID", engineerId);
                deleteCmd.Parameters.AddWithValue("@MachineID", MachineId);
                deleteCmd.ExecuteNonQuery();
            }
        }

        public void Delete()
        {
            using (MySqlConnection conn = new MySqlConnection(DBConfiguration.ConnectionString))
            {
                conn.Open();

                // Remove the machine from EngineerMachine table
                string deleteEngineerMachineSql = "DELETE FROM EngineerMachine WHERE MachineID = @MachineID";
                MySqlCommand deleteEngineerMachineCmd = new MySqlCommand(deleteEngineerMachineSql, conn);
                deleteEngineerMachineCmd.Parameters.AddWithValue("@MachineID", MachineId);
                deleteEngineerMachineCmd.ExecuteNonQuery();

                // Remove the machine from Machines table
                string deleteMachineSql = "DELETE FROM Machines WHERE MachineID = @MachineID";
                MySqlCommand deleteMachineCmd = new MySqlCommand(deleteMachineSql, conn);
                deleteMachineCmd.Parameters.AddWithValue("@MachineID", MachineId);
                deleteMachineCmd.ExecuteNonQuery();
            }
        }

        public void Update(string newName, string newDescription)
        {
            using (MySqlConnection conn = new MySqlConnection(DBConfiguration.ConnectionString))
            {
                conn.Open();

                string updateSql = "UPDATE Machines SET Name = @Name, Description = @Description WHERE MachineID = @MachineID";
                MySqlCommand updateCmd = new MySqlCommand(updateSql, conn);
                updateCmd.Parameters.AddWithValue("@Name", newName);
                updateCmd.Parameters.AddWithValue("@Description", newDescription);
                updateCmd.Parameters.AddWithValue("@MachineID", MachineId);
                updateCmd.ExecuteNonQuery();
            }
        }
    }
}
