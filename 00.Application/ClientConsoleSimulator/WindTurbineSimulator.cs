using System;
using System.IO;
using System.IO.Pipes;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Shared;

namespace ClientConsoleSimulator
{
    public class WindTurbineSimulator
    {
        private Task[] turbineTask = new Task[3];

        private static int numberOfMetricToSend = 10;

        public WindTurbineSimulator(int numberOfTurbine)
        {
            turbineTask = new Task[3]
            {
                Task.Run(() => InitializeNamedPipeClient(new NamedPipeNameBuilder(NamedPipesName.ThePipeNameTemperatura,   "Turbine", numberOfTurbine).ToString())),
                Task.Run(() => InitializeNamedPipeClient(new NamedPipeNameBuilder(NamedPipesName.ThePipeNameHumedad,       "Turbine", numberOfTurbine).ToString())),
                Task.Run(() => InitializeNamedPipeClient(new NamedPipeNameBuilder(NamedPipesName.ThePipeNamePresion,       "Turbine", numberOfTurbine).ToString())),
            };
        }
        public Task[] TurbineTask { get => turbineTask; set => turbineTask = value; }

        private static  void InitializeNamedPipeClient(string pipeClientName)
        {
            using (NamedPipeClientStream pipeClient =
                    new NamedPipeClientStream(".", pipeClientName, PipeDirection.Out))
            {
                // Connect to the pipe or wait until the pipe is available.
                Console.WriteLine("[{0}]\tAttempting to connect to pipe...", pipeClientName);
                pipeClient.Connect();
                Console.WriteLine("[{0}]\tConnected to pipe.", pipeClientName);
                Console.WriteLine("[{0}]\tThere are currently {1} pipe server instances open.",
                                    pipeClientName, pipeClient.NumberOfServerInstances.ToString());
                  
                try
                {
                    var count = 0;
          
                    using (StreamWriter sw1 = new StreamWriter(pipeClient))
                    {
                        sw1.AutoFlush = true;
                        do
                        {
                            var metric = new TheMetric();
                            
                            sw1.WriteLine(JsonConvert.SerializeObject(metric));
                            sw1.Flush();
                            count++;

                            Thread.Sleep(metric.TimeToSleep);

                            Console.WriteLine(string.Format("[{0}]\tMetric => WhatToDo = {1}, TheValue = {2}, TimeToSleep = {3} miliseconds.", 
                                                            pipeClientName, metric.WhatToDo, metric.TheValue, metric.TimeToSleep));
                        }
                        while (count < numberOfMetricToSend);
                    }                    
                }
                catch (Exception e)
                {
                    Console.WriteLine("[{0}]\tERROR: {1}", pipeClientName, e.Message);
                }
            }
            Console.WriteLine("[{0}]\tThe client has closed the connection.", pipeClientName);
        }
    }
}
