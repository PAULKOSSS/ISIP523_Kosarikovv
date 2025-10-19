using System;
using System.Collections.Generic;

class Pr3 
{
    class Characteristic
    {
        public string text;
        public int wordsCount = 0;
        public string shortestWord = "";
        public int sentencesCount = 0;
        public int consonant = 0;
        public int vowel = 0;
        public string longestWord = "";
        Dictionary<char, int> azbyka = new Dictionary<char, int>();


        static List<Characteristic> textHistory = new List<Characteristic>();

    }

    static void Main(string[] args)
    {
        Characteristic stats = new Characteristic();
        bool continueWorking = true;

        Console.WriteLine("Программа для анализа текста");

        while (continueWorking)
        {

            stats.TextAdd();
            if (stats.text == null)
            {
                Console.WriteLine("Не удалось получить текст. Попробуйте снова.");
                continue;
            }


            stats.CalculateAllStats();

            stats.StatsOutput();


            Console.WriteLine("Выберите действие:");
            Console.WriteLine("1 - Проанализировать другой текст");
            Console.WriteLine("2 - Показать историю текстов");
            Console.WriteLine("3 - Выйти из программы");
            Console.Write("Ваш выбор: ");

            string answer = Console.ReadLine();

            if (answer == "3")
            {
                continueWorking = false;
            }
            else if (answer == "2")
            {
                Characteristic.ShowHistory();
                Console.Write("Нажмите любую клавишу для продолжения...");
                Console.ReadKey();
                stats.ClearAllStats();
                Console.Clear();
            }
            else
            {
                stats.ClearAllStats();
                Console.Clear();
            }
        }

        Console.WriteLine("Программа завершена. Спасибо за использование!");
    }
    }

