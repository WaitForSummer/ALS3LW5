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
        public void Fill()
        {
            Random rand = new Random();
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < columns; j++)
                    matrix[i, j] = rand.NextDouble();
        }

        public void ChangeSize()
        {
            // init new size valuef
            Console.WriteLine("Enter new value for rows: ");
            int newRows = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter new value for columns: ");
            int newColumns = Convert.ToInt32(Console.ReadLine());


        }
    }
}
