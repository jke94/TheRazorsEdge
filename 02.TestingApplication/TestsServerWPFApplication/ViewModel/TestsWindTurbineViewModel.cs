using NUnit.Framework;
using ServerWPFApplication.Model;
using ServerWPFApplication.ViewModel;

namespace TestsServerWPFApplication.ViewModel
{
    [TestFixture]
    class TestsWindTurbineViewModel
    {
        private WindTurbineViewModel windTurbineViewModel;

        [SetUp]
        public void Init()
        {
            windTurbineViewModel = new WindTurbineViewModel();
        }

        [Test(Description = "Test to check that constructor returns an object correctly built.")]
        public void TestConstructorAreNotNull()
        {
            Assert.AreNotEqual(null, windTurbineViewModel);
        }

        [Test(Description = "Test to check that constructor returns an object correctly built.")]
        public void TestConstructorWithParameters()
        {
            WindTurbine windTurbine = new WindTurbine(2, "theWindTurbineName");

            windTurbineViewModel = new WindTurbineViewModel(windTurbine);

            Assert.IsNotNull(windTurbineViewModel);

            Assert.IsNotNull(windTurbineViewModel.EstacionMetereologica);;

            Assert.IsNotNull(windTurbineViewModel.Tasks);

            Assert.IsNotNull(windTurbineViewModel.TextMessageHumedad);
            Assert.IsNotNull(windTurbineViewModel.TextMessageTemperatura);
            Assert.IsNotNull(windTurbineViewModel.TextMessagePresion);
        }
    }
}
