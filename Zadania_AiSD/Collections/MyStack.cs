using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadania_AiSD
{
    public class MyStack
    {
        private int[] InternalArray;
        private int Top;
        public MyStack(int size)
        {
            InternalArray = new int[size];
            Top = 0;
        }
        //probuje pobrac element z gory
        public bool TryPop(out int value) 
        {
            value = 0;
            if (Top == 0)
                return false;
            value = InternalArray[Top - 1];
            Top--;
            return true;
        }
        //dodaje element na gore
        public void Push(int value) 
        {
            InternalArray[Top] = value;
            Top++;
        }
    }
}
