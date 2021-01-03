using NUnit.Framework;
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
    }
}
