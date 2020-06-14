using System;
using System.Collections.Generic;
namespace Task_8
{
    class Program
    {
        static bool ContainsTheSameEdge(int From,int To, List<List<int>> matrixEdge) // Проверка на повторяющиеся рёбра 
        {
            for (int i = 0;i<matrixEdge[From].Count;i++)
            {
                if (matrixEdge[From][i] == To)
                    return false;
            }
            return true;
        }
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
                    if (a>up || a<down)
                        Console.WriteLine($"Введите число от {down} до {up}");
                }
                catch
                {
                    Console.WriteLine("Введите натуральное число от 1 до 3");
                }
            } while (!ok || a < down || a > up);
            return a;
        }                 // Запрашивает число из определённого диапазона
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
        }                           // Ввод натурального числа 
        static void ShowGraph(List<List<int>> matrixEdge)
        {
            Console.WriteLine("Ребра графа:");
            for (int i = 0; i < matrixEdge.Count; i++)
            {             
               for (int j = 0; j < matrixEdge[i].Count; j++)
                {
                    Console.WriteLine($"{i}->{matrixEdge[i][j]}");
                }
                
            }
        }     // Вывод рёбер графа
        static void Main(string[] args)
        {
            int choice = 0;
            do
            {
                Console.WriteLine("1. Создать граф вручную\n2. Сгенерировать случайный граф\n3. Выход");
                choice = InputRange(1, 3);
                switch (choice)
                {
                    case 1: // Создание графа вручную
                        {
                            Random rnd = new Random();
                            int N = Input("Введите количество вершин в графе");
                            List<List<int>> matrixEdge = new List<List<int>>(N);
                            if (N == 1)
                            {
                                Console.WriteLine("Граф является деревом, состоящим из одной вершины");
                            }
                            else
                            {
                                for (int i = 0; i < N; i++)                         // Выделяем память под рёбра
                                    matrixEdge.Add(new List<int>());

                                Graph graph = new Graph(N);
                                int Edges = Input("Введите количество рёбер в графе");

                                for (int i = 0; i < Edges; i++) // Добавленеи рёбер в граф 
                                {
                                    Console.WriteLine($"Номера вершин от 0 до  {N-1}");
                                    Console.WriteLine("Введите номер вершины, из которой выходит ребро: ");
                                    int from = InputRange(0, N - 1);
                                    Console.WriteLine("Введите номер вершины, в которую выходит ребро: ");
                                    int to = InputRange(0, N - 1);
                                    if (ContainsTheSameEdge(from, to, matrixEdge))
                                    {
                                        matrixEdge[from].Add(to);
                                        graph.addEdge(from, to);                                       
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Ребро {from}->{to} уже добавлено в граф");
                                    }
                                }

                                ShowGraph(matrixEdge);
                                bool isCon = graph.IsConnected();  // Проерка графа на связность и содержание циклов типа 1->1
                               
                                if (isCon)
                                {
                                    if (graph.isCyclic())          // Проверка графа на содержания циклов
                                        Console.WriteLine("Граф не является деревом");
                                    else
                                        Console.WriteLine("Граф является деревом");
                                }
                                else
                                    Console.WriteLine("Граф не является деревом");
                            }
                            }
                        break;
                    case 2: // Генерация случайного графа
                        {
                            Random rnd = new Random();
                            int N = rnd.Next(1,5);
                            List<List<int>> matrixEdge = new List<List<int>>(N); // Матрица вершин и рёбер
                            if (N == 1)
                            {
                                Console.WriteLine("Граф является деревом, состоящим из одной вершины");
                            }
                            else
                            {
                                for (int i = 0; i < N; i++)                         // Выделяем память под рёбра
                                    matrixEdge.Add(new List<int>());
                                Graph graph = new Graph(N);
                                Console.WriteLine($"Количество вершин в графе:{N}");
                                for (int i = 0; i < N - 1; i++)
                                {
                                    int from = rnd.Next(0, N);
                                    int to = rnd.Next(0, N);
                                    if (ContainsTheSameEdge(from, to, matrixEdge))
                                    {
                                        matrixEdge[from].Add(to);
                                        graph.addEdge(from, to);
                                        Console.WriteLine($"{from} -> {to}");
                                    }

                                }                                   // Генирация случайного графа  

                                bool isCon = graph.IsConnected();   // Проерка графа на связность и содержание циклов типа 1->1
                               
                                if (isCon)
                                {
                                    if (graph.isCyclic())// Проверка графа на содержания циклов
                                        Console.WriteLine("Граф не является деревом");
                                    else
                                        Console.WriteLine("Граф является деревом");
                                }
                                else
                                    Console.WriteLine("Граф не является деревом");
                            }
                        }
                        break;

                }
            } while (choice != 3);

           
           
            
        }
    }
}
