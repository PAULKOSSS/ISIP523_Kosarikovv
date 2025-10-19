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

        public void TextAdd()
        {
            Console.WriteLine("Введите текст (не менее 100 символов)");
            Console.WriteLine("Вводите текст построчно. Для завершения ввода введите пустую строку:");

            string input = "";
            string line;
            int totalLength = 0;


            while (!string.IsNullOrWhiteSpace(line = Console.ReadLine()))
            {
                input += line + "\n";
                totalLength += line.Length;



            }

            text = input.Trim();

            if (text.Length < 100)
            {
                Console.WriteLine("Вы ввели некорректный текст (менее 100 символов)");
                text = null;
            }
            else
            {
                Console.WriteLine($"Текст успешно принят! Длина: {text.Length} символов");
            }
        }



        void WordCount()
        {
            char[] separators = { ' ', ',', '.', '!', '?', ';', ':', '\t', '\n', '\r', '(', ')', '[', ']', '{', '}', '"', '\'' };
            string[] words = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            wordsCount = words.Length;
        }

        void ShortestWordSearch()
        {
            char[] separators = { ' ', ',', '.', '!', '?', ';', ':', '\t', '\n', '\r', '(', ')', '[', ']', '{', '}', '"', '\'' };
            string[] words = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            if (words.Length == 0)
            {
                shortestWord = "";
                return;
            }

            shortestWord = words[0];
            for (int i = 1; i < words.Length; i++)
            {
                if (words[i].Length < shortestWord.Length)
                {
                    shortestWord = words[i];
                }
            }
        }

        void LongestWordSearch()
        {
            char[] separators = { ' ', ',', '.', '!', '?', ';', ':', '\t', '\n', '\r', '(', ')', '[', ']', '{', '}', '"', '\'' };
            string[] words = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            if (words.Length == 0)
            {
                longestWord = "";
                return;
            }

            longestWord = words[0];
            for (int i = 1; i < words.Length; i++)
            {
                if (words[i].Length > longestWord.Length)
                {
                    longestWord = words[i];
                }
            }
        }

        void SentencesCount()
        {
            sentencesCount = 0;
            foreach (char ch in text)
            {
                if (ch == '.' || ch == '!' || ch == '?')
                {
                    sentencesCount++;
                }
            }
        }

        void LettersQuantity()
        {
            consonant = 0;
            vowel = 0;

            string allConsonant = "цкнгшщзхъфвпрлджчсмтьбйЦКНГШЩЗХЪФВПРЛДЖЧСМТЬБЙ";
            string allVowel = "уеыаоэяиюУЕЫАОЭЯИЮ";

            foreach (char ch in text)
            {
                if (char.IsLetter(ch))
                {
                    bool isConsonant = false;
                    for (int i = 0; i < allConsonant.Length; i++)
                    {
                        if (allConsonant[i] == ch)
                        {
                            isConsonant = true;
                            break;
                        }
                    }


                    if (isConsonant)
                    {
                        consonant++;
                    }
                    else
                    {
                        bool isVowel = false;
                        for (int i = 0; i < allVowel.Length; i++)
                        {
                            if (allVowel[i] == ch)
                            {
                                isVowel = true;
                                break;
                            }
                        }

                        if (isVowel)
                        {
                            vowel++;
                        }
                    }
                }
            }
        }

        void StatsLetters()
        {
            azbyka.Clear();
            foreach (char ch in text)
            {
                if (!char.IsLetter(ch))
                    continue;

                char lowerChar = char.ToLower(ch);

                if (azbyka.ContainsKey(lowerChar))
                    azbyka[lowerChar]++;
                else
                    azbyka[lowerChar] = 1;
            }
        }


        void SaveToHistory()
        {

            Characteristic historyCopy = new Characteristic();
            historyCopy.text = this.text.Length > 30 ? this.text.Substring(0, 30) + "..." : this.text;
            historyCopy.wordsCount = this.wordsCount;
            historyCopy.shortestWord = this.shortestWord;
            historyCopy.sentencesCount = this.sentencesCount;
            historyCopy.consonant = this.consonant;
            historyCopy.vowel = this.vowel;
            historyCopy.longestWord = this.longestWord;
            historyCopy.azbyka = new Dictionary<char, int>(this.azbyka);

            textHistory.Add(historyCopy);
        }
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

