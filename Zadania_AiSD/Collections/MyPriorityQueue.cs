using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadania_AiSD
{
    public class MyPriorityQueue
    {
        private int[] InternalArray;
        private bool[] IsEmpty;
        private bool IsReseted;
        private int Head;
        private int Tail;
        public MyPriorityQueue(int size)
        {
            InternalArray = new int[size];
            IsEmpty = new bool[size];
            Head = 0;
            Tail = 0;
            for (int i = 0; i < IsEmpty.Length; i++)
            {
                IsEmpty[i] = true;
            }
        }
        //oznaczenie elementu jako wolny
        public bool TryDequeue(out int value)
        {
            value = 0;
            if (IsEmpty[Tail])
                return false;
            value = InternalArray[Tail];
            IsEmpty[Tail] = true;
            Tail++;
            if (InternalArray.Length <= Tail)
                Tail = 0;
            IsReseted = false;
            return true;
        }
        //dodanie elementu do tablicy zgodnie z zasada kolejki
        public bool TryEnqueue(int value)
        {
            if (!IsEmpty[Head])
                return false;
            InternalArray[Head] = value;
            IsEmpty[Head] = false;
            Head++;
            if (InternalArray.Length <= Head)
            {
                Head = 0;
                IsReseted = true;
            }
            SortNotEmpty();
            return true;
        }
        //ustawienie priorytetu od najwiekszej do najmniejszej wartosci
        private void SortNotEmpty()
        {
            int position = Head;
            if (IsReseted)
                position += InternalArray.Length;
            List<int> values = new List<int>();
            for (int i = Tail; i < position; i++)
            {
                if (!IsEmpty[i % InternalArray.Length])
                {
                    values.Add(InternalArray[i % InternalArray.Length]);
                }
            }
            values.Sort();
            values.Reverse();
            for (int i = Tail; i < position; i++)
            {
                if (!IsEmpty[i % InternalArray.Length])
                {
                    InternalArray[i % InternalArray.Length] = values[0];
                    values.RemoveAt(0);
                }
            }
        }
    }
}
