using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadania_AiSD
{
    public class MyCycleList
    {
        private Node CurrentNode;
        public int CurrentValue { get { return CurrentNode.Value; } private set { } }
        public MyCycleList()
        {
            CurrentNode = null;
        }
        //CurrentValue przemieszcza sie z kazdym dodanym elementem
        public void Add(int value)
        {
            if (CurrentNode == null)
            {
                CurrentNode = new Node(value);
                CurrentNode.NextNode = CurrentNode;
                CurrentNode.PreviousNode = CurrentNode;
            }
            else
            {
                Node pointerToPrevious = CurrentNode.PreviousNode;
                Node pointerToNext = CurrentNode.NextNode;
                Node newNode = new Node(value);
                newNode.PreviousNode = pointerToPrevious;
                newNode.NextNode = CurrentNode;
                CurrentNode.PreviousNode = newNode;
                pointerToPrevious.NextNode = newNode;
            }
        }
        public void Remove()
        {
            Node pointerToPrevious = CurrentNode.PreviousNode;
            Node pointerToNext = CurrentNode.NextNode;
            pointerToPrevious.NextNode = pointerToNext;
            pointerToNext.PreviousNode = pointerToPrevious;
            CurrentNode = CurrentNode.PreviousNode;
        }
        public void MoveNext()
        {
            CurrentNode = CurrentNode.NextNode;
        }
        public void MovePrevious()
        {
            CurrentNode = CurrentNode.PreviousNode;
        }
        private class Node
        {
            public Node NextNode { get; set; }
            public Node PreviousNode { get; set; }
            public int Value;
            public Node(int value)
            {
                NextNode = null;
                Value = value;
            }
        }
    }
}
