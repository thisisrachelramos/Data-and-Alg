/*
Reflection: it is ENQUEUE for ADDING to queuue


1.If solution not far from root: BFS

2. Very deep and solutions are rare: DFS
WRONG: BFS since its faster

3. Very wide: DFS... (since height will be small,
which is good for memory)

4. Frequent and deep in tree: BFS
WRONG: DFS, since answers are fr from root

5. Path exists? DFS

6. Finding shortest path: BFS

*/
using Trees;
using System;
using System.Collections.Generic;
namespace Traveral
{
    public class GraphTraveral
    {

        private BinarySearchTree bst = new BinarySearchTree();

        GraphTraveral()
        {
            bst.InsertV3(9);
            bst.InsertV3(4);
            bst.InsertV3(6);
            bst.InsertV3(20);
            bst.InsertV3(170);
            bst.InsertV3(15);
        }

        public List<int> BreadthFirstSearch()
        {
            new GraphTraveral();
            var currentNode = bst.root;
            var bfsQueue = new Queue<Node>();
            var result = new List<int>();
            bfsQueue.Enqueue(currentNode);
            while (bfsQueue.Count > 0)
            {
                currentNode = bfsQueue.Dequeue();
                result.Add(currentNode.Value);
                if (currentNode.Left != null)
                {
                    bfsQueue.Enqueue(currentNode.Left);
                }
                if (currentNode.Right != null)
                {
                    bfsQueue.Enqueue(currentNode.Right);
                }
            }
            return result;

        }
// Post order
        public List<int> DepthFirstSearch(Node current, List<int> result){
            if (current.Left != null){
                DepthFirstSearch(current.Left, result);
            }
            if (current.Right != null){
                DepthFirstSearch(current.Right, result);
            }
            result.Add(current.Value);
            return result;
        }

        // static void Main(string[] args)
        // {


        // }
    }
}