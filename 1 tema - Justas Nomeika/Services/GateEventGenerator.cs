using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1_tema___Justas_Nomeika.Classes;
using _1_tema___Justas_Nomeika.Repositories;

namespace _1_tema___Justas_Nomeika.Services
{
    public class GateEventGenerator
    {

        public GateEventGenerator()
        {

        }


        public List<GateEvent> GenerateEvents()
        {
            Random r = new Random();
            List<GateEvent> gateEvents = new List<GateEvent>();

            EmployeeRepository _employeeRepository = new EmployeeRepository();
            EntryGateRepository _entryGateRepository = new EntryGateRepository();

            List<Employee> _employees = _employeeRepository.Retrieve();
            List<EntryGate> _entryGates = _entryGateRepository.Retrieve();

            int gateIdMin = _entryGates.Min(r => r.Id);
            int gateIdMax = _entryGates.Max(r => r.Id);

            int eventId = 0;

            foreach (Employee e in _employees)
            {
                eventId++;
                int gateId = _employeeRepository.Retrieve(e.Id).SecurityLevel;
                /*

                DateTime timestamp = DateTime.Parse("2022-10-17 08:00:00");
                string employee = _employeeRepository.Retrieve(e.Id).FullName;
                int employeeSecurity = _employeeRepository.Retrieve(e.Id).SecurityLevel;
                string gateTitle = _entryGateRepository.Retrieve(employeeSecurity).GateTitle;
                bool entryGranted = true;
                */


                int gateSecurity = _entryGateRepository.Retrieve(_employeeRepository.Retrieve(e.Id).SecurityLevel).SecurityLevel;
                string gateTitle = _entryGateRepository.Retrieve(e.SecurityLevel).GateTitle;

                DateTime timestamp = DateTime.Parse($"{DateTime.Now.Year}-{DateTime.Now.Month}-{DateTime.Now.Day} 08:00:00").AddMinutes(r.Next(0, 30)).AddSeconds(r.Next(0, 59));

                string employee = _employeeRepository.Retrieve(e.Id).FullName;
                int employeeSecurity = _employeeRepository.Retrieve(e.Id).SecurityLevel;

                bool entryGranted = gateSecurity <= employeeSecurity ? true : false;

                GateEvent lastItem;

                //Morning entry
                gateEvents.Add(new GateEvent(eventId, gateTitle, timestamp, employee, entryGranted));

                //Console.WriteLine($"{eventId} {gateTitle} {timestamp} {employee} {entryGranted}");


                for (int i = 0; i < r.Next(10, 20); i++)
                {
                    eventId++;

                    lastItem = gateEvents.LastOrDefault();
                    //Event variables
                    gateId = r.Next(gateIdMin, gateIdMax);
                    gateTitle = _entryGateRepository.Retrieve(gateId).GateTitle;
                    gateSecurity = _entryGateRepository.Retrieve(gateId).SecurityLevel;
                    entryGranted = gateSecurity <= employeeSecurity ? true : false;
                    timestamp = lastItem.Timestamp.AddHours(r.Next(0, 1)).AddMinutes(r.Next(0, 30)).AddSeconds(r.Next(0, 59));

                    //Add event to gateEvents list
                    gateEvents.Add(new GateEvent(eventId, gateTitle, timestamp, employee, entryGranted));



                }



            }

            return gateEvents;
        }

    }
}
