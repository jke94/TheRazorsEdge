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
            int numberOfTurbines = 3;
            WindTurbineSimulator[] windTurbines = new WindTurbineSimulator[3];

            for (int i = 0; i < numberOfTurbines; i++)
            {
                Console.WriteLine("i = " + i);
                windTurbines[i] = new WindTurbineSimulator(i);
            }

            Task.WaitAll(windTurbines[0].TurbineTask);
            Task.WaitAll(windTurbines[1].TurbineTask);
            Task.WaitAll(windTurbines[2].TurbineTask);

            //Task[] tasks = new Task[3]
            //{
            //    Task.Run(() => InitializeNamedPipeClient(NamedPipesName.ThePipeNameTemperatura)),
            //    Task.Run(() => InitializeNamedPipeClient(NamedPipesName.ThePipeNameHumedad)),
            //    Task.Run(() => InitializeNamedPipeClient(NamedPipesName.ThePipeNamePresion)),
            //};
        }
    }
}
