using NUnit.Framework;
using ServerWPFApplication.Model;

namespace TestsServerWPFApplication.Model
{
    [TestFixture]
    public class TestsOddfellow
    {
        private Oddfellow oddfellow;

        [SetUp]
        public void Init()
        {
            oddfellow = new Oddfellow(10, 820, 85);
        }

        [Test(Description = "Test to check that constructor returns an object correctly built.")]
        public void TestConstructorAreNotNull()
        {
            Assert.AreNotEqual(null, oddfellow);
        }
    }
}