using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using static System.Reflection.Metadata.BlobBuilder;



class Pr4
{
    public enum var_genre
    {
        Детектив, Приключения, Роман
    }

    class Book
    {
        
        static int count = 0;

        public int Id;
        [Required]
        //[StringLength(20, MinimumLength = 2)]
        public string Name;
        [Required]
        //[StringLength(20, MinimumLength = 2)]
        public string Author;
        [Required]
        [Range(1, 10000)]
        public int Price;
        public int DateOfPublish;
        public var_genre Genre;

        public Book(string name, string author, int price, int d_of_pub, var_genre genre)
        {
            Id = count++;
            Name = name;
            Author = author;
            Price = price;
            DateOfPublish = d_of_pub;
            Genre = genre;
        }

        
    }

    static void AddBook(List<Book> Books)
    {
        string name, author;
        int price;
        int d_of_pub;
        var_genre genre;

        Console.Write("Введите название: ");
        name = Console.ReadLine();

        Console.Write("Введите автора: ");
        author = Console.ReadLine();

        Console.Write("Введите цену: ");
        if (!int.TryParse(Console.ReadLine(), out price))
        {
            Console.WriteLine("Неверный ввод");
        }

        Console.Write("Введите дату: ");
        if (!int.TryParse(Console.ReadLine(), out d_of_pub))
        {
            Console.WriteLine("Неверный ввод");
        }

        Console.WriteLine("1.Детектив");
        Console.WriteLine("2.Приключения");
        Console.WriteLine("3.Роман");
        Console.Write("Введите жанр: ");
        if (!int.TryParse(Console.ReadLine(), out int choice_genre))
        {
            Console.WriteLine("Неверный ввод");
        }
        genre = (var_genre)(choice_genre - 1);

        Book added_book = new Book(name, author, price, d_of_pub, genre);
        //var context = new ValidationContext(added_book);
        //var results = new List<ValidationResult>();
        //if (!Validator.TryValidateObject(added_book, context, results, true))
        //{
        //    Console.WriteLine("Не удалось создать объект User");
        //    foreach (var error in results)
        //    {
        //        Console.WriteLine(error.ErrorMessage);
        //    }
        //    Console.WriteLine();
        //}
        //else
        //    Console.WriteLine($"Объект User успешно создан. Name: {added_book.Name}\n");
    }

    static void DeleteBook(List<Book> Books)
    {
        PrintInfo(Books);

        Console.Write("Выберите книгу, которую хотите удалить, введя ее Id: ");
        if (!int.TryParse(Console.ReadLine(), out int choice_id))
        {
            Console.WriteLine("Неверный ввод");
        }

        var book_to_delete = Books.FirstOrDefault(b => b.Id == choice_id);
        Books.Remove(book_to_delete);
        Console.WriteLine($"Книга {book_to_delete.Name} успешно удалена");
    }

    static void SearchBook(List<Book> Books)
    {

        PrintInfo(Books);
        Console.WriteLine("1.по названию");
        Console.WriteLine("2.по автору");
        Console.WriteLine("3.по жанру");
        Console.WriteLine("Выберите по какому параметру искать");
        if (!int.TryParse(Console.ReadLine(), out int choice)) Console.WriteLine("");
        switch (choice)
        {
            case 1:
                {
                    string search_name;
                    Console.Write("");
                    search_name = Console.ReadLine();
                    var book = Books.FirstOrDefault(b => b.Name == search_name);
                    PrintBookInfo(book);
                    break;
                }

            case 2:
                {
                    string search_author;
                    Console.Write("");
                    search_author = Console.ReadLine();
                    var book = Books.FirstOrDefault(b => b.Author == search_author);
                    PrintBookInfo(book);
                    break;
                }

            case 3:
                {

                    Console.WriteLine("1.Детектив");
                    Console.WriteLine("2.Приключения");
                    Console.WriteLine("3.Роман");
                    Console.Write("Выберите жанр: ");
                    if (!int.TryParse(Console.ReadLine(), out int search_genre))
                    {
                        Console.WriteLine("Неверный ввод");
                    }

                    var books = Books.Where(b => b.Genre == (var_genre)(search_genre - 1)).ToList();
                    PrintInfo(books);
                    break;
                }


        }
    }

    static void SortBooks(List<Book> Books)
    {
        PrintInfo(Books);
        Console.WriteLine("1.по названию");
        Console.WriteLine("2.по году");
        Console.WriteLine("Выберите по какому параметру сортировать");
        if (!int.TryParse(Console.ReadLine(), out int choice)) Console.WriteLine("");
        switch (choice)
        {
            case 1:
                {
                    var books_byname = Books.OrderBy(b => b.Name).ToList();
                    PrintInfo(books_byname);
                    break;
                }
            case 2:
                {
                    var books_byyear = Books.OrderBy(b => b.DateOfPublish).ToList();
                    PrintInfo(books_byyear);
                    break;
                }
        }

    }

    static void MostExpAndCheapBook(List<Book> Books)
    {
        Console.WriteLine($"Самая дорогая книга - {Books.Max(b => b.Price)}");
        Console.WriteLine($"Самая дешевая книга - {Books.Min(b => b.Price)}");
    }

    static void GroupByAutor(List<Book> Books)
    {
        var authorCounts = Books.GroupBy(b => b.Author)
                       .ToDictionary(g => g.Key, g => g.Count())
                       .OrderBy(pair => pair.Key);

        foreach (var pair in authorCounts)
        {
            Console.WriteLine($"{pair.Key}: {pair.Value} книг(и)");
        }
    }

    static void PrintInfo(List<Book> Books)
    {
        foreach (var book in Books) Console.WriteLine($"{book.Id} - {book.Name}, {book.DateOfPublish}");
    }

    static void PrintBookInfo(Book book)
    {
        Console.WriteLine($"Название - {book.Name},автор - {book.Author},цена - {book.Price},жанр - {book.Genre}, год публикации - {book.DateOfPublish}");
    }

    static void Main(string[] args)
    {
        List<Book> Books = new List<Book>();

        Books.Add(new Book("Преступление и наказание", "Достоевский", 500, 1866, var_genre.Роман));
        Books.Add(new Book("Преступление и наказание", "Достоевский", 1000, 1866, var_genre.Роман));
        Books.Add(new Book("Преступление и наказание", "Достоевский", 1500, 1866, var_genre.Роман));
        Books.Add(new Book("Шерлок Холмс", "Конан Дойл", 300, 1887, var_genre.Детектив));
        Books.Add(new Book("Война и мир", "Толстой", 600, 1869, var_genre.Роман));
        Books.Add(new Book("Остров сокровищ", "Стивенсон", 400, 1883, var_genre.Приключения));
        Books.Add(new Book("Убийство в Восточном экспрессе", "Агата Кристи", 350, 1934, var_genre.Детектив));

        Console.WriteLine("Добро пожаловать в систему учета книг библиотеки!");
        Console.WriteLine("Загружено тестовых книг: 5\n");

        while (true)
        {
            Console.WriteLine("=== МЕНЮ ===");
            Console.WriteLine("1. Добавить книгу");
            Console.WriteLine("2. Удалить книгу");
            Console.WriteLine("3. Найти книги");
            Console.WriteLine("4. Сортировать книги");
            Console.WriteLine("5. Самая дорогая и дешевая книга");
            Console.WriteLine("6. Группировка по авторам");
            Console.WriteLine("7. Выход");
            Console.Write("Выберите действие: ");

            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine("Неверный ввод! Пожалуйста, выберите число от 1 до 8.\n");
                continue;
            }

            switch (choice)
            {    
                case 1:
                    AddBook(Books);
                    break;
                case 2:
                    DeleteBook(Books);
                    break;
                case 3:
                    SearchBook(Books);
                    break;
                case 4:
                    SortBooks(Books);
                    break;
                case 5:
                    MostExpAndCheapBook(Books);
                    break;
                case 6:
                    GroupByAutor(Books);
                    break;
                case 7:
                    Console.WriteLine("До свидания!");
                    return;
                default:
                    Console.WriteLine("Неверный выбор! Пожалуйста, выберите число от 1 до 8.\n");
                    break;
            }
        }
    }
}

