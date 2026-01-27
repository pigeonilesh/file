using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Web;

namespace pr3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string file = "C:\\Users\\232415\\Desktop\\Покупки.txt";
            string filed = "C:\\Users\\232415\\Desktop\\Покупкиd.txt";
            if (!File.Exists(file))
            {
                using (StreamWriter sw = new StreamWriter(file))
                {
                }
                Console.WriteLine($"Файл создан");
            }

            Console.WriteLine($"СПИСОК ПОКУПОК");
            Console.WriteLine($"1. Показать список покупок");
            Console.WriteLine($"2. Добавить покупку");
            Console.WriteLine($"3. Отметить покупку выполненной");
            Console.WriteLine($"4. Очистить список");
            Console.WriteLine($"5. Выход");
            Console.Write($"Выберите действие: ");
            int a = int.Parse(Console.ReadLine());
            Console.WriteLine();
            switch (a)
            {
                case 1:
                    using (StreamReader sr = new StreamReader(file))
                    {
                        Console.WriteLine(sr.ReadToEnd());
                    }
                break;
                case 2:
                    using (StreamWriter sw = new StreamWriter(file, true))
                    {
                        sw.WriteLine($"[] {Console.ReadLine()}");
                    }
                break;
                case 3:
                    List<string> list = new List<string>();
                    using (StreamReader sr = new StreamReader(file))
                    {
                        string line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            list.Add(line);
                        }
                    }
                    Console.WriteLine($"Введите совершенную покупку");
                    string pok = Console.ReadLine();
                    using (StreamReader sr = new StreamReader(file))
                    using (StreamWriter sw = new StreamWriter(filed))
                    {
                        string line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            string[] s = line.Split(' ');
                            if (s[1].StartsWith(pok))
                            {
                                line = $"[x] {s[1]}";
                                Console.WriteLine($"Покупка отмечена");
                            }
                            sw.WriteLine(line);
                        }
                    }
                    File.Delete(file);
                    File.Move(filed, file);
                    Console.WriteLine($"Список обновлен");
                    using (StreamReader sr = new StreamReader(file))
                    {
                        Console.WriteLine(sr.ReadToEnd());
                    }
                break;
                case 4:
                    using (StreamReader sr = new StreamReader(file))
                    using (StreamWriter sw = new StreamWriter(filed))
                    {
                        string line = sr.ReadToEnd();
                        line = "";
                        sw.WriteLine(line);
                    }
                    File.Delete(file);
                    File.Move(filed, file);
                    Console.WriteLine($"Список очищен");
                break;
                    case 5: break;
            }
        }
    }
}
