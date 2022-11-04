using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using _1_tema___Justas_Nomeika.Classes;
using _1_tema___Justas_Nomeika.Services;
using static System.Net.Mime.MediaTypeNames;

namespace _1_tema___Justas_Nomeika
{
    internal class Program
    {
        static void Main(string[] args)
        {

            GateEventGenerator eventObject = new GateEventGenerator();
            List<GateEvent> gateEvents = eventObject.GenerateEvents();


            GateEventFilter eventFilter = new GateEventFilter();

            DateTime timeFrom = DateTime.Parse($"{DateTime.Now.Year}-{DateTime.Now.Month}-{DateTime.Now.Day} 08:00:00 AM");
            DateTime timeTo = DateTime.Parse($"{DateTime.Now.Year}-{DateTime.Now.Month}-{DateTime.Now.Day} 10:00:00 PM");


            List<GateEvent> filteredByDate = eventFilter.FilterByDate(gateEvents, timeFrom, timeTo);
            List<GateEvent> sortedByTime = eventFilter.SortByTime(gateEvents);
            List<GateEvent> filteredEmployee = eventFilter.FilterByEmployee(gateEvents, gateEvents[0].Employee);

            //eventFilter.WriteToHTML(sortedByTime);
            //eventFilter.WriteToHTML(filteredEmployee);

            var filteredByEmployee = eventFilter.FilterByEmployee(gateEvents, gateEvents[0].Employee);
            var testing = filteredByEmployee.Select(x => x.Employee).Distinct().ToList();


            /*foreach(var f in sortedByTime)
            {
                Console.WriteLine($"{f.Id} {f.Employee} {f.GateTitle} {f.Timestamp} {f.EntryGranted}");
            }*/




        }
    }
}
