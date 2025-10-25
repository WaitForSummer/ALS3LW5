using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Transactions;

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

        // testing indexer
        [TestMethod]
        public void Indexer_GetValidIndex_Return()
        {
            MyMatrix matrix = new MyMatrix(2, 2, 5, 5);

            double value = matrix[0, 0];

            Assert.IsTrue(value >= 5 && value <= 5);
        }

        [TestMethod]
        public void Indexer_SetValidIndexer_Update()
        {
            MyMatrix matrix = new MyMatrix(2, 2, 1, 10);

            matrix[1, 1] = 99.99;
            double result = matrix[1, 1];

            Assert.AreEqual(99.99, result, 0.001);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void Indexer_GetInvalidRow_ThrowsIOoRException()
        {
            MyMatrix matrix = new MyMatrix(2, 2, 1, 10);

            double value = matrix[5, 0];
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void Indexer_SetInvalidColumn_ThrowsIOoRException()
        {
            MyMatrix matrix = new MyMatrix(2, 2, 1, 10);

            matrix[0, -1] = 100;
        }

        // testing method FillFields
        [TestMethod]
        public void FillFields_WParams_UpdatesValues()
        {
            MyMatrix matrix = new MyMatrix(2, 2, 1, 10);

            matrix.FillFields(50, 60);

            for (int i = 0; i < matrix.Rows; i++)
            {
                for (int j = 0; j < matrix.Columns; j++)
                {
                    Assert.IsTrue(matrix[i, j] >= 50 && matrix[i, j] <= 60);
                }
            }
        }

        // testing changesize
        [TestMethod]
        public void ChangeSize_MoreSize()
        {
            MyMatrix matrix = new MyMatrix(2, 2, 1, 10);
            double originValue = matrix[0, 0];

            matrix.ChangeSize(3, 3, 20, 30);

            Assert.AreEqual(3, matrix.Rows);
            Assert.AreEqual(3, matrix.Columns);
            Assert.AreEqual(originValue, matrix[0, 0], 0.001); 
        }

        [TestMethod]
        public void ChangeSize_Shrink()
        {
            MyMatrix matrix = new MyMatrix(3, 3, 1, 10);
            double expected = matrix[0, 0];

            matrix.ChangeSize(2, 2, 20, 30);

            Assert.AreEqual(2, matrix.Rows);
            Assert.AreEqual(2, matrix.Columns);
            Assert.AreEqual(expected, matrix[0, 0], 0.001);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ChangeSize_Invalid_ThrowsAE()
        {
            MyMatrix matrix = new MyMatrix(2, 2, 1, 10);

            matrix.ChangeSize(0, 5, 1, 10);
        }

        // testing Showpartial
        [TestMethod]
        public void ShowPartialy_ValidRange_Correct()
        {
            MyMatrix matrix = new MyMatrix(4, 4, 1, 100);
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);

            matrix.ShowPartialy(1, 3, 0, 2);

            string output = writer.ToString();
            Assert.IsFalse(string.IsNullOrEmpty(output));

            StreamWriter standartUptput = new StreamWriter(Console.OpenStandardOutput());
            Console.SetOut(standartUptput);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ShowPartialy_InvalidRange()
        {
            MyMatrix matrix = new MyMatrix(3, 3, 1, 10);

            matrix.ShowPartialy(2, 5, 0, 2);
        }
    }
}
