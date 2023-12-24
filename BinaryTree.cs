using System;
//binary tree of generic type that has been used here to specify the type
public class BinaryTree<T>where T : Person, IComparable<T>
{
    private BinaryTreeNode<T> root;

    public BinaryTree()
    {
        root = null;
    }

    public BinaryTreeNode<T> Root
    {
        get
        {
            return root;
        }
        set
        {
           root = value;
        }
    }
//method that takes any value to be inserted in a binary tree
public void Insert(T value)
{ 
              // calling actual method for insering node in a binary tree
                 Root = InsertNode(Root, value);
    
}

//method responsible for insertion of nodes into binary tree
public BinaryTreeNode<T> InsertNode(BinaryTreeNode<T> root,T value)
{ 
                if (root== null)
                {
                    root =new BinaryTreeNode<T>(value);
                }
                if (value.CompareTo(root.Data) < 0)
                    {
                    root.Left = InsertNode(root.Left, value);
                    }
                    else  if (value.CompareTo(root.Data) > 0)
                    { 
                    root.Right = InsertNode(root.Right, value); 
                    }  
              return root;  
}


// the method that takes in unique id of the perosn to be searched
  public BinaryTreeNode<T> Search(string uniqueId)
  {
    // creating a node;
    Queue<BinaryTreeNode<T>> queue = new Queue<BinaryTreeNode<T>>();
    
    // insert root node in a queue
    queue.Enqueue(Root);

    while(queue.Count>0)
    {
        BinaryTreeNode<T> currentNode = queue.Dequeue();

        // Ensure T is of type Person before casting
            if (currentNode.Data is Person personNode)
            {
                if (personNode.GetUniqueId() == uniqueId)
                {
                    return currentNode;
                }
            }
            if(currentNode.Left!=null)
            {            queue.Enqueue(currentNode.Left);
            }
            if(currentNode.Right!=null)
            {
                queue.Enqueue(currentNode.Right);
            }
    }
    return null;
  }


 //method that takes any value that needs to be removed from the binary tree
  public bool Remove(T value)
    {
                bool removed =  RemoveNode(Root, value,null);
                if(removed)
                {
                Console.WriteLine($"Node {value} has been removed.");
                }
                else 
                {
                    Console.WriteLine($"Node {value} not found in the tree.");
                }
            
            return removed;
      }

      //actual method for removing node from binary tree
   public bool RemoveNode(BinaryTreeNode<T> currentNode, T value, BinaryTreeNode<T> parent)
     {
                if (currentNode == null)
                {
                    return false; // Element not found
                }

                if (value.CompareTo(currentNode.Data) < 0)
                {
                    return RemoveNode(currentNode.Left, value, currentNode);
                }
                else if (value.CompareTo(currentNode.Data) > 0)
                {
                    return RemoveNode(currentNode.Right, value, currentNode);
                }
                else
                {
                    // Node to be removed found

                    // Node with only one child or no child
                    if (currentNode.Left == null)
                    {
                        UpdateParentReference(parent, currentNode, currentNode.Right);
                    }
                    else if (currentNode.Right == null)
                    {
                        UpdateParentReference(parent, currentNode, currentNode.Left);
                    }
                    else
                    {
                        // Node with two children: Get the in-order successor (smallest in the right subtree)
                        currentNode.Data = RemoveMinValue(currentNode.Right, currentNode);
                    }

                    return true;
                }
    }

   private T RemoveMinValue(BinaryTreeNode<T> currentNode, BinaryTreeNode<T> parent)
    {
            while (currentNode.Left != null)
            {
                parent = currentNode;
                currentNode = currentNode.Left;
            }

            // currentNode is the in-order successor (min value in the right subtree)
            // Remove the in-order successor node
            if (parent.Left == currentNode)
            {
                parent.Left = currentNode.Right;
            }
            else
            {
                parent.Right = currentNode.Right;
            }

            return currentNode.Data;
    }

    private void UpdateParentReference(BinaryTreeNode<T> parent, BinaryTreeNode<T> currentNode, BinaryTreeNode<T> newChild)
    {
                if (parent == null)
                {
                    Root = newChild; // Update root reference
                }
                else if (parent.Left == currentNode)
                {
                    parent.Left = newChild;
                }
                else
                {
                    parent.Right = newChild;
                }
}
 // In-order traversal
    public List<T> InOrderTraversal()
    {
        List<T> result = new List<T>();
        InOrderTraversalHelper(Root, result);
        return result;
    }
// In-order traversal
     private void InOrderTraversalHelper(BinaryTreeNode <T> node, List<T> result)
    {
        if (node != null)
        {
            InOrderTraversalHelper(node.Left, result);
            result.Add(node.Data);
            InOrderTraversalHelper(node.Right, result);
        }
    }
//Post-order traversal
public void PostorderTraversal(BinaryTreeNode<T> node)
{
                if (node == null)
                {
                    return;
                }
                PostorderTraversal(node.Left);
                PostorderTraversal(node.Right);
                Console.WriteLine(node.Data);
    
}

 // Post-order traversal
    public List<T> PostOrderTraversal()
    {
        List<T> result = new List<T>();
        PostOrderTraversalHelper(Root, result);
        return result;
    }

    private void PostOrderTraversalHelper(BinaryTreeNode <T> node, List<T> result)
    {
        if (node != null)
        {
            PostOrderTraversalHelper(node.Left, result);
            PostOrderTraversalHelper(node.Right, result);
            result.Add(node.Data);
        }
    }
}


