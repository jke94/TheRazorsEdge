using System;
using ServerWPFApplication.Model;

namespace ServerWPFApplication.Core
{
    public class WeatherStation
    {
        public decimal Temperature { get; private set; }
        public decimal Pressure { get; private set; }
        public decimal Humidity { get; private set; }

        public event EventHandler<Oddfellow> TimeHasChanged;

        public void IncreaseTheTemperatureInDegrees(int grados)
        {
            Temperature += grados;

            Notificar();
        }

        public void DecreaseTheTemperatureInDegrees(int grados)
        {
            Temperature -= grados;

            Notificar();
        }

        public void IncreaseThePreasureInBar(int bares)
        {
            Pressure += bares;

            Notificar();
        }

        public void DecreaseThePreasureInBar(int bares)
        {
            Pressure -= bares;

            Notificar();
        }

        public void IncreaseHumidityInPercentage(int porcentaje)
        {
            Humidity += porcentaje;

            Notificar();
        }

        public void DecreaseHumidityInPercentage(int porcentaje)
        {
            Humidity -= porcentaje;

            Notificar();
        }

        public void Notificar()
        {
            var medidas = new Oddfellow(Temperature, Humidity, Pressure);

            if (TimeHasChanged != null)
                TimeHasChanged.Invoke(this, medidas);
        }

        public WeatherStation()
        {
            // Data by default.

            Temperature = 20;
            Pressure = 100;
            Humidity = 50;
        }
    }
}