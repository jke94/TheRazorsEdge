using System;
using ServerWPFApplication.Model;

namespace ServerWPFApplication.Core
{
    public class EstacionMetereologica
    {
        public decimal Temperatura { get; private set; }
        public decimal Presion { get; private set; }
        public decimal Humedad { get; private set; }

        public event EventHandler<Oddfellow> HaCambiadoElTiempo;

        public void AumentarLaTemperaturaEnGrados(int grados)
        {
            Temperatura += grados;

            Notificar();
        }

        public void AumentarLaPresionEnBares(int bares)
        {
            Presion += bares;

            Notificar();
        }

        public void AumentarLaHumedadEnPorcentaje(int porcentaje)
        {
            Humedad += porcentaje;

            Notificar();
        }

        public void Notificar()
        {
            var medidas = new Oddfellow(Temperatura, Humedad, Presion);

            if (HaCambiadoElTiempo != null)
                HaCambiadoElTiempo.Invoke(this, medidas);
        }

        public EstacionMetereologica()
        {
        }
    }
}