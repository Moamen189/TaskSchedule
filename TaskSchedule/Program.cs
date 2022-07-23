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
                if(CurrentProcess == null)
                {
                    if (ProcessAlgorithm.WaitingProcess.Count > ProcessAlgorithm.EndedProcess.Count)
                    {
                        Console.WriteLine("Ideal State Empty Time Line");
                        continue;
                    }
                    else
                        break;
                }

                Console.WriteLine($"Process Name {CurrentProcess.ProcessName} Remain Burst Time {CurrentProcess.RemainBurstTime} ");
                CurrentProcess.RemainBurstTime--;
                if (CurrentProcess.RemainBurstTime == 0)
                {
                    ProcessAlgorithm.EndedProcess.Add(CurrentProcess);
                    if (ProcessAlgorithm.WaitingProcess.Count > 0)
                    {
                        CurrentProcess = ProcessAlgorithm.IncomingQueue(CurrentProcess);
                    }
                    else
                    {
                        CurrentProcess = null;
                    }
                }

            }
            nTimeIndex++;
            CurrentProcess = ProcessAlgorithm.IncomingProcess(CurrentProcess, nTimeIndex);

            if (ProcessAlgorithm.WaitingProcess.Count > 0)
            {
                CurrentProcess = ProcessAlgorithm.IncomingQueue(CurrentProcess);
            }
            Console.WriteLine("*************************************");
            Console.WriteLine("Finished");
            Console.ReadKey();
        }

        //string NewString = JsonConvert.SerializeObject(LstProcesses);
        //File.WriteAllText("Process.txt", NewString);
    }
        
    
}
