using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace _1_tema___Justas_Nomeika.Classes
{
    internal class GateEvent
    {
        public int Id { get; set; }
        public string GateTitle { get; set; }
        public DateTime Timestamp { get; set; }
        public string Employee { get; set; }
        public bool EntryGranted { get; set; }

        public GateEvent(int id, string gateTitle, DateTime timestamp, string employee, bool entryGranted)
        {
            Id = id;
            GateTitle = gateTitle;
            Timestamp = timestamp;
            Employee = employee;
            EntryGranted = entryGranted;
        }

    }
}
