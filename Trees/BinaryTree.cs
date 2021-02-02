using System;

namespace Trees
{
    

public class Node {
 
 public Node right {get; set;}
 public Node left {get;set;}
 public int value {get;set;}

 public Node(int valueIn){
     this.left = null;
     this.right = null;
     this.value = valueIn;
 }
}

public class BinarySearchTree {
    private Node _root;
    //construc
    BinarySearchTree(){
        _root = null;
    }

    //insert
    public void Insert(int value){
        var insertedNode = new Node(value);
        if (_root==null){
            _root = insertedNode;
        }
        
        Node i,j;
        i = j =  _root;
        // find my parent
        while (i!=null){
            j = i;
            if (value > i.value){
                i = i.right;   
            }else{
                i = i.left;
            }
        }   
        
        // determine my relationship
        if (value > j.value){
            j.right = insertedNode;
        }else{
            j.left =insertedNode;
        }    
    }
    
public void InsertV2(int value){
    // new node
    var insertedNode = new Node(value);

    
    // base case
    if (_root == null){
        _root = insertedNode;
    }

   var currentNode = _root;
    while (true){
        if (value > currentNode.value){
            if (currentNode.right == null){
                currentNode.right = insertedNode;
                return;
            }
            currentNode = currentNode.right;
        }
        else{
            if (value < currentNode.value){
                if (currentNode.left == null){
                    currentNode.left = insertedNode;
                    return;
                }
                currentNode = currentNode.left;
            }
        }
    }
}

    //lookup
    public bool Lookup(int value){
        var i = _root;
        while (i !=null){
            if (value == i.value){
                return true;
            }
            else if (value > i.value){
                i = i.right;   
            }
            else {
               i = i.left;
            }
        }
        return false;
    }
    
}



}