using System;
using System.Collections.Generic;

namespace practice_10
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("5. Написать метод слияния деревьев. (при слиянии корней остаются данные первой вершины)");

            Node root = new Node(1);
            root.AddChild(new Node(20));
            root.AddChild(new Node(3));
            root.children[0].AddChild(new Node(21)); // child to Node(2)

            // Tree1
            //        1
            //    2        3
            //21
            Console.WriteLine($"\t{root.data}" +
                              $"\n    {root.children[0].data}    {root.children[1].data}" +
                              $"\n{root.children[0].children[0].data}");
            Console.WriteLine("________________________________________________");

            Node root2 = new Node(10);
            root2.AddChild(new Node(20));
            root2.AddChild(new Node(30));
            root2.children[0].AddChild(new Node(210)); // child to Node(2)
            root2.children[1].AddChild(new Node(310)); // child to Node(3)

            // Tree2
            //        10
            //    20        30
            //210        310
            Console.WriteLine($"\t{root2.data}" +
                              $"\n    {root2.children[0].data}    {root2.children[1].data}" +
                              $"\n{root2.children[0].children[0].data}");
            Console.WriteLine("________________________________________________");


            Node result = Merge(root, root2);

            // Result
            //              1
            //    2        3         30
            //21    210          310
            Console.WriteLine($"\t    {result.data}" +
                              $"\n    {result.children[0].data}      {result.children[1].data}  \t  {result.children[2].data}" +
                              $"\n{result.children[0].children[0].data}   {result.children[0].children[1].data} \t   {result.children[2].children[0].data}");
        }

        public static Node Merge(Node tree1, Node tree2)
        {
            if (tree2 == null)
            {
                return tree1;
            }

            if (tree1 == null)
            {
                return tree2;
            }

            //tree1.data += tree2.data;

            for (int i = 0; i < tree1.children.Count; i++)
            {
                for (int j = 0; j < tree2.children.Count; j++)
                {
                    if (tree1.children[i].data == tree2.children[j].data)
                    {
                        tree1.children[i] = Merge(tree1.children[i], tree2.children[j]);
                        break;
                    }
                }
            }

            for (int i = 0; i < tree2.children.Count; i++)
            {
                bool flag = false;
                for (int j = 0; j < tree1.children.Count; j++)
                {
                    if (tree2.children[i].data == tree1.children[j].data)
                    {
                        flag = true;
                        break;
                    }
                }

                if (!flag)
                {
                    tree1.children.Add(tree2.children[i]);
                }
            }

            return tree1;
        }

        public class Node
        {
            public int data;
            public List<Node> children;

            public Node(int data)
            {
                this.data = data;
                children = new List<Node>();
            }

            public void AddChild(Node child)
            {
                if (!children.Contains(child))
                {
                    children.Add(child);
                }
            }
        }
    }
}