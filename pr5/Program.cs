using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace pr5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string file = "C:\\Users\\ilyan\\Documents\\Учет_Предметов.txt";
            string filed = "C:\\Users\\ilyan\\Documents\\Учет_Предметовd.txt";
            if (!File.Exists(file))
            {
                using (StreamWriter sw = new StreamWriter(file))
                {
                }
                Console.WriteLine($"Файл создан");
            }
            int a = 0;
            while (a != 6)
            {
                Console.WriteLine($"МЕНЮ ПРОГРАММЫ");
                Console.WriteLine($"1. Показать все предметы и оценки");
                Console.WriteLine($"2. Добавить новый предмет");
                Console.WriteLine($"3. Изменить оценку по предмету");
                Console.WriteLine($"4. Удалить предмет");
                Console.WriteLine($"5. Посчитать средний балл");
                Console.WriteLine($"6. Выход");
                Console.Write($"Выберите действие: ");
                a = int.Parse(Console.ReadLine());
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
                            Console.WriteLine($"Введите новый предмет");
                            sw.Write($"{Console.ReadLine().Trim()}=");
                            Console.WriteLine($"Введите оценку по предмету");
                            sw.Write($"{Console.ReadLine().Trim()}");
                            sw.WriteLine($"");
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
                        Console.WriteLine($"Введите предмет чтобы поменять оченку");
                        string pr = Console.ReadLine();
                        using (StreamReader sr = new StreamReader(file))
                        using (StreamWriter sw = new StreamWriter(filed))
                        {
                            string line;
                            while ((line = sr.ReadLine()) != null)
                            {
                                string[] s = line.Split('=');
                                if (s[0].StartsWith(pr))
                                {
                                    line = $"{s[0]}={int.Parse(Console.ReadLine())}";
                                    Console.WriteLine($"Оценка изменина");
                                }
                                sw.WriteLine(line);
                            }
                        }
                        File.Delete(file);
                        File.Move(filed, file);
                        Console.WriteLine($"Предметы обновлены");
                        using (StreamReader sr = new StreamReader(file))
                        {
                            Console.WriteLine(sr.ReadToEnd());
                        }
                        break;
                    case 4:

                        break;
                    case 5:
                        
                        break;
                    case 6:
                        Console.WriteLine("Выход из программы.");
                        break;
                    default:
                        Console.WriteLine("Неверный выбор. Введите число от 1 до 6");
                        break;
                }
            }
        }
    }
}
