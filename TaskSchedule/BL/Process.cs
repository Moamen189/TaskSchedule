using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskSchedule.BL
{
    public class Process
    {
        public String ProcessName { get; set; }
        public int ArrivalTime { get; set; }

        public int BurstTime { get; set; }
    }
}
