using System;
using System.Collections.Generic;

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

        do
        {
            Console.Write("Введите название товара: ");
            Name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(Name))
                Console.WriteLine("Название не может быть пустым!");
        } while (string.IsNullOrWhiteSpace(Name));

        do
        {
            Console.Write("Введите цену: ");
            if (int.TryParse(Console.ReadLine(), out int price) && price >= 0)
            {
                Price = price;
                break;
            }
            else
            {
                Console.WriteLine("Цена должна быть неотрицательным числом!");
            }
        } while (true);

        do
        {
            Console.Write("Введите количество: ");
            if (int.TryParse(Console.ReadLine(), out int quantity) && quantity >= 0)
            {
                Quantity = quantity;
                break;
            }
            else
            {
                Console.WriteLine("Количество должно быть неотрицательным числом!");
            }
        } while (true);

        IsAvaliable = Quantity > 0;

        do
        {
            Console.WriteLine("Выберите категорию:");
            Console.WriteLine("1. Продукты");
            Console.WriteLine("2. Косметика");
            Console.WriteLine("3. Электроника");

            if (int.TryParse(Console.ReadLine(), out int categoryChoice) && categoryChoice >= 1 && categoryChoice <= 3)
            {
                Category = (Categories)(categoryChoice - 1);
                break;
            }
            else
            {
                Console.WriteLine("Неверный выбор категории! Введите число от 1 до 3.");
            }
        } while (true);

        count++;
        Console.WriteLine("Товар успешно добавлен!\n");
    }

    public Product(string name, int price, int quantity, bool isAvailable, Categories category)
    {
        Id = count;
        Name = name;
        Price = price;
        Quantity = quantity;
        IsAvaliable = isAvailable;
        Category = category;
        count++;
    }
}

class Programm
{
    static void InitializeTestData(List<Product> products)
    {
        products.Add(new Product("Хлеб", 50, 100, true, Categories.Продукты));
        products.Add(new Product("Шампунь", 300, 50, true, Categories.Косметика));
        products.Add(new Product("Смартфон", 25000, 10, true, Categories.Электроника));
        products.Add(new Product("Молоко", 80, 0, false, Categories.Продукты));
        products.Add(new Product("Помада", 500, 30, true, Categories.Косметика));
        Console.WriteLine("Тестовые данные добавлены!\n");
    }

    static void Add(List<Product> products)
    {
        products.Add(new Product());
    }

    static void Remove(List<Product> products)
    {
        if (products.Count > 0)
        {
            Console.WriteLine("Список товаров:");
            foreach (var product in products)
                Console.WriteLine($"{product.Id} - {product.Name}");

            Console.Write("Введите id товара, который хотите удалить: ");
            if (int.TryParse(Console.ReadLine(), out int index))
            {
                Product productToRemove = null;
                foreach (var product in products)
                {
                    if (index == product.Id)
                    {
                        productToRemove = product;
                        break;
                    }
                }

                if (productToRemove != null)
                {
                    products.Remove(productToRemove);
                    Console.WriteLine("Товар удалён\n");
                }
                else
                {
                    Console.WriteLine("Товар с таким id не найден\n");
                }
            }
            else
            {
                Console.WriteLine("Неверный формат id\n");
            }
        }
        else
        {
            Console.WriteLine("Список пуст\n");
        }
    }

    static void Order(List<Product> products)
    {
        if (products.Count > 0)
        {
            Console.WriteLine("Список товаров:");
            foreach (var product in products)
                Console.WriteLine($"{product.Id} - {product.Name}");

            Console.Write("Введите id товара, который хотите заказать: ");
            if (int.TryParse(Console.ReadLine(), out int index))
            {
                Console.Write("Введите количество: ");
                if (int.TryParse(Console.ReadLine(), out int n) && n > 0)
                {
                    bool found = false;
                    foreach (var product in products)
                    {
                        if (index == product.Id)
                        {
                            product.Quantity += n;
                            product.IsAvaliable = true;
                            Console.WriteLine($"Товар заказан в количестве {n}. Новое количество: {product.Quantity}\n");
                            found = true;
                            break;
                        }
                    }
                    if (!found) Console.WriteLine("Товар с таким id не найден\n");
                }
                else
                {
                    Console.WriteLine("Количество должно быть положительным числом!\n");
                }
            }
            else
            {
                Console.WriteLine("Неверный формат id\n");
            }
        }
        else
        {
            Console.WriteLine("Список пуст\n");
        }
    }

    static void Sell(List<Product> products)
    {
        if (products.Count > 0)
        {
            Console.WriteLine("Список товаров:");
            foreach (var product in products)
                Console.WriteLine($"{product.Id} - {product.Name} (доступно: {product.Quantity})");

            Console.Write("Введите id товара, который хотите продать: ");
            if (int.TryParse(Console.ReadLine(), out int index))
            {
                Console.Write("Введите количество: ");
                if (int.TryParse(Console.ReadLine(), out int n) && n > 0)
                {
                    bool found = false;
                    foreach (var product in products)
                    {
                        if (index == product.Id)
                        {
                            found = true;
                            if (product.Quantity >= n)
                            {
                                product.Quantity -= n;
                                product.IsAvaliable = product.Quantity > 0;
                                Console.WriteLine($"Товар продан в количестве {n}. Остаток: {product.Quantity}\n");
                            }
                            else
                            {
                                Console.WriteLine($"Недостаточно товара на складе! Доступно: {product.Quantity}\n");
                            }
                            break;
                        }
                    }
                    if (!found) Console.WriteLine("Товар с таким id не найден\n");
                }
                else
                {
                    Console.WriteLine("Количество должно быть положительным числом!\n");
                }
            }
            else
            {
                Console.WriteLine("Неверный формат id\n");
            }
        }
        else
        {
            Console.WriteLine("Список пуст\n");
        }
    }

    static void Search(List<Product> products)
    {
        if (products.Count > 0)
        {
            Console.Write("Варианты поиска: по коду(1), названию(2) и категории(3): ");
            if (int.TryParse(Console.ReadLine(), out int choice) && choice >= 1 && choice <= 3)
            {
                bool found = false;
                switch (choice)
                {
                    case 1:
                        Console.Write("Введите id товара, который хотите найти: ");
                        if (int.TryParse(Console.ReadLine(), out int index))
                        {
                            foreach (var product in products)
                            {
                                if (index == product.Id)
                                {
                                    Console.WriteLine($"Товар найден: ID - {product.Id}, название - {product.Name}, цена - {product.Price}, количество - {product.Quantity}, наличие - {product.IsAvaliable}, категория - {product.Category}");
                                    found = true;
                                    break;
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Неверный формат id");
                        }
                        break;
                    case 2:
                        Console.Write("Введите название товара, который хотите найти: ");
                        string name = Console.ReadLine().ToLower();
                        foreach (var product in products)
                        {
                            if (product.Name.ToLower().Contains(name))
                            {
                                Console.WriteLine($"Товар найден: ID - {product.Id}, название - {product.Name}, цена - {product.Price}, количество - {product.Quantity}, наличие - {product.IsAvaliable}, категория - {product.Category}");
                                found = true;
                            }
                        }
                        break;
                    case 3:
                        Console.WriteLine("Выберите категорию для поиска:");
                        Console.WriteLine("1. Продукты");
                        Console.WriteLine("2. Косметика");
                        Console.WriteLine("3. Электроника");
                        if (int.TryParse(Console.ReadLine(), out int categoryChoice) && categoryChoice >= 1 && categoryChoice <= 3)
                        {
                            Categories searchCategory = (Categories)(categoryChoice - 1);
                            foreach (var product in products)
                            {
                                if (searchCategory == product.Category)
                                {
                                    Console.WriteLine($"Товар найден: ID - {product.Id}, название - {product.Name}, цена - {product.Price}, количество - {product.Quantity}, наличие - {product.IsAvaliable}, категория - {product.Category}");
                                    found = true;
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Неверный выбор категории!");
                        }
                        break;
                }

                if (!found)
                    Console.WriteLine("Товары не найдены\n");
                else
                    Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Неверный выбор варианта поиска!\n");
            }
        }
        else
        {
            Console.WriteLine("Список пуст\n");
        }
    }

    static void DisplayAllProducts(List<Product> products)
    {
        if (products.Count > 0)
        {
            Console.WriteLine("Все товары:");
            Console.WriteLine("ID | Название | Цена | Количество | Наличие | Категория");
            Console.WriteLine("--------------------------------------------------------");
            foreach (var product in products)
            {
                Console.WriteLine($"{product.Id} | {product.Name} | {product.Price} | {product.Quantity} | {product.IsAvaliable} | {product.Category}");
            }
            Console.WriteLine();
        }
        else
        {
            Console.WriteLine("Список пуст\n");
        }
    }

    static void Main(string[] args)
    {
        List<Product> products = new List<Product>();

        InitializeTestData(products);

        while (true)
        {
            Console.WriteLine("==== Меню ====");
            Console.WriteLine("1. Добавить товар");
            Console.WriteLine("2. Удалить товар");
            Console.WriteLine("3. Заказать товар");
            Console.WriteLine("4. Продать товар");
            Console.WriteLine("5. Поиск товаров (по коду, названию и категории)");
            Console.WriteLine("6. Показать все товары");
            Console.WriteLine("0. Выход");
            Console.Write("Выберите действие: ");

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                switch (choice)
                {
                    case 0:
                        Console.WriteLine("До свидания!");
                        return;
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
                        Sell(products);
                        break;
                    case 5:
                        Search(products);
                        break;
                    case 6:
                        DisplayAllProducts(products);
                        break;
                    default:
                        Console.WriteLine("Неверный выбор! Попробуйте снова.\n");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Неверный формат! Введите число.\n");
            }
        }
    }
}