using System.ComponentModel.DataAnnotations;

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

        }

        static void DeleteBook(List<Book> Books)
        {

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

