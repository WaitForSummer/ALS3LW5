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

            // demonstrating work of MyList<T>

            // Test 1: Basic functionality
            Console.WriteLine("--- Basic MyList functionality ---");
            MyList<int> myList = new MyList<int>();

            // Adding elements
            Console.WriteLine("Adding elements: 10, 20, 30, 40, 50");
            myList.Add(10);
            myList.Add(20);
            myList.Add(30);
            myList.Add(40);
            myList.Add(50);

            Console.WriteLine($"Count: {myList.Count}");
            Console.WriteLine($"Capacity: {myList.Capacity}");

            // Accessing elements by index
            Console.WriteLine("\nAccessing elements by index:");
            for (int i = 0; i < myList.Count; i++)
            {
                Console.WriteLine($"myList[{i}] = {myList[i]}");
            }

            // Collection initializer
            Console.WriteLine("\n--- Collection initializer ---");
            MyList<string> stringList = new MyList<string>
            {
                "Hello",
                "World",
                "C#",
                "Programming"
            };

            Console.WriteLine($"String list count: {stringList.Count}");
            for (int i = 0; i < stringList.Count; i++)
            {
                Console.WriteLine($"stringList[{i}] = {stringList[i]}");
            }

            // Indexer setter
            Console.WriteLine("\n--- Indexer setter ---");
            Console.WriteLine($"Before: myList[2] = {myList[2]}");
            myList[2] = 100;
            Console.WriteLine($"After: myList[2] = {myList[2]}");

            // Additional methods
            Console.WriteLine("\n--- Additional methods ---");
            Console.WriteLine($"Contains 30: {myList.Contains(30)}");
            Console.WriteLine($"Contains 100: {myList.Contains(100)}");
            Console.WriteLine($"Index of 40: {myList.IndexOf(40)}");

            Console.WriteLine("Removing element 40...");
            myList.Remove(40);
            Console.WriteLine($"Count after removal: {myList.Count}");

            Console.WriteLine("Elements after removal:");
            foreach (var item in myList)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();

            // AddRange
            Console.WriteLine("\n--- AddRange ---");
            MyList<int> rangeList = new MyList<int>();
            int[] numbers = { 1, 2, 3, 4, 5 };
            rangeList.AddRange(numbers);
            Console.WriteLine($"Range list count: {rangeList.Count}");
            foreach (var item in rangeList)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();

            Console.WriteLine("\nEnd of 2nd task. Press any key to start 3rd task...");
            Console.ReadKey();
            Console.Clear();
        }

        public static void Task3()
        {
            Console.WriteLine("=== Starting Task 3 ===");

            try
            {
                Console.WriteLine("--- Simple MyDictionary Test ---");
                MyDictionary<string, int> dict = new MyDictionary<string, int>();

                Console.WriteLine("--- Basic addition ---");
                dict.Add("one", 1);
                dict.Add("two", 2);
                dict.Add("three", 3);

                Console.WriteLine($"Count: {dict.Count}");
                Console.WriteLine($"dict[\"one\"] = {dict["one"]}");
                Console.WriteLine($"dict[\"two\"] = {dict["two"]}");

                Console.WriteLine("\n--- Update via indexer ---");
                Console.WriteLine($"Before update - dict[\"two\"] = {dict["two"]}");
                dict["two"] = 22;
                Console.WriteLine($"After update - dict[\"two\"] = {dict["two"]}");

                Console.WriteLine("\n--- Add via indexer ---");
                dict["four"] = 4;
                Console.WriteLine($"dict[\"four\"] = {dict["four"]}");
                Console.WriteLine($"Count after adding 'four': {dict.Count}");

                Console.WriteLine("\n--- Foreach iteration ---");
                int itemCount = 0;
                foreach (var pair in dict)
                {
                    Console.WriteLine($"  Key: '{pair.Key}', Value: {pair.Value}");
                    itemCount++;
                }
                Console.WriteLine($"Total items: {itemCount}");

                Console.WriteLine("\n--- Testing resize ---");
                dict.Add("five", 5);
                dict.Add("six", 6);
                dict.Add("seven", 7);
                dict.Add("eight", 8);

                Console.WriteLine($"Count after adding more: {dict.Count}");
                Console.WriteLine("All items after resize:");
                foreach (var pair in dict)
                {
                    Console.WriteLine($"  Key: '{pair.Key}', Value: {pair.Value}");
                }

                Console.WriteLine("\n--- Access after resize ---");
                Console.WriteLine($"dict[\"one\"] after resize = {dict["one"]}");
                Console.WriteLine($"dict[\"seven\"] = {dict["seven"]}");

                Console.WriteLine("\n✓ All basic tests passed!");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"✗ Error: {ex.Message}");
                Console.WriteLine($"Stack trace: {ex.StackTrace}");

                if (ex.InnerException != null)
                {
                    Console.WriteLine($"Inner exception: {ex.InnerException.Message}");
                }
            }

            Console.WriteLine("\nEnd of 3rd task. Press any key to exit...");
            Console.ReadKey();
        }

        static void Main()
        {
            Task1();
            Task2();
            Task3();

            Console.WriteLine("\n=== All tasks completed! ===");
        }
    }
}