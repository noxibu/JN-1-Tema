using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_tema___Justas_Nomeika.Classes
{
    internal class EntryGate
    {
        public int Id { get; set; }
        public string GateTitle { get; set; }
        public int SecurityLevel { get; set; }


        public EntryGate(int id, string gateTitle, int securityLevel)
        {
            Id = id;
            GateTitle = gateTitle;
            SecurityLevel = securityLevel;
        }
    }
}
