using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFPApp
{
    public class DispositivoTiempoActual
    {
        // otras métodos y propiedades del dispositivo

        public void ActualizarPantallaDipositivo(object sender, Tuple<decimal, decimal, decimal> medidas)
        {
            var temperatura = medidas.Item1;
            var presion = medidas.Item2;
            var humedad = medidas.Item3;

            // cosas importantes que hacer con las medidas
        }
    }
}