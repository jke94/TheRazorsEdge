using NUnit.Framework;
using ServerWPFApplication.Model;

namespace TestsServerWPFApplication.Model
{
    [TestFixture]
    public class TestsWindTurbine
    {
        private WindTurbine windFarm;

        [SetUp]
        public void Init()
        {
            windFarm = new WindTurbine(1, "theWindTurbineName");
        }

        [Test(Description = "Test to check that constructor returns an object correctly built.")]
        public void TestConstructorAreNotNull()
        {
            Assert.AreNotEqual(null, windFarm);
        }

        [Test(Description = "Test to check ToString overrided method.")]
        public void TestToStringMethod()
        {
            Assert.AreEqual("theWindTurbineName - 1", windFarm.ToString());
        }
    }
}
