using System;
using System.Collections.Generic;

public class BinaryTreeNode<T>where T : IComparable<T>
  {
        private T data;
        private BinaryTreeNode<T>? left;
        private BinaryTreeNode<T>? right;
        private BinaryTreeNode<T>? parent;
        public BinaryTreeNode(T data)
    {
        this.data = data;
        this.left=null;
        this.right=null;
        this.parent = null;

    }

    public T Data 
    { 
        get
        {
          return data;
        }
        set
        {
            data=value;
        }
     }
    public BinaryTreeNode<T> Left
     {  
        get
        {
            return left;
        } 
        set
        {
            left=value;
        }
    }
    public BinaryTreeNode<T> Right
    { 
        get
        {
            return right;
        } 
        set
        {
            right=value;
        }
     }

  public BinaryTreeNode<T> Parent
    { 
        get
        {
            return parent;
        } 
        set
        {
            right=value;
        }
     }
}
