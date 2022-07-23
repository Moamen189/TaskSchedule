using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using TaskSchedule.BL;

namespace TaskSchedule
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            string JsonString = File.ReadAllText("Process.json");
            List<Process> LstProcesses = JsonConvert.DeserializeObject<List<Process>>(JsonString);
            ISchedualProcesess ProcessAlgorithm = new SchedualProcesess(LstProcesses);
            int nTimeIndex = 0;
            Process CurrentProcess = ProcessAlgorithm.IncomingProcess();

            while (true)
            {

                Console.WriteLine($"Process Name {CurrentProcess.ProcessName} Remain Burst Time {CurrentProcess.RemainBurstTime} ");
                CurrentProcess.RemainBurstTime--;
                if (CurrentProcess.RemainBurstTime == 0)
                {
                    if (ProcessAlgorithm.WaitingProcess.Count > 0)
                    {
                        CurrentProcess = ProcessAlgorithm.IncomingQueue(CurrentProcess);
                    }
                }

            }
            nTimeIndex++;
            CurrentProcess = ProcessAlgorithm.IncomingProcess(CurrentProcess, nTimeIndex);

            if (ProcessAlgorithm.WaitingProcess.Count > 0)
            {
                CurrentProcess = ProcessAlgorithm.IncomingQueue(CurrentProcess);
            }
        }
        //string NewString = JsonConvert.SerializeObject(LstProcesses);
        //File.WriteAllText("Process.txt", NewString);
    }
        
    
}
