using System.Collections.Generic;

namespace Graphs {

    public class Graph{

        private int _numberOfNodes = 0;
        private Dictionary<int, List<int>> _adjacencyList = new Dictionary<int, List<int>>();
        Graph(){
            
        }

        public void AddVertex(int value){
           
            if(_adjacencyList.ContainsKey(value)){
                // we can throw a error and/or log
                return;
            }

             _numberOfNodes++;
             _adjacencyList.Add(value,new List<int>());
        }

        public void AddEdge(int vertex1, int vertex2){
            if (_adjacencyList.ContainsKey(vertex1)){
                _adjacencyList[vertex1].Add(vertex2);

            }

            if (_adjacencyList.ContainsKey(vertex2)){
                _adjacencyList[vertex2].Add(vertex1);
            }
        }
    }


}