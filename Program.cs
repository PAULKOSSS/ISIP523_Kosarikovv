using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

class Pr4 
{
    class Book
    {
        public enum var_genre
        {
            Детектив, Приключения, Роман
        }
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
        public DateOnly DateOfPublish;
        public var_genre Genre;

        public Book(string name, string author, int price, DateOnly d_of_pub, var_genre genre)
        {
            Id = count++;
            Name = name;
            Author = author;
            Price = price;
            DateOfPublish = d_of_pub;
            Genre = genre;
        }

        static void AddBook(List<Book> Books)
        {
            string name, author;
            int price;
            DateOnly d_of_pub;
            var_genre genre;

            Console.Write("Введите название: ");
            name = Console.ReadLine();

            Console.Write("Введите автора: ");
            author = Console.ReadLine();

            Console.Write("Введите цену: ");
            if (!int.TryParse(Console.ReadLine(), out price)) {
                Console.WriteLine("Неверный ввод");
            }

            Console.Write("Введите дату: ");
            if (!DateOnly.TryParse(Console.ReadLine(), out d_of_pub))
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
            var context = new ValidationContext(added_book);
            var results = new List<ValidationResult>();
            if (!Validator.TryValidateObject(added_book, context, results, true))
            {
                Console.WriteLine("Не удалось создать объект User");
                foreach (var error in results)
                {
                    Console.WriteLine(error.ErrorMessage);
                }
                Console.WriteLine();
            }
            else
                Console.WriteLine($"Объект User успешно создан. Name: {added_book.Name}\n");
        }

        static void DeleteBook(List<Book> Books)
        {
            foreach (var book in Books) { 
                Console.WriteLine($"{book.Id} - {book.Name}");
                

            }

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

        }

        static void SortBooks(List<Book> Books)
        {

        }

        static void MostExpAndCheapBook(List<Book> Books)
        {

        }

        static void GroupByAutor(List<Book> Books)
        {

        }
    }

    static void Main(string[] args)
    {
        List<Book> Books = new List<Book>();
    }
}

