using System;
using System.Diagnostics;
using System.IO;

namespace Lb_03
{
    internal class Program
    {
        private const string FILE_PATH = @"\file.txt";

        static void Main(string[] args)
        {
            Console.WriteLine("Введите искомое слово:");
            var word = Console.ReadLine();
            WriteString(1000, word);
            var text = ReadText();
            var rkSearcher = new RabinKarpSearcher();
            var sw = new Stopwatch();
            Console.WriteLine($"Исходная строка: {text}");
            sw.Start();
            var result = rkSearcher.Search(text, word);
            sw.Stop();
            Console.WriteLine($"Алгоритм Рабина-Карпа. Результат: {result}. Отработано за {sw.Elapsed.TotalMilliseconds} мс.");
            var kmpSearcher = new KnuthMorrisPrattSearcher();
            sw.Restart();
            var result2 = kmpSearcher.Search(text, word);
            Console.WriteLine($"Алгоритм Кнута Морриса Пратта. Результат: {result2}. Отработано за {sw.Elapsed.TotalMilliseconds} мс.");

            Console.ReadLine();
        }

        static void WriteString(int symbolCount, string barrierWord)
        {
            var random = new Random();
            var str = "";
            for (int i = 0; i < symbolCount; i++)
            {
                var symbolNumber = random.Next(1040, 1071);
                var symbol = (char)symbolNumber;
                str += symbol;
            }
            str += barrierWord;

            using (var sw = new StreamWriter(FILE_PATH, false))
            {
                sw.WriteLine(str);
            }
        }

        static string ReadText()
        {
            var str = "";
            using (var sr = new StreamReader(FILE_PATH))
            {
                str = sr.ReadToEnd();
            }

            return str;
        }
    }
}
