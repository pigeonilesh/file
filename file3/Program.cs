using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;

namespace file3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //первый код

            //Указываем имя файл. Создается в одной папке с программой.
            string filename = "Приветствие.txt";
            //Используем конструкцию using, которая автоматически закрывает поток
            using (StreamWriter sw = new StreamWriter(filename))
            {
                //Записываем первую строку
                sw.WriteLine($"Привет! Это мой первый файл в C#");
                //Записываем вторую строку
                sw.WriteLine($"Дата создания файла: {DateTime.Now}");
                //Записываем третью строку без перехода на новую строку
                sw.Write($"Этот текст ");
                sw.Write($"будет записан на одной строке ");
                Console.WriteLine($"Данные успешно записаны");
            }
            //После выхода из блока using поток автоматически закрывается
            //Все данные гарантированно записаны на диск
            
            //третий код
            
            Console.WriteLine($"Добавляем данные в конец файла");
            //Второй параметр true дает возможность дополнить текстовый файл
            //По умолчанию передается false, в таком случае файл перезаписывается
            using(StreamWriter sw = new StreamWriter(filename, true))
            {
                sw.WriteLine("\n=== Новая запись ===");
                sw.WriteLine($"Дата: {DateTime.Now}");
                sw.WriteLine($"Сегодня я научился работать с файлами в C#");
                sw.WriteLine($"Это очень полезный навык для програмиста");

                Console.WriteLine($"Данные успешно добавлены в конец файла");
            }
            //Показываем обновленный файл
            using(StreamReader sr = new StreamReader(filename))
            {
                Console.WriteLine(sr.ReadToEnd());
            }
        }
    }
}
