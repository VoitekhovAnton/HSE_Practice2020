using System;
using System.ComponentModel;
using System.Globalization;
using System.Numerics;

namespace Task_11
{
    class Program
    {
        static void FillRandom (string [,] matrix)
        {
            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            Random rnd = new Random();
            for (int i = 0; i < matrix.GetLength(0); i++) // Заполнение матрицы числами от 1 до 121
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    //matrix[i, j] = $"{i * 11 + j+1}";
                    matrix[i, j] = alphabet[rnd.Next(0, 25)].ToString();
                        
                        
                }
            }
        }
        static void FillKeyboard(string [,] mas)
        {
           
            for (int i = 0; i < mas.GetLength(0); i++)
            {
                for (int j = 0;j< mas.GetLength(1); j++)
                {
                    mas[i, j] = Console.ReadLine();
                  
                }
            }
        }
        static void ShowMatrix(string [,] mas)
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
                }
                catch
                {
                    Console.WriteLine("Введите натуральное число от 1 до 3");
                }
            } while (!ok || a < down || a > up);
            return a;
        }  // Запрашивает число из определённого диапазона
        static void Main(string[] args)
        {
            string[,] matrix = new string[11, 11];
            int choice =0;
            do
            {
                Console.WriteLine("1.Заполнить матрицу вручную\n2.Заполнить матрицу случайными буквами\n3.Выход");
                choice = InputRange(1, 3);
                switch (choice)
                {
                    case 1:
                        {
                            FillKeyboard(matrix);
                            ShowMatrix(matrix);
                            string result = null;
                            int RowRight = 6;   // Правая граница спирали 
                            int RowLeft = 4;    // Левая граница спирали
                            int upLine = 4;     // Верхняя граница спирали
                            int downLine = 6;   // Нижняя граница спирали
                            result += matrix[5, 5] + " "; // Центральный элемент 
                            while (upLine >= 0)
                            {
                                for (int i = upLine + 1; i <= downLine - 1; i++) // Бокавая левая часть спирали
                                {
                                    result += matrix[i, RowRight] + " ";
                                }
                                for (int i = RowRight; i >= RowLeft; i--) // Нижняя часть спирали
                                {
                                    result += matrix[downLine, i] + " ";
                                }
                                for (int i = downLine - 1; i >= upLine + 1; i--) // Боковая левая часть спирали
                                {
                                    result += matrix[i, RowLeft] + " ";
                                }
                                for (int i = RowLeft; i <= RowRight; i++) // Верхняя часть спирали 
                                {
                                    result += matrix[upLine, i] + " ";
                                }
                                RowRight++;
                                RowLeft--;
                                upLine--;
                                downLine++;
                            }
                            Console.WriteLine(result);
                        }
                        break;
                    case 2:
                        {
                            FillRandom(matrix);
                            ShowMatrix(matrix);
                            string result = null;
                            int RowRight = 6;   // Правая граница спирали 
                            int RowLeft = 4;    // Левая граница спирали
                            int upLine = 4;     // Верхняя граница спирали
                            int downLine = 6;   // Нижняя граница спирали
                            result += matrix[5, 5] + " "; // Центральный элемент 
                            while (upLine >= 0)
                            {
                                for (int i = upLine + 1; i <= downLine - 1; i++) // Бокавая левая часть спирали
                                {
                                    result += matrix[i, RowRight] + " ";
                                }
                                for (int i = RowRight; i >= RowLeft; i--) // Нижняя часть спирали
                                {
                                    result += matrix[downLine, i] + " ";
                                }
                                for (int i = downLine - 1; i >= upLine + 1; i--) // Боковая левая часть спирали
                                {
                                    result += matrix[i, RowLeft] + " ";
                                }
                                for (int i = RowLeft; i <= RowRight; i++) // Верхняя часть спирали 
                                {
                                    result += matrix[upLine, i] + " ";
                                }
                                RowRight++;
                                RowLeft--;
                                upLine--;
                                downLine++;
                            }
                            Console.WriteLine(result);
                        }
                        break;
                }
            } while (choice != 3);

           
           
           
            
            
           
        }
    }
}
