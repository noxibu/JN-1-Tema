using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1_tema___Justas_Nomeika.Classes;

namespace _1_tema___Justas_Nomeika.Repositories
{
    internal class EmployeeRepository
    {
        List<Employee> Employees { get; set; }

        public EmployeeRepository()
        {
            Employees = new List<Employee>();
            var enviroment = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(enviroment).Parent.Parent.FullName;

            using (StreamReader reader = new StreamReader(projectDirectory + "\\EmployeeRepository.csv"))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(",");

                    Employees.Add(new Employee(short.Parse(values[0]), values[1], short.Parse(values[2])));

                }
            }

        }

        public List<Employee> Retrieve()
        {
            return Employees;
        }

        public Employee Retrieve(int id)
        {
            return Employees.Where(a => a.Id == id).FirstOrDefault();
        }
    }
}
