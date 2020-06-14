using System;

namespace Task_99
{
    class Program
    {
        static void Main(string[] args) // КАК ОФОРМЛЯТЬ?
        {
            CircularLinkedList<string> cl = new CircularLinkedList<string>();
            cl.Add("a");
            cl.Add("b");
            cl.Add("c");
            cl.Add("d");
            cl.Add("e");
            Console.WriteLine(cl.CE_Rec()); 

        }
    }
}
