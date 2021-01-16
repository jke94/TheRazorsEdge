using NUnit.Framework;
using Shared;

namespace TestsShared
{
    [TestFixture]
    public class TestsNamedPipeNameBuilder
    {
        private  NamedPipeNameBuilder namedPipeNameBuilder;

        [SetUp]
        public void Init()
        {
            namedPipeNameBuilder = new NamedPipeNameBuilder("SensorName", "theObject", 10);
        }

        [Test(Description = "Test to check that constructor returns an object correctly built.")]
        public void TestConstructorAreNotNull()
        {
            Assert.AreNotEqual(null, namedPipeNameBuilder);
        }

        [Test(Description = "Test to check ToString overrided method.")]
        public void TestToStringMethod()
        {
            Assert.AreEqual("SensorNametheObject10", namedPipeNameBuilder.ToString());
        }
    }
}