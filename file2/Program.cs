using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace file2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filename = "Приветствие.txt";
            //Проверяем существует ли файл
            if (!File.Exists(filename))
            {
                Console.WriteLine($"Файл не найден");
                return;//Выход из программы
            }
            //Способ 1 чтение всего файла целиком
            using(StreamReader sr = new StreamReader(filename))
            {
                string alltetx = sr.ReadToEnd();//Присваеваем переменной текст файла
                Console.WriteLine(alltetx);
            }
            Console.WriteLine();
            //Способ 2 чтение файла построчно
            using(StreamReader sr = new StreamReader(filename))
            {
                int lines = 1;
                string line;
                //Читаем строку за строкой, пока не достигнем конца
                while((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine($"Строка {lines}: {line}");
                    lines++;
                }
            }
            //Способ 3 чтение посимвольно
            using(StreamReader sr = new StreamReader(filename))
            {
                Console.WriteLine($"Первые 20 символов");
                for (int i = 1; i <= 20; i++)
                {
                    int charcode = sr.Read();
                    if (charcode == 0)
                    {
                        break;
                    }
                    char symbol = (char)charcode;
                    Console.WriteLine(symbol);
                }
                Console.WriteLine();
            }
        }
    }
}
