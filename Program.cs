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
            products.Remove(products[index - 1]);
            Console.WriteLine("Товар удален");
        }
        else Console.WriteLine("Список пуст");
    }
    
    static void Main(string[] args)
    {
        List<Product> products = new List<Product>();
        Add(products);
        Remove(products);
    }
}
