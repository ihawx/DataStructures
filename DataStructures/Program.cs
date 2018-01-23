using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            var stack = new MyStack<int>();
            stack.Push(3);
            stack.Push(2);
            stack.Push(1);
            Console.WriteLine(stack.Count);
        }
    }
}
