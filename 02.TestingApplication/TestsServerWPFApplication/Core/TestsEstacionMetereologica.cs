using NUnit.Framework;
using ServerWPFApplication.Core;
using ServerWPFApplication.Model;
using System.Collections.Generic;

namespace TestsServerWPFApplication.Core
{
    [TestFixture]
    class TestsEstacionMetereologica
    {
        private WeatherStation estacionMetereologica;

        [SetUp]
        public void Init()
        {
            estacionMetereologica = new WeatherStation();
        }

        [Test(Description = "Test to check that constructor returns an object correctly built.")]
        public void TestConstructorAreNotNull()
        {
            Assert.AreNotEqual(null, estacionMetereologica);
        }

        [Test(Description = "Test aumentar la temperatura.")]
        public void TestAumentarTemperatura()
        {
            Assert.AreEqual(20, estacionMetereologica.Temperature);

            estacionMetereologica.IncreaseTheTemperatureInDegrees(1);
            Assert.AreEqual(21, estacionMetereologica.Temperature);

            estacionMetereologica.IncreaseTheTemperatureInDegrees(2);
            Assert.AreEqual(23, estacionMetereologica.Temperature);
        }

        [Test(Description = "Test disminuir la temperatura.")]
        public void TestDisminuirTemperatura()
        {
            Assert.AreEqual(20, estacionMetereologica.Temperature);

            estacionMetereologica.DecreaseTheTemperatureInDegrees(1);
            Assert.AreEqual(19, estacionMetereologica.Temperature);

            estacionMetereologica.DecreaseTheTemperatureInDegrees(23);
            Assert.AreEqual(-4, estacionMetereologica.Temperature);
        }

        [Test(Description = "Test aumentar la presion.")]
        public void TestAumentarPresion()
        {
            Assert.AreEqual(100, estacionMetereologica.Pressure);

            estacionMetereologica.IncreaseThePreasureInBar(1);
            Assert.AreEqual(101, estacionMetereologica.Pressure);

            estacionMetereologica.IncreaseThePreasureInBar(10);
            Assert.AreEqual(111, estacionMetereologica.Pressure);
        }

        [Test(Description = "Test disminuir la presion.")]
        public void TestDisminuirPresion()
        {
            Assert.AreEqual(100, estacionMetereologica.Pressure);

            estacionMetereologica.DecreaseThePreasureInBar(1);
            Assert.AreEqual(99, estacionMetereologica.Pressure);

            estacionMetereologica.DecreaseThePreasureInBar(20);
            Assert.AreEqual(79, estacionMetereologica.Pressure);
        }

        [Test(Description = "Test aumentar la humedad.")]
        public void TestAumentarHumedad()
        {
            Assert.AreEqual(50, estacionMetereologica.Humidity);

            estacionMetereologica.IncreaseHumidityInPercentage(1);
            Assert.AreEqual(51, estacionMetereologica.Humidity);

            estacionMetereologica.IncreaseHumidityInPercentage(10);
            Assert.AreEqual(61, estacionMetereologica.Humidity);
        }

        [Test(Description = "Test disminuir la humedad.")]
        public void TestDisminuirHumedad()
        {
            Assert.AreEqual(50, estacionMetereologica.Humidity);

            estacionMetereologica.DecreaseHumidityInPercentage(1);
            Assert.AreEqual(49, estacionMetereologica.Humidity);

            estacionMetereologica.DecreaseHumidityInPercentage(20);
            Assert.AreEqual(29, estacionMetereologica.Humidity);
        }

        [Test(Description = "Ha cambiado el tiempo.")]
        public void TestHaCambiadoElTiempo()
        {
            List<Oddfellow> receivedEvents = new List<Oddfellow>();


            estacionMetereologica.TimeHasChanged += delegate (object sender, Oddfellow e)
            {
                receivedEvents.Add(e);
            };
            
            Assert.AreEqual(20, estacionMetereologica.Temperature);
            estacionMetereologica.IncreaseTheTemperatureInDegrees(10);
            Assert.AreEqual(30, receivedEvents[0].Temperature);
             

            estacionMetereologica.IncreaseHumidityInPercentage(10);

            Assert.AreEqual(2, receivedEvents.Count);
            
            Assert.AreEqual(30, estacionMetereologica.Temperature);
        }
    }
}
