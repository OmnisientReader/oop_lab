using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_1_3
{
    class TreeNode
    {
        public int Value { get; set; }
        public List<TreeNode> Children { get; } = new List<TreeNode>();

        public void PrintChildrenValues()
        {
            Console.WriteLine($"Children of node with value {Value}:");
            foreach (var child in Children)
            {
                Console.WriteLine(child.Value);
                //child.PrintChildrenValues();
            }
            foreach (var child in Children)
            {
                child.PrintChildrenValues();
            }
        }
    }
}
