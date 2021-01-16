namespace ServerWPFApplication.Model
{
    public class Oddfellow
    {
        public decimal Temperature { get; private set; }
        public decimal Pressure { get; private set; }
        public decimal Humidity { get; private set; }


        public Oddfellow(decimal temperature, decimal pressure, decimal humedity)
        {
            Temperature = temperature;
            Pressure = pressure;
            Humidity = humedity;
        }
    }
}
