using NUnit.Framework;
using ServerWPFApplication.Model;

namespace TestsServerWPFApplication.Model
{
    [TestFixture]
    public class TestWindFarm
    {
        private WindFarm windFarm;

        [SetUp]
        public void Init()
        {
            windFarm = new WindFarm("theWindName");
        }

        [Test(Description = "Test to check that constructor returns an object correctly built.")]
        public void TestConstructorAreNotNull()
        {
            Assert.AreNotEqual(null, windFarm);
        }
    }
}
