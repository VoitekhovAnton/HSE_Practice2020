using System;
using System.IO;
using System.Threading.Tasks;

namespace Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = null;
            int N = 0;
            string path = "INPUT.TXT";           
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    string str = sr.ReadLine();
                    N = Convert.ToInt32(str);
                }
            }
            catch
            {
                Console.WriteLine("Неверный формат входных данных");
            } // Считывание информации в файл

            text += "YES\n";
            double a = 0;
            for (int i = 0; i < N; i++, a += 2 * Math.PI / 300)
            {
                text += $"{Convert.ToInt32(Math.Cos(a) * 10000)} {Convert.ToInt32(Math.Sin(a) * 10000)}\n";
            }
            // Вывод результатов 
            string writePath = "OUTPUT.TXT"; // Путь к файлу
            try
            {
                using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default))
                {
                    sw.Write(text);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine(text);
        }
    }
}
