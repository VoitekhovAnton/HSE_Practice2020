using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading;

namespace Task_10
{
    class Tree
    {
        Node root;
        public int Count { get; set; }
        public Tree (int l)
        {
            Random r = new Random();
            for (int i = 0; i < l; i++)
            {
                Add(r.Next(-20, 20));
            }
        }                                 // Создаём дерево с количетсвом узлов равным l 
        public Tree(List<int> value_list)
        {
            for (int i = 0; i < value_list.Count; i++)
            {
                Add(value_list[i]);
            }
        }                   // Конструктор для слияния деревьев
        public void Add(int data)                               // Добавление элемента в дерево
        {
            if (root == null)
            {
                root = new Node(data);


                this.Count++;
                return;
            }
            RecAdd(root, data);


        }
        private void RecAdd(Node root,int data)                 // Построение дерева поиска с помощью рекурсии
        {
            if (root.Data < data) // Если добавляемый элемент меньше корня 
            {
                if (root.Right == null)
                {
                    root.Right = new Node(data);


                    this.Count++;
                    return;
                }
                RecAdd(root.Right, data);

            }
            else if (root.Data == data)  // Если элемент уже присутствует в дереве
            {
                Console.WriteLine($"Число {data} уже добавлено в дерево ");
                return;
            }
            else //Если добавляемый элемент больше корня
            {
                if (root.Left == null)
                {
                    root.Left = new Node(data);

                    this.Count++;

                    return;
                }
                RecAdd(root.Left, data);
            }
        }
        public static Tree Merger(Tree t1, Tree t2)
        {
            List<int> value_list = new List<int>();
            if (t1.Count>0)
                TakeValue(t1.root, value_list);
            else
                Console.WriteLine("Первое дерево пустое");
            if (t2.Count > 0)
                TakeValue(t2.root, value_list);
            else
                Console.WriteLine("Второе дерево пустое");
            if (value_list.Count > 0)
            {
                Tree Merger_tree = new Tree(value_list);
                return Merger_tree;
            }
            return null;
        }          // Слияние двух деревьев
        protected static void TakeValue(Node t, List<int> list) // Собираем значения с дерева в список
        {
            if (t != null)
            {
                TakeValue(t.Left,list);
                list.Add(t.Data);
                TakeValue(t.Right,list);
            }
        }
        void ShowTree(Node root, int l)
        {

            if (root != null)
            {
                ShowTree(root.Left, l + 3);
                for (int i = 0; i <= l; i++)
                {
                    Console.Write(" ");
                }
                Console.WriteLine(root.Data);

                ShowTree(root.Right, l + 3);
            }
        }                      // Вывод дерева
        public void Show()
        {
            ShowTree(root,3);
        }                                   //Для запуска в Main
    }
}
