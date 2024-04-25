using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_1_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TreeNode root = new TreeNode { Value = 1 };
            root.Children.Add(new TreeNode { Value = 2 });
            root.Children.Add(new TreeNode { Value = 3 });
            TreeNode child = new TreeNode { Value = 4 };
            child.Children.Add(new TreeNode { Value = 5 });
            root.Children.Insert(0, child);

            root.PrintChildrenValues();
        }
    }
}
