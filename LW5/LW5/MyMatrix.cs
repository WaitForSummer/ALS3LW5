namespace LW5
{
    public class Matrix
    {
        // init fields
        private int rows, columns;
        private double[,] matrix;

        // constructor
        public Matrix(int m, int n)
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

            Console.WriteLine("Enter minimal value: ");
            double minValue = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter maximal value: ");
            double maxValue = Convert.ToDouble(Console.ReadLine());

            // fill matrix with random values
            Random rand = new Random();
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < columns; j++)
                    matrix[i, j] = rand.NextDouble() * (maxValue - minValue) + minValue;
        }

        // method to fill matrix with random values
        public void Fill(double min, double max)
        {
            Random rand = new Random();
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < columns; j++)
                    matrix[i, j] = rand.NextDouble() * (max - min) + min;
        }

        public void ChangeSize()
        {
            // init new size valuef
            Console.WriteLine("Enter new value for rows: ");
            int newRows = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter new value for columns: ");
            int newColumns = Convert.ToInt32(Console.ReadLine());

            // validate input
            if (newRows <= 0 || newColumns <= 0) 
            {
                throw new ArgumentException("Matrix dimensions must be positive integers.");
            }

            // copy
            int corRows = Math.Min(rows, newRows);
            int corColumns = Math.Min(columns, newColumns);

            for (int i = 0; i < corRows; i++)
                for (int j = 0; j < corColumns; j++)
                    matrix[i, j] = matrix[i, j];

            // fill is new size is bigger

        }
    }
}
