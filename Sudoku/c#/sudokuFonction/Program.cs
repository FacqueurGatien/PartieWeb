using System;

namespace sudokuFonction
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<List<int>> array;
            RowSolver test = new RowSolver();
            Console.WriteLine("_____________________________________________________________________________");
            Console.WriteLine(test.ToString());
            test.main();
            Console.WriteLine("_____________________________________________________________________________\n\n");

/*            Console.WriteLine("_____________________________________________________________________________");
            array = new List<List<int>>();
                        array = new List<List<int>>() {
                new List<int>() {8}, new List<int>() { 1, 6, 9 }, new List<int>() { 1, 4, 9 },
                new List<int>() {1,2,5}, new List<int>() { 1,3,5,7 }, new List<int>() { 2, 3, 7 },
                new List<int>() {2,3,4,6,9}, new List<int>() { 4,6,7}, new List<int>() { 2,3,7,9}
            };
            test.EditArray(array);
            Console.WriteLine(test.ToString());
            test.main();
            Console.WriteLine("_____________________________________________________________________________\n\n");

            Console.WriteLine("_____________________________________________________________________________");
            array = new List<List<int>>() {
                            new List<int>() {1}, new List<int>() { 2 }, new List<int>() { 6 },
                            new List<int>() {3,4,5,7,8,9}, new List<int>() { 3,4,5,7,8,9}, new List<int>() {3,4,5,7,8,9},
                            new List<int>() {3,4,5,7,8,9}, new List<int>() { 3,4,5,7,8,9}, new List<int>() { 3, 4, 5, 7, 8, 9 }
                        };
            test.EditArray(array);
            Console.WriteLine(test.ToString());
            test.main();
            Console.WriteLine("_____________________________________________________________________________\n\n");

            Console.WriteLine("_____________________________________________________________________________");
            array = new List<List<int>>() {
                            new List<int>() {7}, new List<int>() { 4 }, new List<int>() { 3 },
                            new List<int>() {1,2,6,8,9}, new List<int>() { 1,2,6,8,9}, new List<int>() { 1,2,6,8,9},
                            new List<int>() {1,2,5,6}, new List<int>() { 1,2,5,6}, new List<int>() { 1, 2, 5, 6 }
                        };
            test.EditArray(array);
            Console.WriteLine(test.ToString());
            test.main();
            Console.WriteLine("_____________________________________________________________________________\n\n");

            Console.WriteLine("_____________________________________________________________________________");
            array = new List<List<int>>() {
                            new List<int>() {9}, new List<int>() { 5 }, new List<int>() { 8 },
                            new List<int>() {1,2,7}, new List<int>() { 1,2,7}, new List<int>() { 1,2,7},
                            new List<int>() {3,4,6}, new List<int>() { 3,4,6}, new List<int>() { 3, 4, 6 }
                        };
            test.EditArray(array);
            Console.WriteLine(test.ToString());
            test.main();
            Console.WriteLine("_____________________________________________________________________________\n\n");*/


            Console.WriteLine("_____________________________________________________________________________");
            array = new List<List<int>>() {
                            new List<int>() {5,8}, new List<int>() {1,9}, new List<int>() {3,4},
                            new List<int>() {1,2}, new List<int>() { 6,9}, new List<int>() { 5,7},
                            new List<int>() {4,6}, new List<int>() { 7,8}, new List<int>() { 2,3}
                        };
            test.EditArray(array);
            Console.WriteLine(test.ToString());
            test.main();
            Console.WriteLine("_____________________________________________________________________________\n\n");
        }
    }
}