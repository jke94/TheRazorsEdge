using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerWPFApplication.Model
{
    public class WindTurbine
    {
        private int windTurbineID;
        private string windTurbineName;

        public WindTurbine(int windTurbID, string windTurbName)
        {
            WindTurbineID = windTurbID;
            WindTurbineName = windTurbName;
        }

        public int WindTurbineID { get => windTurbineID; set => windTurbineID = value; }
        public string WindTurbineName { get => windTurbineName; set => windTurbineName = value; }

        public override string ToString()
        {
            return string.Concat(WindTurbineName, " - ", WindTurbineID);
        }
    }
}
