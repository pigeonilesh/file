using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace pr2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string file = "C:\\Users\\232415\\Documents\\Дневник\\Дневник настроений.txt";
            DateTime now = DateTime.Now;
            Console.WriteLine("ДНЕВНИК НАСТРОЕНИЙ");
            Console.WriteLine(now.ToString("dd.MM.yyyy"));
            Console.Write($"Оцените свое настроение (1-5): ");
            int nas = int.Parse(Console.ReadLine());
            Console.Write($"Введите краткий комментарий: ");
            string kom = Console.ReadLine();
            using (StreamWriter sw = new StreamWriter(file, true))
            {
                sw.WriteLine($"[{now.ToString("dd.MM.yyyy")}] Настроение: {nas}/5 - {kom}");
                Console.WriteLine($"Запись добалена");
            }
        }
    }
}
