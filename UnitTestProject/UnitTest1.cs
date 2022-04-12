using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        //[SetUp]
        //public void Setup()
        //{
        //}

        [TestMethod]
        public void ValidateInput(string name)
        {
            Assert.Equals("Noncedo", name);
        }
    }
}