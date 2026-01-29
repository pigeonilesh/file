using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                        Console.WriteLine();
                        break;
                    case 2:
                        List<string> list1 = new List<string>();
                        using (StreamReader sr = new StreamReader(file))
                        {
                            string line;
                            while ((line = sr.ReadLine()) != null)
                            {
                                list1.Add(line);
                            }
                        }
                        Console.WriteLine($"Введите новый предмет");
                        string np = Console.ReadLine().Trim();
                        bool q = false;
                        for (int i = 0; i < list1.Count; i++)
                        {
                            string[] s = list1[i].Split('=');
                            if (s[0] == np)
                            {
                                q = true;
                                break;
                            }
                        }
                        if (q)
                        {
                            Console.WriteLine("Этот предмет уже существует!");
                        }
                        else
                        {
                            Console.WriteLine($"Введите оценку по предмету");
                            string noc = Console.ReadLine().Trim();
                            list1.Add($"{np}={noc}");
                            using (StreamWriter sw = new StreamWriter(filed))
                            {
                                for (int i = 0; i < list1.Count; i++)
                                {
                                    sw.WriteLine(list1[i]);
                                }
                            }
                            File.Delete(file);
                            File.Move(filed, file);
                            Console.WriteLine("Предмет добавлен.");
                        }
                        break;
                    case 3:
                        List<string> list2 = new List<string>();
                        using (StreamReader sr = new StreamReader(file))
                        using (StreamWriter sw = new StreamWriter(filed))
                        {
                            string line;
                            while ((line = sr.ReadLine()) != null)
                            {
                                list2.Add(line);
                            }
                            Console.WriteLine($"Введите предмет чтобы поменять оценку");
                            string pr = Console.ReadLine().Trim();
                            for (int i = 0; i < list2.Count; i++)
                            {
                                string[] s = list2[i].Split('=');
                                if (s[0].StartsWith(pr))
                                {
                                    Console.Write($"Напишите исправленную оценку: ");
                                    int oc = Convert.ToInt32(Console.ReadLine());
                                    list2[i] = $"{s[0]}={oc}";
                                    Console.WriteLine($"Оценка изменина");
                                }
                                sw.WriteLine(list2[i]);
                            }
                        }
                        File.Delete(file);
                        File.Move(filed, file);
                        Console.WriteLine();
                        Console.WriteLine($"Список обновлен");
                        break;
                    case 4:
                        List<string> list3 = new List<string>();
                        using (StreamReader sr = new StreamReader(file))
                        {
                            string line;
                            while ((line = sr.ReadLine()) != null)
                            {
                                list3.Add(line);
                            }
                            for (int i = 0; i < list3.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}. {list3[i]}");
                            }
                            Console.Write($"Введите номер строки для удаления: ");
                            int b = int.Parse(Console.ReadLine());
                            for (int i = 0; i < list3.Count; i++)
                            {
                                if (b == i + 1)
                                {
                                    list3.RemoveAt(i);
                                }
                            }
                        }
                        using (StreamWriter sw = new StreamWriter(filed))
                        {
                            for (int i = 0; i < list3.Count; i++)
                            {
                                sw.WriteLine(list3[i]);
                            }
                        }
                        File.Delete(file);
                        File.Move(filed, file);
                        Console.WriteLine($"Предмет удален");
                        break;
                    case 5:
                        List<string> list4 = new List<string>();
                        using (StreamReader sr = new StreamReader(file))
                        {
                            string line;
                            while ((line = sr.ReadLine()) != null)
                            {
                                list4.Add(line);
                            }
                        }
                        double sum = 0;
                        int kol = 0;
                        string maxpr = "";
                        int max = 0;
                        string minpr = "";
                        int min = 6;
                        for (int i = 0; i < list4.Count; i++)
                        {
                            string[] s = list4[i].Split('=');
                            int oc = int.Parse(s[1].Trim());
                            sum += oc;
                            kol++;
                            if (oc > max)
                            {
                                max = oc;
                                maxpr = s[0].Trim();
                            }
                            if (oc < min)
                            {
                                min = oc;
                                minpr = s[0].Trim();
                            }
                        }
                        if (kol > 0)
                        {
                            double average = sum / kol;
                            Console.WriteLine($"Средний балл: {average:F2}");
                            Console.WriteLine($"Лучший предмет: {maxpr} ({max})");
                            Console.WriteLine($"Худший предмет: {minpr} ({min})");
                        }
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
