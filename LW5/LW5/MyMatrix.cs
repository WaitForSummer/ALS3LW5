namespace LW5
{
    public class MyMatrix
    {
        // init fields
        private int rows, columns;
        private double[,] matrix;
        private Random random;

        // helping method
        public void FillFields(double minV, double maxV)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    matrix[i, j] = random.NextDouble() * (maxV - minV) + minV;
                }
            }
        }

        // constructor
        public MyMatrix(int m, int n, double minV = 0, double maxV = 100)
        {
            // validate input
            if (m <= 0 || n <= 0)
            {
                throw new ArgumentException("Matrix dimensions must be positive integers.");
            }

            // init
            rows = m;
            columns = n;
            matrix = new double[rows, columns];
            random = new Random();

            Console.WriteLine("Enter minimal value: ");
            double minValue = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter maximal value: ");
            double maxValue = Convert.ToDouble(Console.ReadLine());

            // fill matrix with random values
            FillFields(minValue, maxValue);
        }

        // method to fill matrix with random values
        public void Fill()
        {
            Console.WriteLine("Enter minimal value: ");
            double min = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter maximal value: ");
            double max = Convert.ToDouble(Console.ReadLine());
            
            FillFields(min, max);
        }

        // method to resize matrix
        public void ChangeSize()
        {
            // init new size value
            Console.WriteLine("Enter new value for rows: ");
            int newRows = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter new value for columns: ");
            int newColumns = Convert.ToInt32(Console.ReadLine());

            // validation
            if (newRows <= 0 || newColumns <= 0)
                throw new ArgumentException("New values must be greater than 0");

            double[, ] newMatrix = new double[newRows, newColumns];
            Random random = new Random();

            // copy
            int corRows = Math.Min(rows, newRows);
            int corColumns = Math.Min(columns, newColumns);

            for (int i = 0; i < corRows; i++)
                for (int j = 0; j < corColumns; j++)
                    newMatrix[i, j] = matrix[i, j];

            // fill is new size is bigger
            for (int i = 0; i < newRows; i++)
            {
                for (int j = 0; j < newColumns; j++)
                {
                    if (i >= rows || j >= columns)
                    {
                        double min = matrix[0, 0];
                        double max = matrix[0, 0];

                        // find minmax
                        for (int k = 0; k < rows; k++)
                        {
                            for (int z = 0; z < columns; z++)
                            {
                                if (matrix[k, z] < min) { min = matrix[k, z]; }
                                if (matrix[k, z] > max) { max = matrix[k, z]; }
                            }
                        }

                        newMatrix[i, j] = random.NextDouble() * (max - min) + min;
                    }
                }
            }

            // reinit
            matrix = newMatrix;
            rows = newRows;
            columns = newColumns;
        }

        // method to print range
        public void ShowPartialy(int startRow, int startColumn, int endRow, int endColumn)
        {
            // validation
            if (startRow < 0 || startColumn < 0 || endColumn > columns || endRow >= rows || startColumn > endColumn || startRow > endRow)
            {
                throw new ArgumentException("Invalid range params");
            }

            // output
            Console.WriteLine($"View of matrix [{startRow + 1}:{endRow + 1}, {startColumn + 1}:{endColumn + 1}]:");
            for (int i = startRow; i <= endRow; i++)
            {
                for (int j = startColumn; j <= endColumn; j++)
                    Console.Write($"{matrix[i, j]:F2}\t");
                Console.WriteLine();
            }
        }
        
        // ouput full matrix
        public void Show()
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                    Console.Write($"{matrix[i, j]:F2}\t");

                Console.WriteLine();
            }
            Console.WriteLine();
        }

        // indexator
        public double this[int row, int column]
        {
            get
            {
                // validation
                if (row < 0 || column < 0 || row > rows || column > columns)
                    throw new IndexOutOfRangeException("Matrix index out of range");

                return matrix[row, column];
            }
            set
            {
                // validation
                if (row < 0 || column < 0 || row > rows || column > columns)
                    throw new IndexOutOfRangeException("Matrix index out of range");

                matrix[row, column] = value;
            }
        }

        // properties for sizes
        public int Rows => rows;
        public int Columns => columns;
    }
}
