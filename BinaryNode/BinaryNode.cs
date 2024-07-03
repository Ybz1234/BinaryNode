using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryNode
{
    internal class BinaryNode<T>
    {
        public T Value { get; set; }
        public BinaryNode<T> Left { get; set; }
        public BinaryNode<T> Right { get; set; }
        public BinaryNode(T value)
        {
            this.Value = value;
            this.Left = this.Right = null;
        }
        public BinaryNode(BinaryNode<T> left, T value, BinaryNode<T> right)
        {
            this.Left = left;
            this.Value = value;
            this.Right = right;
        }
        public T GetValue()
        {
            return Value;
        }
        public BinaryNode<T> GetLeft()
        {
            return Left;
        }
        public BinaryNode<T> GetRight()
        {
            return Right;
        }

        public bool HasLeft()
        {
            return Left != null;
        }

        public bool HasRight()
        {
            return Right != null;
        }
        public void SetValue(T value)
        {
            this.Value = value;
        }
        public void SetLeft(BinaryNode<T> left)
        {
            Left = left;
        }
        public void SetRight(BinaryNode<T> right)
        {
            Right = right;
        }
        public override string ToString()
        {
            return Left + " " + Value + " " + Right;
        }
    }
}
