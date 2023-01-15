using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadania_AiSD.SortingAlgorithms
{
    public class CountingSort
    {
        public static int[] Sort(int[] arr, int min, int max)
        {
            int[] count = new int[max - min + 1];
            for (int i = 0; i < arr.Length; i++)
                count[arr[i] - min]++;

            int k = 0;
            for (int i = min; i <= max; i++)
                for (int j = 0; j < count[i - min]; j++)
                    arr[k++] = i;

            return arr;
        }
    }
}
