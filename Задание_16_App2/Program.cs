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
            string name = "Products.json";
            string path = path1 + "\\" + name;
            //nP - название самого дорогого товара, pP - цена товара
            string nP = "";
            double pP = 0;
            using (StreamReader sr = new StreamReader(path))
            {
                string jsonString = sr.ReadToEnd();
                Console.WriteLine(jsonString);
                string group = "";
                string[] a = jsonString.Split('\r', '\n');
                foreach (string n in a)
                {
                    group += n;
                }
                string[] array = group.Split('}');
                foreach (string n in array)
                {
                    if (n != " ")
                    {
                        string jS = n + '}';
                        Product product = JsonSerializer.Deserialize<Product>(jS);
                        if (product.PriceProduct > pP)
                        {
                            pP = product.PriceProduct;
                            nP = product.NameProduct;
                        }
                    }
                }
            }
            Console.WriteLine("Самый дорогой товар: {0}", nP);
            Console.WriteLine("Для завершения программы нажмите любую клавишу.");
            Console.ReadKey();
        }
    }
    class Product
    {
        [JsonPropertyName("Код товара")]
        public int CodeProduct { get; set; }
        [JsonPropertyName("Название товара")]
        public string NameProduct { get; set; }
        [JsonPropertyName("Цена товара")]
        public double PriceProduct { get; set; }
    }
}
