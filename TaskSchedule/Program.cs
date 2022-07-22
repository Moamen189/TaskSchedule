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
            string NewString = JsonConvert.SerializeObject(LstProcesses);
            File.WriteAllText("Process.txt", NewString);
            Console.ReadKey();
        }
    }
}
