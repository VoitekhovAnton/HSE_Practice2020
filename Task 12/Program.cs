using System;
using System.Reflection.Metadata;
using System.Diagnostics;

namespace Task_12
{
    class Program
    {
        public static void Show(int [] mas)
        {
            foreach (int x in mas)
                Console.Write(x + " ");
        }
        static void Main(string[] args)
        {
            
            Random rnd = new Random();
            const int N = 100;
            int[] IncreasingArr = new int[N];
            int[] DecreasingArr = new int[N];
            int[] RandomArr = new int[N];
            for (int i = 0; i < N; i++)
            {
                IncreasingArr[i] = i + 1;
            }  
            for (int i = 0; i < N; i++)
            {
                DecreasingArr[i] = N-i;
            }               
            for (int i = 0; i < N; i++)
            {
                RandomArr[i] = rnd.Next(-100, 100);
            }
            
            // Демонстрация блочной сортировки для отсортированного массива 
            Console.WriteLine("Блочная сортировка массива, элементы которого расположены по возрастанию");
            Console.WriteLine("До:");
            Show(IncreasingArr);
            Console.WriteLine();
            Console.WriteLine("После:");           
            IncreasingArr = BucketSort.SortArr(IncreasingArr).ToArray();
            Show(IncreasingArr);
            Console.WriteLine();
            Console.WriteLine($"Количество созданных блоков:{BucketSort.CountBuckets}");
            Console.WriteLine();
            //Демнострация блочной сортировки для массива отсортированного по убыванию
            Console.WriteLine("Блочная сортировка массива, элементы которого расположены по убыванию");
            Console.WriteLine("До:");
            Show(DecreasingArr);
            Console.WriteLine();
            Console.WriteLine("После:");          
            DecreasingArr = BucketSort.SortArr(DecreasingArr).ToArray();                   
            Show(DecreasingArr);
            Console.WriteLine();
            Console.WriteLine($"Количество созданных блоков:{BucketSort.CountBuckets}");
            Console.WriteLine();
            //Демнострация блочной сортировки для не отсортированного массива 
            Console.WriteLine("Блочная сортировка неотсортированного массива");
            Console.WriteLine("До:");
            Show(RandomArr);
            Console.WriteLine();
            Console.WriteLine("После:");  
            RandomArr = BucketSort.SortArr(RandomArr).ToArray();   
            Show(RandomArr);
            Console.WriteLine();
            Console.WriteLine();
            // Перезаполнение массивов
            for (int i = 0; i < N; i++)
            {
                IncreasingArr[i] = i + 1;
            }
            for (int i = 0; i < N; i++)
            {
                DecreasingArr[i] = N - i;
            }
            for (int i = 0; i < N; i++)
            {
                RandomArr[i] = rnd.Next(-100, 100);
            }
            // Быстрая сортировка для массива отсортированного по возрастанию
            Console.WriteLine("Быстрая сортировка для массива отсортированного по возрастанию");
            Console.WriteLine("До:");
            Show(IncreasingArr);
            Console.WriteLine();
            Console.WriteLine("После:");
            QuickSorting.StartSorting(IncreasingArr,0,IncreasingArr.Length-1);
            Show(IncreasingArr);
            Console.WriteLine();
            Console.WriteLine($"Количество перестоновок: {QuickSorting.CountSwap}");
            //Быстрая сортировка для массива отсортированного по убыванию
            Console.WriteLine("Быстрая сортировка для массива отсортированного по убыванию");
            Console.WriteLine("До:");
            Show(DecreasingArr);
            Console.WriteLine();
            Console.WriteLine("После");
            QuickSorting.StartSorting(DecreasingArr,0,DecreasingArr.Length-1);
            Show(DecreasingArr);
            Console.WriteLine();
            Console.WriteLine($"Количество перестоновок: {QuickSorting.CountSwap}");
            // Быстрая сортировка для неотсортированного массива 
            Console.WriteLine("Быстрая сортировка для неотсортированного массива");
            Console.WriteLine("До:");
            Show(RandomArr);
            Console.WriteLine();
            Console.WriteLine("После:");
            QuickSorting.quicksort(RandomArr, 0, RandomArr.Length - 1);
            Show(RandomArr);
            Console.WriteLine();
            Console.WriteLine($"Количество перестоновок: {QuickSorting.CountSwap}");

        }
    }
}
