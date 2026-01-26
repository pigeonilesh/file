using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace pr1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string file = "моя_биография.txt";
            using (StreamWriter wr = new StreamWriter(file))
            {
                wr.WriteLine($"- Меня зовут Иван");
                wr.WriteLine($"- Мне 20 лет");
                wr.WriteLine($"- Я учусь программированию");
                wr.WriteLine($"- Мое хобби Brawl Stars");
                wr.WriteLine($"- Мечтаю стать разработчиком");
            }
            using (StreamReader sr = new StreamReader(file))
            {
                int koll = 1;
                string line;
                //Читаем строку за строкой, пока не достигнем конца
                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine($"Строка {koll}: {line}");
                    koll++;
                }
            }
            int kol = 1;
            using (StreamReader sr = new StreamReader(file))
            {
                string line = sr.ReadLine();
                while ((line = sr.ReadLine()) != null)
                {
                    kol++;
                }
            }
            Console.WriteLine($"Общее число строк в документе = {kol}");
        }
    }
}
