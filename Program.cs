using System;
using static System.Net.Mime.MediaTypeNames;

class Pr1
{

    static void Output(int[] prises, string[] products, int quan_oper)
    {
        for (int i = 0; i < quan_oper; i++)
        {
            Console.WriteLine($"{products[i]} {prises[i]}");
        }
    }

    static void Stat(int[] prises, int quan_oper)
    {
        int sum = 0, average, min = prises[0], max = prises[0];
        for (int i = 0; i < quan_oper; i++)
        {
            sum += prises[i];
            if (min > prises[i]) min = prises[i];
            if (max < prises[i]) max = prises[i];  
        }
        average = sum / quan_oper;
        Console.WriteLine(average.ToString(), max.ToString(), min.ToString(), sum.ToString());
    }

    static void Main(String[] args)
    {
        Console.Write("Введите кол-во операций: ");
        int quan_oper = Convert.ToInt32(Console.ReadLine);
        int[] prises = new int[quan_oper];
        string[] products = new string[quan_oper];
        for (int i = 0; i < quan_oper; i++) 
        {
            Console.Write("Введите товар или услугу и цену(через ;)");
            string str = Console.ReadLine();
            string[] els = str.Split(new char[] { ';' });
            prises[i] = Convert.ToInt32(els[1]);
            products[i] = els[0];
        }

        while (true)
        {
            Console.WriteLine("1. Вывод данных");
            Console.WriteLine("2. Статистика");
            Console.WriteLine("3. Сортировка по цене");
            Console.WriteLine("4. Конвертация валюты");
            Console.WriteLine("5. Поиск по названию");
            Console.WriteLine("0. Выход");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 0:
                    Console.WriteLine("Adios");
                    break;
                case 1:
                    Output(prises, products, quan_oper);
                    break;
                case 2:
                    Stat(prises, quan_oper);
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    break;

            }

            if (choice == 0) break;
          
        }
        
        ;
    }
}
