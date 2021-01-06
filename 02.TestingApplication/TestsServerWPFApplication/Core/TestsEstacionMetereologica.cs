using NUnit.Framework;
using ServerWPFApplication.Core;
using ServerWPFApplication.Model;
using System.Collections.Generic;

namespace TestsServerWPFApplication.Core
{
    [TestFixture]
    class TestsEstacionMetereologica
    {
        private EstacionMetereologica estacionMetereologica;

        [SetUp]
        public void Init()
        {
            estacionMetereologica = new EstacionMetereologica();
        }

        [Test(Description = "Test to check that constructor returns an object correctly built.")]
        public void TestConstructorAreNotNull()
        {
            Assert.AreNotEqual(null, estacionMetereologica);
        }

        [Test(Description = "Test aumentar la temperatura.")]
        public void TestAumentarTemperatura()
        {
            Assert.AreEqual(20, estacionMetereologica.Temperatura);

            estacionMetereologica.AumentarLaTemperaturaEnGrados(1);
            Assert.AreEqual(21, estacionMetereologica.Temperatura);

            estacionMetereologica.AumentarLaTemperaturaEnGrados(2);
            Assert.AreEqual(23, estacionMetereologica.Temperatura);
        }

        [Test(Description = "Test disminuir la temperatura.")]
        public void TestDisminuirTemperatura()
        {
            Assert.AreEqual(20, estacionMetereologica.Temperatura);

            estacionMetereologica.DisminuirLaTemperaturaEnGrados(1);
            Assert.AreEqual(19, estacionMetereologica.Temperatura);

            estacionMetereologica.DisminuirLaTemperaturaEnGrados(23);
            Assert.AreEqual(-4, estacionMetereologica.Temperatura);
        }

        [Test(Description = "Test aumentar la presion.")]
        public void TestAumentarPresion()
        {
            Assert.AreEqual(100, estacionMetereologica.Presion);

            estacionMetereologica.AumentarLaPresionEnBares(1);
            Assert.AreEqual(101, estacionMetereologica.Presion);

            estacionMetereologica.AumentarLaPresionEnBares(10);
            Assert.AreEqual(111, estacionMetereologica.Presion);
        }

        [Test(Description = "Test disminuir la presion.")]
        public void TestDisminuirPresion()
        {
            Assert.AreEqual(100, estacionMetereologica.Presion);

            estacionMetereologica.DisminuirLaPresionEnBares(1);
            Assert.AreEqual(99, estacionMetereologica.Presion);

            estacionMetereologica.DisminuirLaPresionEnBares(20);
            Assert.AreEqual(79, estacionMetereologica.Presion);
        }

        [Test(Description = "Test aumentar la humedad.")]
        public void TestAumentarHumedad()
        {
            Assert.AreEqual(50, estacionMetereologica.Humedad);

            estacionMetereologica.AumentarLaHumedadEnPorcentaje(1);
            Assert.AreEqual(51, estacionMetereologica.Humedad);

            estacionMetereologica.AumentarLaHumedadEnPorcentaje(10);
            Assert.AreEqual(61, estacionMetereologica.Humedad);
        }

        [Test(Description = "Test disminuir la humedad.")]
        public void TestDisminuirHumedad()
        {
            Assert.AreEqual(50, estacionMetereologica.Humedad);

            estacionMetereologica.DisminuirLaHumedadEnPorcentaje(1);
            Assert.AreEqual(49, estacionMetereologica.Humedad);

            estacionMetereologica.DisminuirLaHumedadEnPorcentaje(20);
            Assert.AreEqual(29, estacionMetereologica.Humedad);
        }

        [Test(Description = "Ha cambiado el tiempo.")]
        public void TestHaCambiadoElTiempo()
        {
            List<Oddfellow> receivedEvents = new List<Oddfellow>();


            estacionMetereologica.HaCambiadoElTiempo += delegate (object sender, Oddfellow e)
            {
                receivedEvents.Add(e);
            };
            
            Assert.AreEqual(20, estacionMetereologica.Temperatura);
            estacionMetereologica.AumentarLaTemperaturaEnGrados(10);
            Assert.AreEqual(30, receivedEvents[0].Temperatura);
             

            estacionMetereologica.AumentarLaHumedadEnPorcentaje(10);

            Assert.AreEqual(2, receivedEvents.Count);
            
            Assert.AreEqual(30, estacionMetereologica.Temperatura);
        }
    }
}
