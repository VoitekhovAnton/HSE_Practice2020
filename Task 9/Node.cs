using System;
using System.Collections.Generic;
using System.Text;

namespace Task_99
{
    class Node<T> // Класс узла 
    {
        public T Data { get; set; }
        public Node (T data)
        {
            Data = data;
        }
        public Node<T>  Next { get; set; }
    }
}
