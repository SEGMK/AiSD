using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadania_AiSD.SortingAlgorithms
{
    public class HeapSort
    {
        public static void Sort(int[] arr)
        {
            int n = arr.Length;

            // Budowanie kopca
            for (int i = n / 2 - 1; i >= 0; i--)
                Heapify(arr, n, i);

            // Usuwanie elementów z kopca
            for (int i = n - 1; i >= 0; i--)
            {
                // Przenoszenie korzenia kopca do końca
                int temp = arr[0];
                arr[0] = arr[i];
                arr[i] = temp;

                // Przywracanie właściwości kopca
                Heapify(arr, i, 0);
            }
        }

        private static void Heapify(int[] arr, int n, int i)
        {
            int largest = i;
            int left = 2 * i + 1;
            int right = 2 * i + 2;

            // Znajdowanie największego elementu
            if (left < n && arr[left] > arr[largest])
                largest = left;

            if (right < n && arr[right] > arr[largest])
                largest = right;

            if (largest != i)
            {
                int temp = arr[i];
                arr[i] = arr[largest];
                arr[largest] = temp;

                Heapify(arr, n, largest);
            }
        }
    }
}
