using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.Text.Json.Serialization;

namespace Тест
{
    class Program
    {
        static void Main(string[] args)
        {
            string jsonString = "{\r\n  \"Код товара\": 1,\r\n  \"Название товара\": \"a\",\r\n  \"Цена товара\": 125\r\n}";
            Product product = JsonSerializer.Deserialize<Product>(jsonString);
            Console.WriteLine(product.NameProduct);
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