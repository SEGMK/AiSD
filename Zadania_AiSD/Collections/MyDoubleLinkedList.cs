using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadania_AiSD
{
    public class MyDoubleLinkedList
    {
        private Node FirstNode;
        private Node CurrentNode;
        public int CurrentValue { get { return CurrentNode.Value; } private set { } }
        public MyDoubleLinkedList() 
        {
            FirstNode = null;
            CurrentNode = FirstNode;
        }
        public void AddFirst(int value)
        {
            Node node = new Node(value);
            if (FirstNode == null)
            {
                FirstNode = node;
                CurrentNode = FirstNode;
            }
            else
            {
                node.NextNode = FirstNode;
                FirstNode.PreviousNode = node;
                FirstNode = node;
            }
        }
        //nie działa dodanie node-a na ostatnią pozycje 
        public void AddLast(int value)
        {
            Node node = new Node(value);
            if (FirstNode == null)
            {
                FirstNode = node;
                CurrentNode = FirstNode;
            }
            else
            {
                CurrentNode.NextNode = node;
                node.PreviousNode = CurrentNode;
            }
        }
        public void RemoveLast()
        {
            Node node = FirstNode;
            Node previousNode = null;
            while (node.NextNode != null)
            {
                previousNode = node;
                node = node.NextNode;
            }
            if (CurrentNode == node)
                CurrentNode = previousNode;
            previousNode.NextNode = null;
        }
        public void RemoveFirst()
        {
            if (CurrentNode == FirstNode)
                CurrentNode = FirstNode.NextNode;
            FirstNode = FirstNode.NextNode;
            FirstNode.PreviousNode = null;
        }
        public bool MoveNext()
        {
            if (CurrentNode.NextNode == null)
                return false;
            else
            {
                CurrentNode = CurrentNode.NextNode;
                return true;
            }
        }
        public bool MovePrevious() 
        {
            if (CurrentNode.PreviousNode == null)
                return false;
            else
            {
                CurrentNode = CurrentNode.PreviousNode;
                return true;
            }

        }
        public void GoToFirstNode()
        {
            CurrentNode = FirstNode;
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
