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

    }
}
