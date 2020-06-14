using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Task_99
{
    class CircularLinkedList<T>
    {
        Node<T> head; // Первый элемент списка 
        Node<T> tail; // Последний элемент списка, хронящий ссылку на первый элемент 
        public int Count { get; private set; }
        public int CE() // Итеративный подсчёт элементов 
        {
            if (head != null)
            {
                Node<T> node = head.Next;
                int count = 1;
                while (!(head.Equals(node)))
                {
                    node = node.Next;
                    count++;
                }
                return count;
            }
            else
                return 0;
          
        }
        
        public int CE_Rec() // Для запуска функции в Mian 
        {
            if (head != null)
                return Rec(head.Next, head);
            else
                return 0;

        }
        private int Rec(Node<T> node,Node<T> Head) // Рекурсивный подсчёт элементов 
        {
            int count = 0;
            if (!(node.Equals(Head)))
            {
                count += Rec(node.Next, Head);
                count++;
                return count;
            }
            else
                return 1;
            
        }
        public void Add(T data) // Добавления элемента в список 
        {
            Node<T> node = new Node<T>(data);
            if (head == null)
            {
                head = node;
                tail = head;
                tail.Next = head;
            }
            else
            {
                node.Next = head;
                tail.Next = node;
                tail = node;
            }
            Count++;
        }
    }
}
