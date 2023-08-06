namespace Factory.Models
{
    public class Engineer
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }    
        public string LicenseID{ get; set; }
        public int EngineerID { get; set; }
        public List<Machine> Machines { get; set; }


        public Engineer(string Name, string email, string phone, string licenseID, int engineerID)
        {

            this.Name = Name;
            this.Email = email;
            this.Phone = phone;
            this.Machines = new();
            this.LicenseID = licenseID;
            this.EngineerID = engineerID;
            this.Machines = new() { new Machine(1, "Microwave", "It is not working I dontknow why") };
        }


    }
}
