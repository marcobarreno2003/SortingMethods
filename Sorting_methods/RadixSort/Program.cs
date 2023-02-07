using System;

namespace RadixSortExample
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 170, 45, 75, 90, 802, 24, 2, 66 };
            int maxDigits = GetMaxDigits(arr);

            RadixSort(arr, maxDigits);

            Console.WriteLine(string.Join(", ", arr));
        }

        static void RadixSort(int[] arr, int maxDigits)
        {
            int[] output = new int[arr.Length];
            int[] count = new int[10];

            for (int i = 0, factor = 1; i < maxDigits; i++, factor *= 10)
            {
                Array.Clear(count, 0, count.Length);

                for (int j = 0; j < arr.Length; j++)
                {
                    int digit = (arr[j] / factor) % 10;
                    count[digit]++;
                }

                for (int j = 1; j < count.Length; j++)
                {
                    count[j] += count[j - 1];
                }

                for (int j = arr.Length - 1; j >= 0; j--)
                {
                    int digit = (arr[j] / factor) % 10;
                    output[count[digit] - 1] = arr[j];
                    count[digit]--;
                }

                Array.Copy(output, arr, arr.Length);
            }
        }

        static int GetMaxDigits(int[] arr)
        {
            int max = arr[0];

            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] > max)
                {
                    max = arr[i];
                }
            }

            int maxDigits = 0;

            while (max > 0)
            {
                maxDigits++;
                max /= 10;
            }

            return maxDigits;
        }
    }
}

