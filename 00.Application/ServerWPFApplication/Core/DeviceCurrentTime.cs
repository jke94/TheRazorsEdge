using ServerWPFApplication.Model;

namespace ServerWPFApplication.Core
{
    public class DeviceCurrentTime
    {
        public void ActualizarPantallaDipositivo(object sender, Oddfellow medidas)
        {
            var temperatura = medidas.Temperature;
            var presion = medidas.Pressure;
            var humedad = medidas.Humidity;
        }
    }
}