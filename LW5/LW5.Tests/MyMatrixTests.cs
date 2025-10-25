using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LW5.Tests
{
    [TestClass]
    public class MyMatrixTests
    {
        // testing constructor
        [TestMethod]
        public void TestConstructor_IsValid()
        {
            MyMatrix matrix = new MyMatrix(3, 4, 1, 10);

            Assert.AreEqual(3, matrix.Rows);
            Assert.AreEqual(4, matrix.Columns);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestConstructor_ZeroRows_Invalid() 
        {
            MyMatrix matrix = new MyMatrix(0, 5, 1, 10);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestConstructor_WithNegativesParams_Invalid()
        {
            MyMatrix matrix = new MyMatrix(3, -2, 1, 10);
        }


    }
}
