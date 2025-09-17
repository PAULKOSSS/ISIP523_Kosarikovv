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

    static void Sort(int[] prises, string[] products,int quan_oper)
    {
        for (int i = 0; i < quan_oper; i++)
            for (int j = 0; j < prises[i] - 1; j++)
            {
                if (prises[i] >  prises[j])
                {
                    int tempi = prises[i];
                    prises[i] = prises[j];
                    prises[j] = tempi;
                    string temps = products[i];
                    products[i] = products[j];
                    products[j] = temps;
                }
            }
    }

    static void CurrencyConverter(int[] prises, string[] products, int quan_oper)
    {
        Console.WriteLine("Выберите в какую валюту хотите перевести: ");
        Console.WriteLine("1. Доллар");
        Console.WriteLine("2. Евро");
        Console.WriteLine("3. Квача");
        Console.WriteLine("4. Своя валюта");

        decimal[] costcopy = new decimal[quan_oper];
        for (int i = 0; i < quan_oper; i++)
        {
            costcopy[i] = prises[i];
        }

        int n = Convert.ToInt32(Console.ReadLine());
        //string choice = "";
        decimal usdRate = 83.0m;
        decimal eurRate = 97.0m;
        decimal kvachRate = 0.28m;
        decimal perRate = 0;

        if (n == 1)
        {
            //choice = "Доллар";
            for (int i = 0; i < quan_oper; i++)
            {

                costcopy[i] = (decimal)(costcopy[i] / usdRate);
            }
        }
        if (n == 2)
        {
            //choice = "Евро";
            for (int i = 0; i < quan_oper; i++)
            {
                costcopy[i] = (decimal)(costcopy[i] / eurRate);
            }
        }
        if (n == 3)
        {
            //choice = "Квача";
            for (int i = 0; i < quan_oper; i++)
            {
                costcopy[i] = (decimal)(costcopy[i] / kvachRate);
            }
        }
        if (n == 4)
        {
            Console.WriteLine("Введите курс: ");
            perRate = Convert.ToDecimal(Console.ReadLine());
            for (int i = 0; i < quan_oper; i++)
            {
                costcopy[i] = (decimal)(costcopy[i] / perRate);
            }
        }
        for (int i = 0; i < quan_oper; i++)
        {
            Console.WriteLine($"{products[i]} - {costcopy[i]}");
        }
    }

    static void SearchByName(string[] products, int[] prises, int quan_oper)
    {
        Console.WriteLine("Введите товар или услугу стоимость которой хотите увидеть: ");
        string pos = Console.ReadLine();
        for (int i = 0; i < quan_oper; i++)
        {
            if (pos == products[i]) Console.WriteLine(prises[i]);
            else Console.WriteLine("Товар отсутствует");
        }
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
                    Sort(prises, products, quan_oper);
                    Output(prises, products, quan_oper);
                    break;
                case 4:
                    CurrencyConverter(prises, products, quan_oper);
                    break;
                case 5:
                    SearchByName(products, prises, quan_oper);
                    break;

            }

            if (choice == 0) break;
          
        }
        
        ;
    }
}
