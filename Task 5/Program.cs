using System;
using System.ComponentModel;
using System.Numerics;
using System.Runtime.InteropServices;

namespace Task_5
{
    class Program
    {
        // 692И
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
                  
                }
                catch
                {
                    Console.WriteLine("Введите натуральное число");
                    ok = false;
                }
            } while (!ok);
            return a;
        }        // Ввод натурального числа 
        static void FillMatrix(double [,] mas)
        {
            Random rnd = new Random();
            for (int i = 0; i < mas.GetLength(0); i++)
            {
                for(int j = 0; j < mas.GetLength(1); j++)
                {
                    mas[i, j] = rnd.Next(-10, 10);
                }
            }
        }// Заполнение матрицы рандомными числами 
        static double FindMax(double [,] mas)
        {
            int k = 0;
            double max = mas[mas.GetLength(0)-1, 0];
            for (int i = 0; i < mas.GetLength(0) - 1; i++)
            {
                for (int j = 0; j < mas.GetLength(1) - k; j++)
                {
                    if (mas[i, j] > max)
                        max = mas[i, j];
                }
                k++;
            }
            return max;
        } // Нахождение максимального элемента над главной диогональю 
        static void ShowMatrix(double[,] mas)
        {
            for (int i = 0; i < mas.GetLength(0); i++)
            {
                for (int j = 0; j < mas.GetLength(1); j++)
                {
                    Console.Write(string.Format("{0,6}", mas[i, j] + " "));
                }
                Console.WriteLine();
            }
        } // Вывод матрирцы 
        static void FillMatrixKeyBoard(double[,] mas)
        {
            for (int i = 0; i < mas.GetLength(0); i++)
            {
                for (int j = 0; j < mas.GetLength(1); j++)
                {
                    mas[i, j] = Doub($"Введите A[{i},{j}]");
                }
                Console.WriteLine();
            }
        } // Заполнение матрицы с клавиатуры 
        static int InputRange(int down, int up)
        {

            int a = 0;
            bool ok = true;
            do
            {
                try
                {
                    a = int.Parse((Console.ReadLine()));
                    if (a < 0)
                    {
                        ok = false;
                    }
                    if (a > up || a < down)
                        Console.WriteLine($"Введите число от {down} до {up}");
                }
                catch
                {
                    Console.WriteLine("Введите натуральное число от 1 до 3");
                }
            } while (!ok || a < down || a > up);
            return a;
        }     // Запрашивает число из определённого диапазона

        static void Main(string[] args) 
        {
            int choice = 0;
            do
            {
                Console.WriteLine("1.Заполнить матрицу вручную\n2.Заполнить матрицу случайными числами\n3.Выход");
                choice = InputRange(1, 3);
                switch (choice)
                {
                    case 1: // Заполнение вручную
                        {
                            int n = Input("Введите порядок матрицы");
                            if (n > 0)
                            {
                                double[,] mas = new double[n, n];
                                FillMatrix(mas);
                                ShowMatrix(mas);
                                Console.WriteLine($"Наибольший из элементов находящихся над главной диогональю равен {FindMax(mas)}");
                            }
                            else
                                Console.WriteLine("Матрица пустая");

                        }
                        break;
                    case 2: // Заполнение случайными числами
                        {
                            int n = Input("Введите порядок матрицы");
                            if (n > 0)
                            {
                                double[,] mas = new double[n, n];
                                FillMatrix(mas);
                                ShowMatrix(mas);
                                Console.WriteLine($"Наибольший из элементов находящихся над главной диогональю равен {FindMax(mas)}");
                            }
                            else
                                Console.WriteLine("Матрица пустая");

                        }
                        break;
                }
            } while (choice != 3);
          

           
        }
    }
}
