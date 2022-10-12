using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperProject
{
    public class Project
    {
        public int PNumber { get; set; }
        public string? PName { get; set; }
        public int DNum { get; set; }
        public string? PLocation { get; set; }

        public List<Employee> Employees { get; set; }

        public Project()
        {
            Employees = new List<Employee>();
        }

        public override string ToString()
        {
            return $"{PNumber,5} {PName,-20} {DNum,5} {PLocation}";
        }
    }
}
