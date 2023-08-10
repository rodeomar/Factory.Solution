using MySqlConnector;

namespace Factory.Models
{
    public class Engineer
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string LicenseID { get; set; }
        public int EngineerID { get; set; }


        public Engineer(string Name, string email, string phone, string licenseID, int engineerID)
        {

            this.Name = Name;
            this.Email = email;
            this.Phone = phone;
            this.LicenseID = licenseID;
            this.EngineerID = engineerID;
        }


        public List<Machine> GetMachines()
        {
            List<Machine> machines = new List<Machine>();

            using (MySqlConnection conn = new MySqlConnection(DBConfiguration.ConnectionString))
            {
                conn.Open();

                string sql = "SELECT m.* FROM Machines AS m INNER JOIN EngineerMachine AS em ON m.MachineID = em.MachineID WHERE em.EngineerID = @EngineerID";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@EngineerID", EngineerID);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Machine machine = new Machine(
                            reader.GetInt32("MachineID"),
                            reader.GetString("Name"),
                            reader.GetString("Description")
                        );

                        machines.Add(machine);
                    }
                }
            }

            return machines;
        }
        public void AddMachine(int machineId)
        {
            using (MySqlConnection conn = new MySqlConnection(DBConfiguration.ConnectionString))
            {
                conn.Open();

                string insertSql = "INSERT INTO EngineerMachine (EngineerID, MachineID) VALUES (@EngineerID, @MachineID)";
                MySqlCommand insertCmd = new MySqlCommand(insertSql, conn);
                insertCmd.Parameters.AddWithValue("@EngineerID", EngineerID);
                insertCmd.Parameters.AddWithValue("@MachineID", machineId);

                try
                {
                    insertCmd.ExecuteNonQuery();
                }
                catch (MySqlException)
                {
                    return;
                }


            }
        }
        public void RemoveMachine(int machineId)
        {
            using (MySqlConnection conn = new MySqlConnection(DBConfiguration.ConnectionString))
            {
                conn.Open();

                string deleteSql = "DELETE FROM EngineerMachine WHERE EngineerID = @EngineerID AND MachineID = @MachineID";
                MySqlCommand deleteCmd = new MySqlCommand(deleteSql, conn);
                deleteCmd.Parameters.AddWithValue("@EngineerID", EngineerID);
                deleteCmd.Parameters.AddWithValue("@MachineID", machineId);
                deleteCmd.ExecuteNonQuery();
            }
        }



        public void Delete()
        {
            using (MySqlConnection conn = new MySqlConnection(DBConfiguration.ConnectionString))
            {
                conn.Open();

                // Remove the engineer from EngineerMachine table
                string deleteEngineerMachineSql = "DELETE FROM EngineerMachine WHERE EngineerID = @EngineerID";
                MySqlCommand deleteEngineerMachineCmd = new MySqlCommand(deleteEngineerMachineSql, conn);
                deleteEngineerMachineCmd.Parameters.AddWithValue("@EngineerID", EngineerID);
                deleteEngineerMachineCmd.ExecuteNonQuery();

                // Remove the engineer from Engineers table
                string deleteEngineerSql = "DELETE FROM Engineers WHERE EngineerID = @EngineerID";
                MySqlCommand deleteEngineerCmd = new MySqlCommand(deleteEngineerSql, conn);
                deleteEngineerCmd.Parameters.AddWithValue("@EngineerID", EngineerID);
                deleteEngineerCmd.ExecuteNonQuery();
            }
        }

        public void Update(string Name, string Email, string Phone, string LicenseID)
        {
            using (MySqlConnection conn = new MySqlConnection(DBConfiguration.ConnectionString))
            {
                conn.Open();

                string updateSql = "UPDATE Engineers SET Name = @Name, Email = @Email, Phone = @Phone, LicenseID = @LicenseID WHERE EngineerID = @EngineerID";
                MySqlCommand updateCmd = new MySqlCommand(updateSql, conn);
                updateCmd.Parameters.AddWithValue("@Name", Name);
                updateCmd.Parameters.AddWithValue("@Email", Email);
                updateCmd.Parameters.AddWithValue("@Phone", Phone);
                updateCmd.Parameters.AddWithValue("@LicenseID", LicenseID);
                updateCmd.Parameters.AddWithValue("@EngineerID", EngineerID);
                updateCmd.ExecuteNonQuery();
            }
        }

    }


}
