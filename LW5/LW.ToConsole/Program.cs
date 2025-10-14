using LW5;

namespace LW5.ToConsole
{
    public class Program
    {
        public static void Task1()
        {
            Console.WriteLine("=== Starting Task 1 ===");

            // demonstrating work of MyMatrix.cs for 1st task
            int rows = 10;
            int cols = 5;

            // using constructor
            Console.WriteLine("--- Creating matrix ---\n");
            MyMatrix newMatrix = new MyMatrix(rows, cols);

            // demonstrating new matrix
            Console.WriteLine("\nYour matrix: ");
            newMatrix.Show();

            // Fill w new values and show it
            Console.WriteLine("--- Refilling your matrix ---\n");
            newMatrix.Fill();
            Console.WriteLine("\nYour matrix: ");
            newMatrix.Show();

            // resizing to 10x10
            Console.WriteLine("--- Resizing matrix ---\n");
            newMatrix.ChangeSize();
            Console.WriteLine("\nYour matrix: ");
            newMatrix.Show();

            // resizing to 5x10
            Console.WriteLine("--- Resizing matrix ---\n");
            newMatrix.ChangeSize();
            Console.WriteLine("\nYour matrix: ");
            newMatrix.Show();

            // partial output
            Console.WriteLine("--- Partial Show (range) ---\n");
            newMatrix.ShowPartialy(2, 5, 4, 8);

            Console.WriteLine();
            Console.WriteLine("End of 1st task. Press any key to start 2nd task...");
            Console.ReadKey();
            Console.Clear();
        }

        public static void Task2() 
        {
            Console.WriteLine("=== Starting Task 2 ===");

            // demonstrating work of 2nd task
            // init
            MyList<int> myList = new MyList<int>();

            // adding 
            Console.WriteLine("Please, enter count of values: ");
            int n = Console.ReadLine().;
        }

        static void Main()
        {
            Task1();
        }
    }
}