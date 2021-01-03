using NUnit.Framework;
using ServerWPFApplication.ViewModel;

namespace TestsServerWPFApplication.ViewModel
{
    [TestFixture]
    public class TestsWindFarmViewModel
    {
        private WindFarmViewModel windFarmViewModel;

        [SetUp]
        public void Init()
        {
            windFarmViewModel = new WindFarmViewModel();
        }

        [Test(Description = "Test to check that constructor returns an object correctly built.")]
        public void TestConstructorAreNotNull()
        {
            Assert.AreNotEqual(null, windFarmViewModel);
        }
    }
}
