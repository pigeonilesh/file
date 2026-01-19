using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

//Создание и запись в файл

namespace file
{
    internal class Program
    {
        static void Main(string[] args)
        {
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
        }
    }
}
