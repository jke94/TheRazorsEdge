using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientConsoleSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfTurbines = 5;
            WindTurbineSimulator[] windTurbines = new WindTurbineSimulator[numberOfTurbines];

            for (int i = 0; i < numberOfTurbines; i++)
            {
                windTurbines[i] = new WindTurbineSimulator(i);
            }

            for (int i = 0; i < numberOfTurbines; i++)
            {
                Task.WaitAll(windTurbines[i].TurbineTask);
            }
        }
    }
}
