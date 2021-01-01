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
            int numberOfTurbines = 5;
            WindTurbineSimulator[] windTurbines = new WindTurbineSimulator[numberOfTurbines];

            for(int i = 0; i < numberOfTurbines; i++)
            {
                Console.WriteLine("i = " + i);
                windTurbines[i] = new WindTurbineSimulator(i);
            }
            
            for(int i=0; i < numberOfTurbines; i++)
            {
                Task.WaitAll(windTurbines[i].TurbineTask);
            }
        }
    }
}
