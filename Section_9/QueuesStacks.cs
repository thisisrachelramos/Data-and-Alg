using System;
using System.Collections.Generic;

namespace QueuesStacks
{
    public class Node
    {
        public int Value { get; set; }
        public Node Next { get; set; }

        public Node Previous { get; set; }

        public Node(int value)
        {
            Value = value;
            Next = null;
            Previous = null;
        }
    }

    /*
    Reflection: good at -1 for remove since we want to do our pointer magic b4 the node we remove
    STILL forgetting to update the length.
    Still need to validate is len == 0
    New: Linked list goes top (next)-> (next)-> (next)-> bottom (Makes pop easy 😊)
    New: Pop needs a check if length is 1, since top is === bottom
    */
    public class Stack
    {
        public Node Top { get; private set; }
        public Node Bottom { get; private set; }
        public int Length { get; private set; }
        public Stack()
        {
            Top = null;
            Bottom = null;
            Length = 0;
        }

        public Node Peek()
        {
            return Top;
        }

        public void Push(int value)
        {
            var oldTop = Top;
            Top = new Node(value);
            Top.Next = oldTop;
            if (Length == 0)
            {
                Bottom = Top;
            }
            Length++;
            return;
        }

        public void Pop()
        {
            if (Length == 0)
            {
                return;
            }
            if (Length == 1)
            {
                Bottom = Top;
            }
            var oldTop = Top;
            Top = Top.Next;
            Length--;
            return;
        }
    }

    public class Stackv2
    {
        private List<int?> _stack = new List<int?>();
        private int? _top;
        private int? _bottom;
        public Stackv2()
        {

            _top = null;
            _bottom = null;

        }

        public int? Peek()
        {
            return _stack[_stack.Count - 1];
        }

        public void Push(int value)
        {
            _stack.Add(value);
            return;
        }

        public void Pop()
        {
            _stack.RemoveAt(_stack.Count - 1);
        }
    }

    public class Queue
    {
        private Node _first;
        private Node _last;

        private int _length;
        public Queue()
        {
            _first = null;
            _last = null;
            _length = 0;
        }

        public int Peek()
        {
            return _first.Value;
        }

        public void Enqueue(int value)
        {
            var newNode = new Node(value);
            _last.Next = newNode;
            _last = newNode;
            if (_length == 0)
            {
                _first = newNode;
            }          
            _length++;
            return;
        }

        public void Dequeue()
        {
            if (_length == 0)
            {
                return;
            }
            _first = _first.Next;
            if (_length == 2)
            {
                _last = _first;
            }
            if (_length == 1){
                _first = null;
                _last = null;
            }
            _length--;
            return;
        }
    }
}

public class LeetCode232 {

    private Stack<int> stack1 = new Stack<int>();
    private Stack<int> stack2 = new Stack<int>();
    
    /** Initialize your data structure here. */
    public LeetCode232() {
        
        
    }
    
    /** Push element x to the back of queue. */
    public void Push(int x) {
            
        while(stack1.Count > 0){
            stack2.Push(stack1.Pop());
        }
        stack1.Push(x);
         while(stack2.Count > 0){
             stack1.Push(stack2.Pop());
         }     
 
    }
    
    /** Removes the element from in front of queue and returns that element. */
    public int Pop() {
         return   stack1.Pop();
    }
    
    /** Get the front element. */
    public int Peek() {
      return  stack1.Peek();
    }
    
    /** Returns whether the queue is empty. */
    public bool Empty() {
        return stack1.Count == 0 ;
        
    }
}

/**
 * Your MyQueue object will be instantiated and called as such:
 * MyQueue obj = new MyQueue();
 * obj.Push(x);
 * int param_2 = obj.Pop();
 * int param_3 = obj.Peek();
 * bool param_4 = obj.Empty();
 */