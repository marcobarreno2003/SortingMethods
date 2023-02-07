using System;

namespace InsertionSortExample
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 5, 3, 9, 1, 7 };

            InsertionSort(arr);

            Console.WriteLine(string.Join(", ", arr));
        }

        static void InsertionSort(int[] arr)
        {
            int n = arr.Length;
            for (int i = 1; i < n; ++i)
            {
                int key = arr[i];
                int j = i - 1;

                while (j >= 0 && arr[j] > key)
                {
                    arr[j + 1] = arr[j];
                    j = j - 1;
                }

                arr[j + 1] = key;
            }
        }
    }
}