using System.Reflection.PortableExecutable;

namespace Factory.Models
{
    public class Engineer
    {
        public string Name { get; set; }
        public string LicenseID{ get; set; }
        public List<Machine> Machines { get; set; }


        public Engineer(string Name, string licenseID)
        {

            this.Name = Name;

            this.Machines = new();
            this.LicenseID = licenseID;
        }


    }
}
