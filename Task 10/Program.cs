using System;
using System.Net.Http.Headers;

namespace Task_10
{
    class Program
    {
        static int Input(string str)
        {
            int a = 0;
            bool ok = true;
            do
            {
                try
                {
                    Console.WriteLine(str);
                    a = Int32.Parse(Console.ReadLine());
                    ok = true;
                    if (a < 0)
                    {
                        ok = false;
                        Console.WriteLine("Введите положительное число");
                    }

                }
                catch
                {
                    Console.WriteLine("Введите натуральное число");
                    ok = false;
                }
            } while (!ok);
            return a;
        }   // Ввод положительного числа 
        static void Main(string[] args)
        {
            Tree t1 = new Tree(Input("Введите количество элементов в дереве t1"));
            Tree t2 = new Tree(Input("Введите количество элементов в дереве t2"));
            Console.WriteLine("      t1");
            Console.WriteLine();
            t1.Show();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("      t2");
            Console.WriteLine();
            t2.Show();
            Tree t3 = Tree.Merger(t1, t2);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            if (t3 != null)
            {
                Console.WriteLine("      t3");
                Console.WriteLine();
                t3.Show();
            }
            else
                Console.WriteLine("Оба дерева не содержат элементов");
            



        }
    }
}
