using System.Runtime.CompilerServices;
using System.Threading;
using System;
using Zadania_AiSD.Collections;
using Zadania_AiSD.SortingAlgorithms;

namespace Zadania_AiSD
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //stworzenie tablicy i nadanie jej losowych wartosci <0; 100)
            int[] array = new int[100];
            Random r = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = r.Next(0, 100);
            }
            MergeSort.Sort(array, 0, array.Length - 1);
        }
        
    }
}