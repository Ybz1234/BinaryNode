using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryNode
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
        }
        static void PreOrder<T>(BinaryNode<T> t)
        {
            if (t == null) return;
            Console.Write($"{t.GetValue()} ➡  ");
            PreOrder(t.GetLeft());
            PreOrder(t.GetRight());
        }
        static void InOrder<T>(BinaryNode<T> t)
        {
            if (t == null) return;
            InOrder(t.GetLeft());
            Console.Write($"{t.GetValue()} ➡  ");
            InOrder(t.GetRight());
        }
        static void PostOrder<T>(BinaryNode<T> t)
        {
            if (t == null) return;
            PostOrder(t.GetLeft());
            PostOrder(t.GetRight());
            Console.Write($"{t.GetValue()} ➡  ");
        }
        static void PrintEven(BinaryNode<int> t)
        {
            if (t == null) return;
            if (t.GetValue() % 2 == 0)
                Console.Write($"{t.GetValue()} ➡  ");
            PrintEven(t.GetLeft());
            PrintEven(t.GetRight());
        }
        static int NumOfNodes<T>(BinaryNode<T> t)
        {
            if (t == null) return 0;
            return 1 + NumOfNodes(t.GetLeft()) + NumOfNodes(t.GetRight());
        }
        static bool IsExists<T>(BinaryNode<T> t, T value)
        {
            if (t == null) return false;
            if (value.Equals(t.GetValue())) return true;
            return IsExists(t.GetLeft(), value) || IsExists(t.GetRight(), value);
        }
        static bool IsEachFatherHas2Child<T>(BinaryNode<T> t)
        {
            if (t == null)
                return true;

            if (IsLeaf(t))
                return true;

            else if (!t.HasLeft() || !t.HasRight())
                return false;
            return IsEachFatherHas2Child(t.GetLeft()) && IsEachFatherHas2Child(t.GetRight());
        }
        static int Height<T>(BinaryNode<T> t)
        {
            if (t == null) return -1;
            return 1 + Math.Max(Height(t.GetLeft()), Height(t.GetRight()));
        }
        public static bool IsLeaf<T>(BinaryNode<T> t)
        {
            return !t.HasLeft() && !t.HasRight();
        }
        public static int LeafsCounter<T>(BinaryNode<T> t)
        {
            if (t == null) return 0;
            else if (IsLeaf(t)) return 1;
            return LeafsCounter(t.GetLeft()) + LeafsCounter(t.GetRight());
        }
        public static void PrintLeafs<T>(BinaryNode<T> t)
        {
            if (t == null) return;
            if (IsLeaf(t))
            {
                Console.Write($"{t.GetValue()} ➡  ");
                return;
            }
            PrintLeafs(t.GetLeft());
            PrintLeafs(t.GetRight());
        }
        public static void SetMultiplication(BinaryNode<int> t)
        {
            if (t == null) return;
            t.SetValue(t.GetValue() * 2);
            SetMultiplication(t.GetLeft());
            SetMultiplication(t.GetRight());
        }
        static public bool IsValueEqualsToChildrenSum(BinaryNode<int> node)
        {
            if (!IsEachFatherHas2Child(node))
                return false;

            bool left = false;
            bool right = false;

            if (node.GetValue().Equals(node.GetLeft().GetValue() + node.GetRight().GetValue()))
            {
                left = IsValueEqualsToChildrenSum(node.GetLeft());
                right = IsValueEqualsToChildrenSum(node.GetRight());
            }
            return left && right;
        }
        public static int MaxVal(BinaryNode<int> node)
        {
            if (node == null)
                return 0;
            return Math.Max(Math.Max(MaxVal(node.GetRight()), node.GetValue()), Math.Max(MaxVal(node.GetLeft()), node.GetValue()));
        }
        public static void PrintValuesPerLevel(BinaryNode<int> t, int level)
        {
            if (t == null) return;

            if (level == 0)
            {
                Console.Write($"{t.GetValue()} ➡  ");
                return;
            }

            PrintValuesPerLevel(t.GetLeft(), level - 1);
            PrintValuesPerLevel(t.GetRight(), level - 1);
        }
        public static string GetMathExpression(BinaryNode<char> t)
        {
            return t.ToString();
        }
        public static int GetResult(BinaryNode<char> t)
        {
            if (t == null)
                return 0;

            if (char.IsDigit(t.GetValue()))
                return t.GetValue() - 48;

            else
            {
                char op = t.GetValue();
                switch (op)
                {
                    case '+': return GetResult(t.GetLeft()) + GetResult(t.GetRight());
                    case '-': return GetResult(t.GetLeft()) - GetResult(t.GetRight());
                    case '*': return GetResult(t.GetLeft()) * GetResult(t.GetRight());
                    case '/': return GetResult(t.GetLeft()) / GetResult(t.GetRight());
                    default: throw new InvalidOperationException("Unknown operator");
                }
            }
        }
    }
}
