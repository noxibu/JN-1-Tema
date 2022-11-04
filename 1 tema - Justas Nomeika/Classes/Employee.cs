using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_tema___Justas_Nomeika.Classes
{
    public class Employee
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int SecurityLevel { get; set; }


        public Employee(int id, string fullName, int securityLevel)
        {
            Id = id;
            FullName = fullName;
            SecurityLevel = securityLevel;
        }
    }
}
