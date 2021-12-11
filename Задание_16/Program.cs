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

namespace Задание_16
{
    class Program
    {
        /*Необходимо разработать программу для записи информации о товаре в текстовый файл в формате json.
         Разработать класс для моделирования объекта «Товар». Предусмотреть члены класса «Код товара» (целое число), «Название товара» (строка), «Цена товара» (вещественное число).
         Создать массив из 5-ти товаров, значения должны вводиться пользователем с клавиатуры.
         Сериализовать массив в json-строку, сохранить ее программно в файл «Products.json».*/
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Введите директорию любой папки на своем компе, в которой будет создан файл \"Products.json\":");
                string pathCatalogue = Console.ReadLine();
                string fileName = "Products.json";
                string path = pathCatalogue + "\\" + fileName;
                Console.WriteLine("Введите последовательно информацию о пяти товарах со свойствами \"Код товара\", \"Название товара\", \"Цена товара\":");
                string[] goods = new string[5];
                for (int i = 0; i < 5; i++)
                {
                    Product x = new Product()
                    {
                        CodeProduct = Convert.ToInt32(Console.ReadLine()),
                        NameProduct = Console.ReadLine(),
                        PriceProduct = Convert.ToDouble(Console.ReadLine())
                    };
                    JsonSerializerOptions options = new JsonSerializerOptions()
                    {
                        Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                        WriteIndented = true
                    };
                    string jsonString = JsonSerializer.Serialize(x, options);
                    using (StreamWriter sw = new StreamWriter(path, true))
                    {
                        sw.WriteLine("{0} ", jsonString);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("Для завершения программы нажмите любую клавишу.");
            Console.ReadKey();
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
}
