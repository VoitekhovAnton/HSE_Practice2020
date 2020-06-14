using System;
using System.Collections.Generic;
using System.Text;

namespace Task_9
{
    class DoublyLinkedList
    {
        Node head;// Начало списка
        Node tail;// Конец списка
        public int Count { get; private set; }
        public DoublyLinkedList (int N)
        {
            for (int i = N; i > 0; i--)
            {
                Node node = new Node(i);
                if (head == null)
                {
                    head = node;
                }
                else
                {
                    node.Prev = tail;
                    tail.Next = node;                   
                }
                tail = node;
                Count++;
            }
        }
        public void Show()
        {
            if (head != null)
            {
                string ToShow = null;
                Node node = head;
                while (node != null)
                {
                    ToShow += $"{node.Data} ";
                    node = node.Next;
                }
                Console.WriteLine(ToShow);
            }
            else
                Console.WriteLine("Двунаправленный список пуст");
        } // Вывод списка 
        public bool Remove (int data)
        {
            
            Node node = head;

            // поиск удаляемого узла
            while (node != null)
            {
                if (node.Data==data)
                {
                    break;
                }
                node = node.Next;
            }
            if (node != null)
            {
                // если узел не последний
                if (node.Next != null)
                {
                    node.Next.Prev = node.Prev;
                }
                else
                {
                    // если последний, переустанавливаем tail
                    tail = node.Prev;
                }

                // если узел не первый
                if (node.Prev != null)
                {
                    node.Prev.Next = node.Next;
                }
                else
                {
                    // если первый, переустанавливаем head
                    head = node.Next;
                }
                Count--;
                return true;
            }
            return false;
        } // Удаление элемента из списка 
        public bool Search (int data)
        {
            Node node = head; 
            while (node != null)
            {
                if (node.Data == data)
                    return true;
                node = node.Next;
            }
            return false;
        } // Поиск элемента в списке  

    }
}
