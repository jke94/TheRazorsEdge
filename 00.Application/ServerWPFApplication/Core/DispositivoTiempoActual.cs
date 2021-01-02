using ServerWPFApplication.Model;

namespace ServerWPFApplication.Core
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