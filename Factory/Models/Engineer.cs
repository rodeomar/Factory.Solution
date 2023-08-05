using System.Reflection.PortableExecutable;

namespace Factory.Models
{
    public class Engineer
    {
        public string Name { get; set; }
        public string LicenseDetails { get; set; }
        public List<Machine> Machines { get; set; }


        public Engineer(string Name, string licenseDetails)
        {

            this.Name = Name;

            this.Machines = new();
            this.LicenseDetails = licenseDetails;
        }


    }
}
