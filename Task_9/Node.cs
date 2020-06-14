using System;
using System.Collections.Generic;
using System.Text;

namespace Task_9
{
    class Node
    {
        public int Data { get; set; }
        public Node Next { get; set; }
        public Node Prev { get; set; }
        public Node (int data)
        {
            Data = data;
        }
    }
}
