using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadania_AiSD
{
    public class MyQueue
    {
        private int[] InternalArray;
        private bool[] IsEmpty;
        private int Head;
        private int Tail;
        public MyQueue(int size)
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
            if (InternalArray.Length <= Tail)
                Tail = 0;
            if (IsEmpty[Tail])
                return false;
            value = InternalArray[Tail];
            IsEmpty[Tail] = true;
            Tail++;
            return true;
        }
        //dodanie elementu do tablicy zgodnie z zasada kolejki
        public bool TryEnqueue(int value)
        {
            if (InternalArray.Length <= Head)
                Head = 0;
            if (!IsEmpty[Head])
                return false;
            InternalArray[Head] = value;
            IsEmpty[Head] = false;
            Head++;
            return true;
        }
    }
}
