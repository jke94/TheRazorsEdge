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

        public void ActualizarPantallaDipositivo(object sender, Oddfellow medidas)
        {
            var temperatura = medidas.Temperatura;
            var presion = medidas.Presion;
            var humedad = medidas.Humedad;

            // cosas importantes que hacer con las medidas
        }
    }
}