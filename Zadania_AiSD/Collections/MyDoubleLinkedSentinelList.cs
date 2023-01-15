using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Zadania_AiSD.Collections
{
    public class MyDoubleLinkedSentinelList
    {
        private Node FirstNode;
        private Node LastNode;
        private Node CurrentNode;
        public int CurrentValue { get { return CurrentNode.Value; } private set { } }
        public MyDoubleLinkedSentinelList()
        {
            FirstNode = null;
            CurrentNode = FirstNode;
        }
        public bool Search(int value)
        {
            Node node = new Node(value);
            node.IsSentient = true;
            LastNode.NextNode = node;
            node.PreviousNode = LastNode;
            LastNode = node;
            Node searchNode = FirstNode;
            while (searchNode.Value != value)
            {
                searchNode = searchNode.NextNode;
            }
            LastNode = LastNode.PreviousNode;
            LastNode.NextNode = null;
            if (!searchNode.IsSentient)
                return true;
            else
                return false;
        }
        public void AddFirst(int value)
        {
            Node node = new Node(value);
            if (FirstNode == null)
            {
                FirstNode = node;
                CurrentNode = FirstNode;
                LastNode = FirstNode;
            }
            else
            {
                node.NextNode = FirstNode;
                FirstNode.PreviousNode = node;
                FirstNode = node;
            }
        }
        public void AddLast(int value)
        {
            Node node = new Node(value);
            if (FirstNode == null)
            {
                FirstNode = node;
                CurrentNode = FirstNode;
                LastNode = FirstNode;
            }
            else
            {
                LastNode.NextNode = node;
                node.PreviousNode = LastNode;
                LastNode = node;
            }
        }
        public void RemoveLast()
        {
            if (CurrentNode == LastNode)
                CurrentNode = CurrentNode.PreviousNode;
            if (FirstNode == LastNode)
                FirstNode = null;
            LastNode = LastNode.PreviousNode;
            if (LastNode != null)
                LastNode.NextNode = null;

        }
        public void RemoveFirst()
        {
            if (CurrentNode == FirstNode)
                CurrentNode = FirstNode.NextNode;
            if (LastNode == FirstNode)
                LastNode = null;
            FirstNode = FirstNode.NextNode;
            if (FirstNode != null)
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
        public void GoToLastNode()
        {
            CurrentNode = LastNode;
        }
        private class Node
        {
            public Node NextNode { get; set; }
            public Node PreviousNode { get; set; }
            public int Value;
            public bool IsSentient;
            public Node(int value)
            {
                NextNode = null;
                Value = value;
                IsSentient = false;
            }
        }
    }
}
