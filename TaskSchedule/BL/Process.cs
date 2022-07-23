using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskSchedule.BL
{
    public class Process
    {
        int _BurstTime;
        public string ProcessName { get; set; }
        public int ArrivalTime { get; set; }

        public int BurstTime {
            get { 
            return _BurstTime; 
            } set {
                _BurstTime = value;
                    RemainBurstTime = _BurstTime;
            } }
        public int RemainBurstTime { get; set; }

    }
}
