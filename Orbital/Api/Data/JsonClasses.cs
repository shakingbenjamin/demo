using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Data
{
    public class ScheduleEntry
    {
        public string entryNumber { get; set; }
        public string entryDate { get; set; }
        public string entryType { get; set; }
        public IList<string> entryText { get; set; }
    }

    public class Leaseschedule
    {
        public string scheduleType { get; set; }
        public IList<ScheduleEntry> scheduleEntry { get; set; }
    }

    public class Root
    {
        public Leaseschedule leaseschedule { get; set; }
    }
}