using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

namespace Task_6
{
    class Program
    {
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
                    if (a < 3)
                    {
                        Console.WriteLine("Минимальная дляна последовательности равна 3");
                        ok = false;
                    }
                       
                }
                catch
                {
                    Console.WriteLine("Введите натуральное число");
                    ok = false;
                }
            } while (!ok);
            return a;
        }           // Ввод натурального числа
        static string result = null;
       
        
        static void Culc(double first,double second,double third, double last,int N,ref bool IsRised,ref bool IsEqRised)
        {
            if (second + 2 == 0)
            {
                IsRised = true;
                IsEqRised = false;
                Console.WriteLine($"Невозможно вычеслить {N+3} член последовательности последовательность");
                return;
            }
            double current = (third + 1) / (second + 2) * first;
            
            if (current == last)
                IsRised = false;
            if (current < last)
            {
                IsRised = false;
                IsEqRised = false;
            }
            N--;
            Console.Write(Math.Round(current,2)+" ");
            if (N > 0)
                Culc(second, third, current,current, N, ref IsRised,ref IsEqRised);
            
        } 
        static void Main(string[] args)
        {
            bool IsRised = true; // Флажок на строговозрастающую последовательность
            bool IsEqRised = true; // Флажок на неубывающаю последовательность  
            Console.WriteLine("Введите первые три элемента последовательности");
            double a1 = Doub("Введите a1");
            double a2 = Doub("Введите a2");
            double a3 = Doub("Введите a3");
            // Проверяем монотонность введённых числа 
            if (a1 > a2)
            {
                IsRised = false; 
                IsEqRised = false;
            }
            if (a1 == a2)
                IsRised = false;
            if (a2 > a3)
            {
                IsRised = false;
                IsEqRised = false;
            }
            if (a2 == a3 )
                IsRised = false;
            // Конец проверки на монотонность 
            int N = Input("Введите количество элементов последовательности"); 
            N -= 3;
            Console.WriteLine();
            Console.Write(a1 + " ");
            Console.Write(a2 + " ");
            Console.Write(a3 + " ");
            if (N != 0)
            {
                Culc(a1, a2, a3, a3, N, ref IsRised, ref IsEqRised); // Вычисляем члены последовательности и определяем её монотонность
            }
          
           
            if (IsRised==false && IsEqRised==false)
                Console.WriteLine("Последовательность не является ни строго возрастающая, ни монотонно неубывающей");
            else if (IsEqRised==true && IsRised==false)
                Console.WriteLine("Последовательность монотонно неубывающая");
            else if(IsEqRised==false && IsRised == true)
            {

            }
            else
                Console.WriteLine("Последовательность монотонно возрастающая");







        }
    }
}
