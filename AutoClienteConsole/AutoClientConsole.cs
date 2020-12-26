using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutoClienteConsole
{
    public class AutoClientConsole
    {
        static void  Main(string[] args)
        {
            Task[] tasks = new Task[3]
            {
                Task.Run(() => InitializeNamedPipeClient(NamedPipesName.ThePipeNameTemperatura)),
                Task.Run(() => InitializeNamedPipeClient(NamedPipesName.ThePipeNameHumedad)),
                Task.Run(() => InitializeNamedPipeClient(NamedPipesName.ThePipeNamePresion)),
            };

            Task.WaitAll(tasks);
        }

        private static void InitializeNamedPipeClient(string pipeClientName)
        {
            using (NamedPipeClientStream pipeClient =
                    new NamedPipeClientStream(".", pipeClientName, PipeDirection.Out))
            {
                // Connect to the pipe or wait until the pipe is available.
                Console.WriteLine("[{0}] Attempting to connect to pipe...", pipeClientName);
                pipeClient.Connect();

                Console.WriteLine("[{0}] Connected to pipe.", pipeClientName);
                Console.WriteLine("[{0}] There are currently {0} pipe server instances open.",
                                    pipeClientName, pipeClient.NumberOfServerInstances.ToString());
                try
                {
                    var count = 0;
                    // Read user input and send that to the client process.
                    using (StreamWriter sw1 = new StreamWriter(pipeClient))
                    {
                        sw1.AutoFlush = true;
                        var random = new Random();
                        do
                        {
                            sw1.WriteLine(DateTime.Now);
                            sw1.FlushAsync();
                            Thread.Sleep(250 * (int)random.Next(10, 30)/Thread.CurrentThread.ManagedThreadId);
                            count++;
                            Console.WriteLine(string.Format("[{0}], Count = {1}", pipeClientName, count));
                        }
                        while (count < 10);

                        sw1.WriteLine("[{0}] El cliente cerró la conecxión", pipeClientName);
                    }
                }
                // Catch the IOException that is raised if the pipe is broken
                // or disconnected.
                catch (IOException e)
                {
                    Console.WriteLine("[{0}] ERROR: {0}", pipeClientName, e.Message);
                }
            }
            Console.WriteLine("[{0}] El cliente ha cerrado la conecxión...", pipeClientName);
        }
    }
}
