using NUnit.Framework;
using UAS_PAW_2;

namespace UAS_No2_Test
{
    [TestFixture()]
    public class Tests
    {
        Kasir cash = new Kasir();

        [SetUp]
        public void Setup()
        {
            Kasir cash = new Kasir();
        }

        [Test]
        public void Test1()
        {
            Assert.IsNotNull(cash);
            Assert.Pass();
        }
    }
}