using System;

namespace ShellSortExample
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 12, 34, 54, 2, 3 };
            ShellSort(arr);
            Console.WriteLine(string.Join(", ", arr));
        }

        static void ShellSort(int[] arr)
        {
            int n = arr.Length;
            int gap = n / 2;

            while (gap > 0)
            {
                for (int i = gap; i < n; i++)
                {
                    int temp = arr[i];
                    int j;

                    for (j = i; j >= gap && arr[j - gap] > temp; j -= gap)
                    {
                        arr[j] = arr[j - gap];
                    }

                    arr[j] = temp;
                }

                gap /= 2;
            }
        }
    }
}

