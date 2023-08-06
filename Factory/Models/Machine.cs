namespace Factory.Models
{
    public class Machine
    {

        public int MachineId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Engineer> Engineers { get; set; }

        public Machine(int ID, string Name, string description)
        {
            this.MachineId = ID;
            this.Name = Name;
            this.Description = description;
            this.Engineers = new();
        }

        public void AddEngineer(Engineer engineer)
        {
            if (!Engineers.Contains(engineer))
            {
                Engineers.Add(engineer);
                engineer.Machines.Add(this);
            }
        }

        public void RemoveEngineer(Engineer engineer)
        {
            if (Engineers.Contains(engineer))
            {
                Engineers.Remove(engineer);
                engineer.Machines.Remove(this);
            }
        }

    }
}
