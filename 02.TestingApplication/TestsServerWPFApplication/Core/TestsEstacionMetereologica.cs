using NUnit.Framework;
using ServerWPFApplication.Core;
using ServerWPFApplication.Model;
using System.Collections.Generic;

namespace TestsServerWPFApplication.Core
{
    [TestFixture]
    class TestsEstacionMetereologica
    {
        private WeatherStation weatherStation;

        [SetUp]
        public void Init()
        {
            weatherStation = new WeatherStation();
        }

        [Test(Description = "Test to check that constructor returns an object correctly built.")]
        public void TestConstructorAreNotNull()
        {
            Assert.AreNotEqual(null, weatherStation);
        }

        [Test(Description = "Test increase the temperature.")]
        public void TestAumentarTemperatura()
        {
            Assert.AreEqual(20, weatherStation.Temperature);

            weatherStation.IncreaseTheTemperatureInDegrees(1);
            Assert.AreEqual(21, weatherStation.Temperature);

            weatherStation.IncreaseTheTemperatureInDegrees(2);
            Assert.AreEqual(23, weatherStation.Temperature);
        }

        [Test(Description = "Test lower the temperature.")]
        public void TestDisminuirTemperatura()
        {
            Assert.AreEqual(20, weatherStation.Temperature);

            weatherStation.DecreaseTheTemperatureInDegrees(1);
            Assert.AreEqual(19, weatherStation.Temperature);

            weatherStation.DecreaseTheTemperatureInDegrees(23);
            Assert.AreEqual(-4, weatherStation.Temperature);
        }

        [Test(Description = "Test increase pressure.")]
        public void TestAumentarPresion()
        {
            Assert.AreEqual(100, weatherStation.Pressure);

            weatherStation.IncreaseThePreasureInBar(1);
            Assert.AreEqual(101, weatherStation.Pressure);

            weatherStation.IncreaseThePreasureInBar(10);
            Assert.AreEqual(111, weatherStation.Pressure);
        }

        [Test(Description = "Test decrease pressure.")]
        public void TestDisminuirPresion()
        {
            Assert.AreEqual(100, weatherStation.Pressure);

            weatherStation.DecreaseThePreasureInBar(1);
            Assert.AreEqual(99, weatherStation.Pressure);

            weatherStation.DecreaseThePreasureInBar(20);
            Assert.AreEqual(79, weatherStation.Pressure);
        }

        [Test(Description = "Test increase humidity.")]
        public void TestAumentarHumedad()
        {
            Assert.AreEqual(50, weatherStation.Humidity);

            weatherStation.IncreaseHumidityInPercentage(1);
            Assert.AreEqual(51, weatherStation.Humidity);

            weatherStation.IncreaseHumidityInPercentage(10);
            Assert.AreEqual(61, weatherStation.Humidity);
        }

        [Test(Description = "Test reduce humidity.")]
        public void TestDisminuirHumedad()
        {
            Assert.AreEqual(50, weatherStation.Humidity);

            weatherStation.DecreaseHumidityInPercentage(1);
            Assert.AreEqual(49, weatherStation.Humidity);

            weatherStation.DecreaseHumidityInPercentage(20);
            Assert.AreEqual(29, weatherStation.Humidity);
        }

        [Test(Description = "The weather has changed.")]
        public void TestHaCambiadoElTiempo()
        {
            List<Oddfellow> receivedEvents = new List<Oddfellow>();


            weatherStation.TimeHasChanged += delegate (object sender, Oddfellow e)
            {
                receivedEvents.Add(e);
            };
            
            Assert.AreEqual(20, weatherStation.Temperature);
            weatherStation.IncreaseTheTemperatureInDegrees(10);
            Assert.AreEqual(30, receivedEvents[0].Temperature);
             

            weatherStation.IncreaseHumidityInPercentage(10);

            Assert.AreEqual(2, receivedEvents.Count);
            
            Assert.AreEqual(30, weatherStation.Temperature);
        }
    }
}
