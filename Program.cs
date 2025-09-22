using System;

class Product
{
    public static int Count = 1;
    public static string[] categories = new string[3] { "продукты", "косметика", "хозтовары" };
    public int Id;
    public string Name;
    public int Price;
    public int Quantity;
    public bool isAvaliable;
    public string Category;


}

class Programm
{
    static void Add(List<Product> products)
    {
        products.Add(new Product());
    }

    static void Main(string[] args)
    {
        List<Product> products = new List<Product>();
    }
}
