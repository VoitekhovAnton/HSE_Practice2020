using System;

namespace Practice
{
    class Program
    {
        // 60Б
        static double Doub(string str)             // Ввод действительного числа 
        {
            double a = 0;
            bool ok = true;
            do
            {
                try
                {
                    Console.WriteLine(str);
                    a = Double.Parse(Console.ReadLine());
                    ok = true;
                }
                catch
                {
                    Console.WriteLine("Введите число");
                    ok = false;
                }
            } while (!ok);
            return a;
        }
        static bool InArea(double x, double y)
        {           
            if (x * x + Math.Pow(y - 1, 2) <= 1 && y <= 1 - x * x)
                return true;
            else
                return false;
        } // Проверка на принадлежность выделенной области 
        static void Main(string[] args)
        {
            double x = Doub("Введите координату X");
            double y = Doub("Введите координату Y");
            if(InArea(x, y))
                Console.WriteLine($"Точка с координатами ({x};{y}) принадлежит заштрихованной области. U = -3");
            else
                Console.WriteLine($"Точка с координатами ({x};{y}) не принадлежит заштрихованной области. U = {Math.Pow(y,2)}");

        }
    }
}
