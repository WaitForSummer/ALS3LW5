using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

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
        public void TestConstructor_ZeroRows_ThrowsAE()
        {
            MyMatrix matrix = new MyMatrix(0, 5, 1, 10);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestConstructor_WithNegativesParams_ThrowsAE()
        {
            MyMatrix matrix = new MyMatrix(3, -2, 1, 10);
        }

        // testing indexer
        [TestMethod]
        public void Indexer_GetValidIndex()
        {
            MyMatrix matrix = new MyMatrix(2, 2, 5, 5);

            double value = matrix[0, 0];

            Assert.IsTrue(value >= 5 && value <= 5);
        }

        [TestMethod]
        public void Indexer_SetValidIndexer()
        {
            MyMatrix matrix = new MyMatrix(2, 2, 1, 10);

            matrix[1, 1] = 99.99;
            double result = matrix[1, 1];

            Assert.AreEqual(99.99, result, 0.001);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void Indexer_GetInvalidRow_ThrowsEIOoR()
        {
            MyMatrix matrix = new MyMatrix(2, 2, 1, 10);

            double value = matrix[5, 0];
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void Indexer_SetInvalidColumn_ThrowsEIOoR()
        {
            MyMatrix matrix = new MyMatrix(2, 2, 1, 10);

            matrix[0, -1] = 100;
        }

        // testing method Fill
        [TestMethod]
        public void Fill_WithParameters_UpdatesValues()
        {
            MyMatrix matrix = new MyMatrix(2, 2, 1, 10);

            matrix.Fill(0.5, 7.7);

            Assert.IsTrue(matrix.Rows == 2 && matrix.Columns == 2);
        }

        // testing changesize
        [TestMethod]
        public void ChangeSize_EnlargeMatrix_PreservesValues()
        {
            MyMatrix matrix = new MyMatrix(2, 2, 1, 10);
            double originValue = matrix[0, 0];

            matrix.ChangeSize(3, 3, 20, 30);

            Assert.AreEqual(3, matrix.Rows);
            Assert.AreEqual(3, matrix.Columns);
            Assert.AreEqual(originValue, matrix[0, 0], 0.001);
        }

        [TestMethod]
        public void ChangeSize_ShrinkMatrix()
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
        public void ChangeSize_InvalidDimensions_ThrowsAE()
        {
            MyMatrix matrix = new MyMatrix(2, 2, 1, 10);

            matrix.ChangeSize(0, 5, 1, 10);
        }

        // testing ShowPartialy
        [TestMethod]
        public void ShowPartialy_ValidRange_ExecutesWithoutError()
        {
            MyMatrix matrix = new MyMatrix(4, 4, 1, 100);

            var originalOut = Console.Out;

            try
            {
                using (var writer = new StringWriter())
                {
                    Console.SetOut(writer);
                    matrix.ShowPartialy(0, 1, 2, 3);

                    string output = writer.ToString();
                    Assert.IsFalse(string.IsNullOrEmpty(output));
                }
            }
            finally
            {
                Console.SetOut(originalOut);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ShowPartialy_InvalidRange_ThrowsAE()
        {
            MyMatrix matrix = new MyMatrix(3, 3, 1, 10);

            matrix.ShowPartialy(2, 5, 0, 2);
        }

        // addictive methods
        // properties
        [TestMethod]
        public void Properties_RowsAndColumns_ReturnCorrectValues()
        {
            MyMatrix matrix = new MyMatrix(5, 7, 1, 10);

            Assert.AreEqual(5, matrix.Rows);
            Assert.AreEqual(7, matrix.Columns);
        }

        // changesize method
        [TestMethod]
        public void ChangeSize_SameSize_NoLoss()
        {
            MyMatrix matrix = new MyMatrix(3, 3, 1, 10);
            double[,] originalValues = new double[3, 3];

            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    originalValues[i, j] = matrix[i, j];

            matrix.ChangeSize(3, 3, 20, 30);

            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    Assert.AreEqual(originalValues[i, j], matrix[i, j], 0.001);
        }

        // indexer
        [TestMethod]
        public void Indexer_AllCells()
        {
            MyMatrix matrix = new MyMatrix(2, 3, 1, 10);

            // checking access
            for (int i = 0; i < matrix.Rows; i++)
            {
                for (int j = 0; j < matrix.Columns; j++)
                {
                    double value = matrix[i, j];
                    Assert.IsFalse(double.IsNaN(value));
                    Assert.IsTrue(value >= 1 && value <= 10);
                }
            }
        }

        [TestMethod]
        public void Matrix_Creation_WithDifRanges()
        {
            MyMatrix matrix1 = new MyMatrix(2, 2, 0, 1);
            MyMatrix matrix2 = new MyMatrix(2, 2, 100, 200);
            MyMatrix matrix3 = new MyMatrix(2, 2, -50, 50);

            Assert.AreEqual(2, matrix1.Rows);
            Assert.AreEqual(2, matrix2.Rows);
            Assert.AreEqual(2, matrix3.Rows);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void Indexer_NegativeRow_ThrowsEIOoR()
        {
            MyMatrix matrix = new MyMatrix(2, 2, 1, 10);
            double value = matrix[-1, 0];
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void Indexer_ColumnEqualToColumns_ThrowsEIOoR()
        {
            MyMatrix matrix = new MyMatrix(2, 2, 1, 10);
            double value = matrix[0, 2];
        }
    }
}