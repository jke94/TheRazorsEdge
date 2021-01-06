using NUnit.Framework;
using ServerWPFApplication.Core;

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
    }
}
