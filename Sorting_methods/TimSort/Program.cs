using System;

namespace TimSortExample
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 12, 11, 13, 5, 6, 7 };
            TimSort(arr);
            Console.WriteLine(string.Join(", ", arr));
        }

        static void TimSort(int[] arr)
        {
            int n = arr.Length;
            int minRun = GetMinRun(n);

            for (int i = 0; i < n; i += minRun)
            {
                InsertionSort(arr, i, Math.Min((i + minRun - 1), (n - 1)));
            }

            for (int size = minRun; size < n; size = 2 * size)
            {
                for (int start = 0; start < n; start += 2 * size)
                {
                    int midpoint = start + size - 1;
                    int end = Math.Min((start + 2 * size - 1), (n - 1));
                    Merge(arr, start, midpoint, end);
                }
            }
        }

        static void InsertionSort(int[] arr, int left, int right)
        {
            for (int i = left + 1; i <= right; i++)
            {
                int temp = arr[i];
                int j = i - 1;

                while (j >= left && arr[j] > temp)
                {
                    arr[j + 1] = arr[j];
                    j--;
                }

                arr[j + 1] = temp;
            }
        }

        static void Merge(int[] arr, int l, int m, int r)
        {
            int i, j, k;
            int n1 = m - l + 1;
            int n2 = r - m;

            int[] L = new int[n1];
            int[] R = new int[n2];

            for (i = 0; i < n1; i++)
            {
                L[i] = arr[l + i];
            }
            for (j = 0; j < n2; j++)
            {
                R[j] = arr[m + 1 + j];
            }

            i = 0;
            j = 0;
            k = l;

            while (i < n1 && j < n2)
            {
                if (L[i] <= R[j])
                {
                    arr[k] = L[i];
                    i++;
                }
                else
                {
                    arr[k] = R[j];
                    j++;
                }
                k++;
            }

            while (i < n1)
            {
                arr[k] = L[i];
                i++;
                k++;
            }

            while (j < n2)
            {
                arr[k] = R[j];
                j++;
                k++;
            }
        }

        static int GetMinRun(int n)
        {
            int r = 0;
            while (n >= 64)
            {
                r |= n & 1;
                n >>= 1;
            }
            return n + r;
        }
    }
}

