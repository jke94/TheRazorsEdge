using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFPApp
{
    public class Oddfellow
    {
        public decimal Temperatura { get; private set; }
        public decimal Presion { get; private set; }
        public decimal Humedad { get; private set; }


        public Oddfellow(decimal temperatura, decimal presion, decimal humedad)
        {
            Temperatura = temperatura;
            Presion = presion;
            Humedad = humedad;
        }
    }
}
