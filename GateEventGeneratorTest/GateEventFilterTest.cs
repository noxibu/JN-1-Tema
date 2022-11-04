using System;
using Xunit;
using _1_tema___Justas_Nomeika.Classes;
using _1_tema___Justas_Nomeika.Services;
using System.Collections.Generic;
using _1_tema___Justas_Nomeika;
using System.Linq;

namespace GateEventGeneratorTest
{
    public class GateEventFilterTest
    {
        [Fact]
        public void FilterByEmployeeTest()
        {
            // arrange

            var gateEventGenerator = new GateEventGenerator();
            var gateEventFilter = new GateEventFilter();
            List<GateEvent> gateEvents = gateEventGenerator.GenerateEvents();

            // act
            var filteredByEmployee = gateEventFilter.FilterByEmployee(gateEvents, gateEvents[0].Employee);
            var testing = filteredByEmployee.Select(x => x.Employee).Distinct().ToList();



            // assert
            Assert.Equal(1, testing.Count());
        }
    }
}
