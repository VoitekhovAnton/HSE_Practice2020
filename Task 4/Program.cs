using System;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Transactions;

namespace Task_4
{
    class Program
    { // 119Д
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
                    if (a <= 0)
                    {
                        ok = false;
                        Console.WriteLine("Введите положительное число");
                    }                       
                  
                }
                catch
                {
                    Console.WriteLine("Введите число");
                    ok = false;
                }
            } while (!ok);
            return a;
        }
        static double Culc(double e)
        {
            double Sum = 0; // Сумма членов ряда
            int i = 0;      // Индекс
            double n = 0;   // i-ый член ряда 
            do
            {
                i++;
                n = Math.Pow(-1, i + 1) / (i * (i + 1) * (i + 2)); // Вычисляем n-ый член 
                Sum += n;

            } while (e <= Math.Abs(Sum));
            Sum -= Math.Pow(-1, i + 1) / (i * (i + 1) * (i + 2));
            
            return Sum;
        }
        static void Main(string[] args)
        {
            double e = Doub("Введите точность вычеслений");
            Console.WriteLine($"Сумма с точностью {e}: {Math.Round(Culc(e),3)} ") ;
        }
    }
}
