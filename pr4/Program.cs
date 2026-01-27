using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Web;

namespace pr4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string file = "C:\\Users\\232415\\Desktop\\Исходный.txt";
            string filed = "C:\\Users\\232415\\Desktop\\Обработанный.txt";
            if (!File.Exists(file))
            {
                using (StreamWriter sw = new StreamWriter(file))
                {
                    sw.WriteLine($"привет!");
                    sw.WriteLine($"как дела?");
                    sw.WriteLine($"");
                    sw.WriteLine($"хорошо");
                    sw.WriteLine($"");
                }
                Console.WriteLine($"Файл создан");
            }

            int kol = 0;
            using (StreamReader sr = new StreamReader(file))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    kol++;
                }
            }
            using (StreamReader sr = new StreamReader(file))
            using (StreamWriter sw = new StreamWriter(filed))
            { 
                List<string> list = new List<string>();
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    list.Add(line);
                }
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i] == "")
                    {
                        list.RemoveAt(i);
                    }
                }
                for (int i = 0; i < list.Count; i++)
                {
                    sw.WriteLine($"0{i+1}. {list[i].ToUpper()}");
                }
            }
            int koll = 0;
            using (StreamReader sr = new StreamReader(filed))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    koll++;
                }
            }
            Console.WriteLine($"Число строк в исходном документе: {kol}");
            Console.WriteLine($"Число строк в обработанном документе: {koll}");
            using (StreamReader sr = new StreamReader(filed))
            {
                Console.WriteLine(sr.ReadToEnd());
            }
        }
    }
}
