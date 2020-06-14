using System;
using System.Collections.Generic;
using System.Text;

namespace Task_12
{
    class QuickSorting
    {

        public static int CountSwap { get; private set; }

        public static void StartSorting(int[] arr, int first, int last)
        {
            CountSwap = 0;
            quicksort( arr,first,last);
        }


        public static void sorting(int [] arr, long first, long last) // Быстрая сортировка рекурсией 
        {
            double p = arr[(last - first) / 2 + first]; // Элемент для сравнения во время сортировки 
            int temp;
            long i = first, j = last;
            while (i <= j)
            {
                while (arr[i] < p && i <= last) ++i; // Ищем индекс большоого элемента в маленькой части массива 
                while (arr[j] > p && j >= first) --j;// Ищем индекс маленького элемента в большой части массива 
                if (i < j) 
                {
                    temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                    ++i; --j;
                    CountSwap++; 
                }
            }
            if (j > first) sorting(arr, first, j);
            if (i < last) sorting(arr, i, last);
        }

       static int partition(int[] array, int start, int end)
        {
            int temp;// Временное место хранения элемента 
            int marker = start;//делит левый и правый подмассив

            for (int i = start; i < end; i++)
            {
                if (array[i] < array[end]) 
                {
                    if (i != marker)
                        CountSwap++;
                    temp = array[marker]; 
                    array[marker] = array[i];
                    array[i] = temp;
                    marker += 1;
                }
            }
           // Помещаем элемент для сравнения между подмассивами
            temp = array[marker];
            array[marker] = array[end];
            array[end] = temp;
            return marker;
        }

       public static void quicksort(int[] array, int start, int end)
        {
            if (start >= end)
            {
                return;
            }
            int pivot = partition(array, start, end);
            quicksort(array, start, pivot - 1);
            quicksort(array, pivot + 1, end);
        }

    }
}
