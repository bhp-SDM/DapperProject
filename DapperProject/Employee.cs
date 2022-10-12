namespace DapperProject
{
    public class Employee
    {
        public int SSN { get; set; }
        public string? FName { get; set; }
        public string? LName { get; set; }

        public List<Project> Projects { get; set; }

        public Employee()
        {
            Projects = new List<Project>();
        }

        public override string ToString()
        {
            return $"{SSN,10} {FName + " " + LName}";
        }
    }
}
