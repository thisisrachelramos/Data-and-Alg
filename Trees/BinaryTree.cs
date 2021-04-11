using System;

namespace Trees
{


    public class Node
    {

        public Node Right { get; set; }
        public Node Left { get; set; }
        public int Value { get; set; }

        public Node(int valueIn)
        {
            this.Left = null;
            this.Right = null;
            this.Value = valueIn;
        }
    }

    public class BinarySearchTree
    {
        private Node _root;
        //construc
        BinarySearchTree()
        {
            _root = null;
        }

        //insert
        public void Insert(int value)
        {
            var insertedNode = new Node(value);
            if (_root == null)
            {
                _root = insertedNode;
            }

            Node i, j;
            i = j = _root;
            // find my parent
            while (i != null)
            {
                j = i;
                if (value > i.Value)
                {
                    i = i.Right;
                }
                else
                {
                    i = i.Left;
                }
            }

            // determine my relationship
            if (value > j.Value)
            {
                j.Right = insertedNode;
            }
            else
            {
                j.Left = insertedNode;
            }
        }

        public void InsertV2(int value)
        {
            // new node
            var insertedNode = new Node(value);


            // base case
            if (_root == null)
            {
                _root = insertedNode;
            }

            var currentNode = _root;
            while (true)
            {
                if (value > currentNode.Value)
                {
                    if (currentNode.Right == null)
                    {
                        currentNode.Right = insertedNode;
                        return;
                    }
                    currentNode = currentNode.Right;
                }
                else
                {
                    if (value < currentNode.Value)
                    {
                        if (currentNode.Left == null)
                        {
                            currentNode.Left = insertedNode;
                            return;
                        }
                        currentNode = currentNode.Left;
                    }
                }
            }
        }

        //lookup
        public bool Lookup(int value)
        {
            var i = _root;
            while (i != null)
            {
                if (value == i.Value)
                {
                    return true;
                }
                else if (value > i.Value)
                {
                    i = i.Right;
                }
                else
                {
                    i = i.Left;
                }
            }
            return false;
        }


        /*
        Reflection:
        got the code correct in the first try :D
        Needed help to keep it DRY and order of iteration AFTER the null check
        forgot return after setting the root to the new node (for the case of an empty tree)
        wrong direction for > greater than sign
        */
        public void InsertV3(int value)
        {
            var newNode = new Node(value);
            if (_root == null)
            {
                _root = newNode;
                return;
            }

            var currentNode = _root;
            while (true)
            {
                if (currentNode.Value < value)
                {

                    if (currentNode.Right == null)
                    {
                        currentNode.Right = newNode;
                        return;
                    }
                    currentNode = currentNode.Right;
                }
                else
                {

                    if (currentNode.Left == null)
                    {
                        currentNode.Left = newNode;
                        return;

                    }
                    currentNode = currentNode.Left;
                }
            }


        }

        //lookup
        public bool Lookupv2(int value)
        {
            if (_root == null)
            {
                return false;
            }
            var currentNode = _root;

            while (currentNode != null)
            {
                if (currentNode.Value == value)
                {
                    return true;
                }
                if (value > currentNode.Value)
                {
                    currentNode = currentNode.Right;
                }
                else
                {
                    currentNode = currentNode.Left;
                }

            }

            return false;
        }
        /*
        We need a reference to the parent node
        Need to do the simple parts 
        ****FIRSTTTT**
        */
        public void Remove(int value)
        {
            if (_root == null)
            {
                return;
            }

            var current = _root;
            Node parent = null;
            /*
            val: 41

                41      
            40      70


                50


                41      
            40      70


                        71

                41      
            40      70


                50     71

            */
            while (current != null)
            {
                // traverse
                if (value > current.Value)
                {
                    parent = current;
                    current = current.Right;
                }
                else if (value < current.Value)
                {
                    parent = current;
                    current = current.Left;
                }
                // we have a match
                if (current.Value == value)
                {


                    
                    var rightChild = current.Right;
                    // 1. Current node has no Right child
                    if (current.Right == null)
                    {
                        // root check
                        if (parent == null){
                            this._root = current.Left;
                        }else{
                            // parent > current
                            // parent's left 
                            if (parent.Value > current.Value){
                                parent.Left = current.Left;
                            }
                            // parent < current
                            else if (parent.Value < current.Value){
                                parent.Right = current.Left;
                            }
                           
                        }
                    }
                    // todo:
                    // 2. Has right child with right leaf

                    // 3. Has right child with left leaf

                    // 4. Has right child with both leaves



                }
            }
        }

        public void Traverse(Node root){
            if (root == null){
                return;
            }

            Traverse(root.Right);

            Traverse(root.Left);
       
        }

    }



}