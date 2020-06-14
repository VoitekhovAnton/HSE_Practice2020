using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Formatters;
using System.Text;

namespace Task_12
{
    class BucketSort
    {
        public static int  CountBuckets { get; private set; }
       // Список для отсортированного массива 
        public static List<int> SortArr(int[] mas)
        {
            CountBuckets = 0;
            List<int> sortedArray = new List<int>();
            if (mas.Length > 1)
            {
                int numOfBuckets;
               
                int max = mas[0];
                int min = mas[0];
                for (int i = 0; i < mas.Length; i++)
                {
                    if (mas[i] > max)
                        max = mas[i];
                    if (mas[i] < min)
                        min = mas[i];
                }
                numOfBuckets =max-min+1;
                CountBuckets = numOfBuckets;
                // Выделяю место для блоков заполняю блоки 
                List<int>[] BucketsList = new List<int>[numOfBuckets];
                for (int i = 0; i < numOfBuckets; i++)
                {
                    BucketsList[i] = new List<int>();
                }
                // Заполняю блоки
                for (int i = 0; i < mas.Length; i++)
                {
                    BucketsList[mas[i] - min].Add(mas[i]);
                }
                
               // Добавляем непустые блоки в исходный массив 
                for(int i = 0; i < BucketsList.Length; i++)
                {
                   if (BucketsList[i].Count > 0)
                    {
                        for (int j = 0; j < BucketsList[i].Count; j++)
                        {
                           sortedArray.Add(BucketsList[i][j]);
                        }
                    }
                }

            }
            else
            {
                sortedArray.Add(mas[0]);
            }
            return sortedArray;
        }
        
        
        

    }

    
}


  
