using System;

namespace Task_9
{
    class Program
    {
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
                    if (a <= 0)
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
        }   // Ввод положительного числа 
        static void Menu()
        {
            Console.WriteLine("1. Создать двунаправленный список\n2. Вывести двунаправленный список\n3. Удалить элемент из двунаправленного списка\n4. Найти элемент в двунаправленном списке\n5. Выход");
        } // Меню
        static bool DoExict(DoublyLinkedList list)
        {
            if (list == null)
            {
                Console.WriteLine("Двунаправленный список не создан");
                return false;
            }
            return true;

        } // Определяет существование двунаправленного списка
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
            int choice = 0;
            DoublyLinkedList dli = null;
            do
            {
                Menu();
                choice = InputRange(1, 5);
                switch (choice)
                {
                    case 1:// Создание двунаправленного списка
                        {
                            dli = new DoublyLinkedList(Input("Введите количество элементов в двунаправленном списке"));
                        }
                        break;

                    case 2: // Вывод двунаправленного списка
                        {
                            if (DoExict(dli))
                            {
                                dli.Show();
                            }                               
                        }
                        break;

                    case 3: // Удаление элемента из двунаправленного списка
                        {
                            if (DoExict(dli))
                            {
                                int forDelete = Input("Введите информационное поле элемента, который вы хотите удалить");
                                bool IsDelited = dli.Remove(forDelete);
                                if (IsDelited)
                                    Console.WriteLine($"Элемент {forDelete} удалён");
                                else
                                    Console.WriteLine($"Элемената {forDelete} нет в списке");
                            }
                        }
                        break;

                    case 4: // Поиск элемента в двунаправленном списке
                        {
                            if (DoExict(dli))
                            {
                                int forSearch = Input("Введите информационное поле элемента, который вы хотите найти");
                                bool IsSearched = dli.Search(forSearch);
                                if (IsSearched)
                                    Console.WriteLine($"Элемент {forSearch} найден");
                                else
                                    Console.WriteLine($"Элемената {forSearch} нет в списке");
                            }
                        }
                        break;
                }
            } while (choice != 5);

       
        
        
        }
    }
}
