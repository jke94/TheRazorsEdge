using ClientConsoleSimulator;
using NUnit.Framework;
using System.Threading.Tasks;

namespace TestsClientConsoleSimulator
{
    public class TestsWindTurbineSimulator
    {
        private WindTurbineSimulator windTurbineSimulator;

        [SetUp]
        public void Init()
        {
            windTurbineSimulator = new WindTurbineSimulator(3);
        }

        [Test(Description = "Test to check that constructor returns an object correctly built.")]
        public void TestConstructorAreNotNull()
        {
            Assert.AreNotEqual(null, windTurbineSimulator);
        }
    }
}