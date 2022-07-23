using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskSchedule.BL
{
    public interface ISchedualProcesess
    {
        public List<Process> MainProcess { get; set; }
        public List<Process> WaitingProcess { get; set; }
        public List<Process> EndedProcess { get; set; }


        public Process IncomingProcess(Process CurrentProcess, int TimeLineProcess);
        public Process IncomingProcess();

        public Process IncomingQueue(Process CurrentProcess);
    }
}
