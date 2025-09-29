using System;
using System.Diagnostics;
using System.Xml.Linq;

public enum Categories
{
    Продукты,
    Косметика,
    Электроника
}

class Product
{
    public static int count = 1;
    public int Id;
    public string Name;
    public int Price;
    public int Quantity;
    public bool IsAvaliable;
    public Categories Category;

    public Product() 
    {
        Id = count;
        Console.Write("Введите название товара: ");
        Name = Console.ReadLine();
        Console.Write("Введите цену: ");
        Price = Convert.ToInt32(Console.ReadLine());
        Console.Write("Введите количество: ");
        Quantity = Convert.ToInt32(Console.ReadLine());
        Console.Write("Введите наличие(true, false)");
        IsAvaliable = Convert.ToBoolean(Console.ReadLine());

        Console.WriteLine("Выберите категорию:");
        Console.WriteLine("1. Продукты");
        Console.WriteLine("2. Косметика");
        Console.WriteLine("3. Электроника");
        

        int categoryChoice = Convert.ToInt32(Console.ReadLine());
        Categories Сategory = (Categories)(categoryChoice - 1);
        count++;
    }    
}



class Programm
{
    
    static void Add(List<Product> products)
    {
        products.Add(new Product());
    }

    static void Remove(List<Product> products) 
    {
        if (products.Count > 0)
        {
            foreach (var product in products)
                Console.WriteLine($"{product.Id} - {product.Name}");

            Console.Write("Введите id товара, который хотите удалить: ");
            int index = Convert.ToInt32(Console.ReadLine());
            foreach (var product in products)
            {
                if (index == product.Id)
                {
                    products.Remove(product);
                    Console.WriteLine("Товар удалён");
                }
            }
        }
        else Console.WriteLine("Список пуст");
    }

    static void Order(List<Product> products)
    {
        if (products.Count > 0)
        {
            foreach (var product in products)
                Console.WriteLine($"{product.Id} - {product.Name}");

            Console.Write("Введите id товара, который хотите заказать: ");
            int index = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите количество: ");
            int n = Convert.ToInt32(Console.ReadLine());
            foreach (var product in products)
            {
                if (index == product.Id)
                {
                    product.Quantity += n;
                    Console.WriteLine($"Товар заказан в количестве {n}");
                }
            }
        }
        else Console.WriteLine("Список пуст");
    }

    static void Sell(List<Product> products)
    {
        if (products.Count > 0)
        {
            foreach (var product in products)
                Console.WriteLine($"{product.Id} - {product.Name}");

            Console.Write("Введите id товара, который хотите продать: ");
            int index = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите количество: ");
            int n = Convert.ToInt32(Console.ReadLine());
            foreach (var product in products)
            {
                if (index == product.Id)
                {
                    product.Quantity -= n;
                    Console.WriteLine($"Товар продан в количестве {n}");
                }
            }
        }
        else Console.WriteLine("Список пуст");
    }

    static void Main(string[] args)
    {
        List<Product> products = new List<Product>();
        while (true) 
        {
            Console.WriteLine("==== Меню ====");
            Console.WriteLine("1. Добавить товар");
            Console.WriteLine("2. Удалить товар");
            Console.WriteLine("3. Заказать товар");
            Console.WriteLine("4. Продать товар");
            Console.WriteLine("5. Поиск товаров (по коду, названию и категории)");
            Console.WriteLine("0. Выход");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice) 
            {
                case 0:
                    break;
                case 1:
                    Add(products);
                    break;
                case 2:
                    Remove(products);
                    break;
                case 3:
                    Order(products);
                    break;
                case 4:
                    break;
                case 5:
                    break;
            }
        }
    }
}
