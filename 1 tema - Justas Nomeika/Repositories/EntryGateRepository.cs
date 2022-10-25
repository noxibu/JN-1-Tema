using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1_tema___Justas_Nomeika.Classes;

namespace _1_tema___Justas_Nomeika.Repositories
{
    internal class EntryGateRepository
    {
        List<EntryGate> Gates { get; set; }

        public EntryGateRepository()
        {
            Gates = new List<EntryGate>();

            List<EntryGate> gateList = new List<EntryGate>();

            var enviroment = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(enviroment).Parent.Parent.FullName;

            using (StreamReader reader = new StreamReader(projectDirectory + "\\EntryGateRepository.csv"))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(",");

                    Gates.Add(new EntryGate(short.Parse(values[0]), values[1], short.Parse(values[2])));

                }
            }

        }


        public List<EntryGate> Retrieve()
        {
            return Gates;
        }

        public EntryGate Retrieve(int id)
        {
            return Gates.Where(a => a.Id == id).FirstOrDefault();
        }
    }
}
