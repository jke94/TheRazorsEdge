using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoClienteConsole
{
    public class NamedPipeNameBuilder
    {
        private string sensorName;
        private string theObject;
        private int turbineID;

        public NamedPipeNameBuilder(string sensorName, string theObject, int turbineID)
        {
            SensorName = sensorName;
            TheObject = theObject;
            TurbineID = turbineID;
        }

        public string SensorName { get => sensorName; set => sensorName = value; }
        public string TheObject { get => theObject; set => theObject = value; }
        public int TurbineID { get => turbineID; set => turbineID = value; }

        public override string ToString()
        {
            return string.Concat(SensorName, TheObject, TurbineID);
        }
    }
}