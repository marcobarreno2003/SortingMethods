using System;

namespace LinearSearchExample
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 1, 3, 5, 7, 9 };
            int target = 7;

            int result = LinearSearch(arr, target);

            Console.WriteLine(result);
        }

        static int LinearSearch(int[] arr, int target)
        {
            int n = arr.Length;
            for (int i = 0; i < n; i++)
            {
                if (arr[i] == target)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
