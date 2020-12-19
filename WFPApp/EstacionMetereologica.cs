using System;

namespace WFPApp
{
    public class EstacionMetereologica
    {
        public decimal Temperatura { get; private set; }
        public decimal Presion { get; private set; }
        public decimal Humedad { get; private set; }

        public string TextAux = "30 ºC";

        public event EventHandler<Tuple<decimal, decimal, decimal>> HaCambiadoElTiempo;

        public void AumentarLaTemperaturaEnGrados(int grados)
        {
            Temperatura = grados + 1;

            Notificar();
        }

        public void Notificar()
        {
            var medidas = new Tuple<decimal, decimal, decimal>(Temperatura, Humedad, Presion);

            if (HaCambiadoElTiempo != null)
                HaCambiadoElTiempo.Invoke(this, medidas);
        }
    }
}