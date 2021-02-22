namespace LinkedLists
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

    public class MyLinkedList
    {
        public Node Head { get; set; }
        public Node Tail { get; set; }

        public int Length { get; set; }
        public MyLinkedList(int value)
        {
            Head = new Node(value);
            Tail = Head;
            Length = 1;

        }
        public Node Reverse()
        {
            if (Length==1){
                return Head;
            }            
            Tail = Head;
            var slow = Head;
            while (true)
            {
                var fast = slow.Next;
                var originalFastNext = fast.Next;
                fast.Next = slow;
                slow = fast;
                fast = originalFastNext;
                if (originalFastNext == null){
                    Head = slow;
                    break;
                }
            }
            return Head;
        }
        public void Append(int value)
        {
            var newNode = new Node(value);
            Tail.Next = newNode;
            Tail = newNode;
            Length++;
        }

        public void Prepend(int value)
        {
            var newNode = new Node(value);
            newNode.Next = Head;
            Head = newNode;
            Length++;

        }

        /*
        Reflection: I was correct in saying i=1!!! Since we want to grab a ref to the node BEFORE the index
        */
        public void Insert(int index, int value)
        {

            if (index == 0)
            {
                Prepend(value);
            }
            int i = 1;
            var currentNode = Head;
            while (i < index)
            {
                currentNode = currentNode.Next;
                i++;
            }

            var newNode = new Node(value);
            newNode.Next = currentNode.Next;
            currentNode.Next = newNode;
        }

        public void Remove(int index)
        {
            if (index == 0)
            {
                Head = Head.Next;
            }

            // check for out of range

            int i = 1;
            var currentNode = Head;
            while (i < index)
            {
                currentNode = currentNode.Next;
                i++;
            }
            if (index == Length - 1)
            {
                Tail = currentNode;
            }
            else
            {
                currentNode.Next = currentNode.Next.Next;
            }
            Length--;

        }
    }



    public class MyDoubleLinkedList
    {
        public Node Head { get; set; }
        public Node Tail { get; set; }

        public int Length { get; set; }
        public MyDoubleLinkedList(int value)
        {
            Head = new Node(value);
            Tail = Head;
            Length = 1;

        }

        public void Append(int value)
        {
            var newNode = new Node(value);
            newNode.Previous = Tail;
            Tail.Next = newNode;
            Tail = newNode;
            Length++;
        }

        public void Prepend(int value)
        {
            var newNode = new Node(value);
            Head.Previous = newNode;
            newNode.Next = Head;
            Head = newNode;
            Length++;

        }

        /*
        Reflection: I was correct in saying i=1!!! Since we want to grab a ref to the node BEFORE the index
        */
        public void Insert(int index, int value)
        {

            if (index == 0)
            {
                Prepend(value);
            }

            if (index > Length - 1)
            {
                throw new System.Exception();
            }

            int i = 1;
            var currentNode = Head;
            while (i < index)
            {
                currentNode = currentNode.Next;
                i++;
            }

            var newNode = new Node(value);
            newNode.Previous = currentNode;
            newNode.Next = currentNode.Next;
            if (currentNode.Next != null)
            {
                currentNode.Next.Previous = newNode;
            }
            currentNode.Next = newNode;
            Length++;
        }

        public void Remove(int index)
        {
            if (index == 0)
            {
                Head = Head.Next;
                Head.Previous = null;
            }

            // check for out of range

            int i = 1;
            var currentNode = Head;
            while (i < index)
            {
                currentNode = currentNode.Next;
                i++;
            }
            if (index == Length - 1)
            {
                Tail = currentNode;
                Tail.Next = null;

            }
            else
            {
                currentNode.Next.Next.Previous = currentNode;
                currentNode.Next = currentNode.Next.Next;

            }
            Length--;

        }
    }

}