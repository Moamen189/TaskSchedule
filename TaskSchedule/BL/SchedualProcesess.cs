using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskSchedule.BL
{
    internal class SchedualProcesess : ISchedualProcesess
    {
        public SchedualProcesess()
        {
            MainProcess = new List<Process>();
            WaitingProcess = new List<Process>();

        }

        public SchedualProcesess(List<Process> mainProcess)
        {
            MainProcess = mainProcess;
            WaitingProcess= new List<Process>();

        }
        public List<Process> MainProcess { get; set; }
        public List<Process> WaitingProcess { get; set; }

        public Process IncomingProcess(Process CurrentProcess, int TimeLineProcess)
        {
           Process MyProcess = MainProcess.Where(a => a.ArrivalTime == TimeLineProcess).FirstOrDefault();
            if(MyProcess == null)
            {
                return CurrentProcess;
            }
            else
            {
                if(CurrentProcess.BurstTime < MyProcess.BurstTime)
                {
                    WaitingProcess.Add(MyProcess);
                    return CurrentProcess;
                }
                else
                {
                    WaitingProcess.Add(CurrentProcess);
                    return MyProcess;
                }
            }
        }

        public Process IncomingProcess(Process CurrentProcess)
        {
            int miniBurstTime = WaitingProcess.Min(a => a.BurstTime);
            Process MyProcess = WaitingProcess.Where(a => a.BurstTime == miniBurstTime).FirstOrDefault();
            if (CurrentProcess.BurstTime < MyProcess.BurstTime)
            {
              
                return CurrentProcess;
            }else
            {
                WaitingProcess.Remove(MyProcess);
                WaitingProcess.Add(CurrentProcess);
                return MyProcess;
            }
        }
    }
}
