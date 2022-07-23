using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskSchedule.BL
{
    public class Process
    {
        public Process()
        {
            RemainBurstTime = BurstTime;
        }
        public string ProcessName { get; set; }
        public int ArrivalTime { get; set; }

        public int BurstTime { get; set; }
        public int RemainBurstTime { get; set; }

    }
}
