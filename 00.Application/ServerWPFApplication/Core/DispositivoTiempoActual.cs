using ServerWPFApplication.Model;

namespace ServerWPFApplication.Core
{
    public class DispositivoTiempoActual
    {
        public void ActualizarPantallaDipositivo(object sender, Oddfellow medidas)
        {
            var temperatura = medidas.Temperatura;
            var presion = medidas.Presion;
            var humedad = medidas.Humedad;
        }
    }
}