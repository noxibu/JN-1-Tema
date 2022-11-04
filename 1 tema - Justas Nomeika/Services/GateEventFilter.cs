using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1_tema___Justas_Nomeika.Classes;
using _1_tema___Justas_Nomeika.Services;

namespace _1_tema___Justas_Nomeika.Services
{
    public class GateEventFilter
    {


        public GateEventFilter()
        {

        }


        public List<GateEvent> FilterByDate(List<GateEvent> gateEvents, DateTime fromDate, DateTime toDate)
        {

            List<GateEvent> filteredEvents = new List<GateEvent>();

            filteredEvents = gateEvents.Where(x => x.Timestamp >= fromDate).Where(y => y.Timestamp <= toDate).ToList();

            if (filteredEvents.Count > 0)
            {
                foreach (var f in filteredEvents)
                {
                    // Console.WriteLine($"{f.Id} {f.Employee} {f.GateTitle} {f.Timestamp} {f.EntryGranted}");
                }
            }
            else
            {
                Console.WriteLine("No data matching the criteria.");
            }



            return filteredEvents;
        }

        public List<GateEvent> FilterByEmployee(List<GateEvent> gateEvents, string employee)
        {

            List<GateEvent> filteredEvents = new List<GateEvent>();
            filteredEvents = gateEvents.Where(x => x.Employee == employee).ToList();

            if (filteredEvents.Count > 0)
            {
                foreach (var f in filteredEvents)
                {
                    // Console.WriteLine($"{f.Id} {f.Employee} {f.GateTitle} {f.Timestamp} {f.EntryGranted}");
                }
            }
            else
            {
                Console.WriteLine("No data matching the criteria.");
            }

            return filteredEvents;
        }

        public List<GateEvent> SortByTime(List<GateEvent> gateEvents)
        {
            List<GateEvent> sortedEvents = new List<GateEvent>();

            sortedEvents = gateEvents.OrderBy(x => x.Timestamp).ToList();


            return sortedEvents;
        }

        public void WriteToHTML(List<GateEvent> eventList)
        {
            Random r = new Random();
            string fullPath = @"C:\Users\Justas\source\repos\1 tema - Justas Nomeika\1 tema - Justas Nomeika\GeneratedReport" + DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss") + "--" + r.Next(1, 100) + ".html";
            List<string> htmlDataList = new List<string>();
            string htmlData = "";

            foreach (GateEvent x in eventList)
            {
                htmlDataList.Add($"<tr>\r\n    <td>{x.Id}</td>\r\n    <td>{x.Employee}</td>\r\n    <td>{x.GateTitle}</td>\r\n    <td>{x.Timestamp}</td>\r\n</tr>");
            }


            htmlData = string.Join("", htmlDataList);
            string htmlBody = "<!DOCTYPE html>\r\n<html>\r\n<head>\r\n<style>\r\ntable {\r\n  font-family: arial, sans-serif;\r\n  border-collapse: collapse;\r\n  width: 100%;\r\n}\r\n\r\ntd, th {\r\n  border: 1px solid #dddddd;\r\n  text-align: left;\r\n  padding: 8px;\r\n}\r\n\r\ntr:nth-child(even) {\r\n  background-color: #dddddd;\r\n}\r\n</style>\r\n</head>\r\n<body>\r\n\r\n\r\n\r\n<table>\r\n  <tr>\r\n    <th>ID</th>\r\n    <th>Employee</th>\r\n    <th>Gate Title</th>\r\n    <th>Date</th>\r\n  </tr>" + htmlData + "\r\n</table>\r\n\r\n</body>\r\n</html>";


            using (StreamWriter sw = new StreamWriter(fullPath))
            {
                sw.Write(htmlBody);
            }




        }
    }
}
