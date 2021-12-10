using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.Text.Json.Serialization;
using System.IO;


namespace Задание_16_App2
{
    class Program
    {
        /*Необходимо разработать программу для получения информации о товаре из json-файла.
        Десериализовать файл «Products.json» из задачи 1. Определить название самого дорогого товара.*/
        static void Main(string[] args)
        {
            Console.WriteLine("Введите полный путь к файлу:");
            string path1 = Console.ReadLine();
            string path2 = "Products.json";
            string path = path1 + "\\" + path2;
            using (StreamReader sr = new StreamReader(path))
            {
                string text = sr.ReadToEnd();
                string[] array = text.Split('\n');
                foreach (string row in rowArray)
                {
                    string[] wordArray = row.Split(' ');
                    wordNumber += wordArray.Length;
                }
                symbolNumber = text.Length;
            }
            using (StreamReader sr = new StreamReader(path))
            {
                string m = sr.ReadToEnd();
                string[] stringArray = m.Split();
                for (int i = 0; i < n; i++)
                {
                    int d = Convert.ToInt32(stringArray[i]);
                    sum += d;
                }
            }
            Console.WriteLine("Для завершения программы нажмите любую клавишу.");
            Console.ReadKey();
        }
    }
}
