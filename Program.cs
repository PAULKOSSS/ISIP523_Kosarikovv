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
    }    
}



class Programm
{
    

    

    static void Main(string[] args)
    {
        List<Product> products = new List<Product>();
        
    }
}
