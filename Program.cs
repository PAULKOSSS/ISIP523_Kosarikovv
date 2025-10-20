class Pr4
{
    enum genre
    {
        Детектив,
        Приключения,
        Роман
    }
    class Book
    {
        static public int Id = 1;
        public string Title;
        public string Aurhor;
        public genre Genre;
        public DateOnly Year;
        public int price;
    }

    static void Main(string[] args)
    {
        int choice;
        Console.WriteLine("Меню");
        Console.WriteLine("1.Добавить книгу");
        Console.WriteLine("2.Удалить книгу");
        Console.WriteLine("3.Поиск книги(автор - 1, название - 2, жанр - 3)");
        Console.WriteLine("4.Сортировка(название - 1, по году - 2)");
        Console.WriteLine("5.Самая дорогая и дешевая книга");
        Console.WriteLine("6.Греппировка по автору");
        Console.WriteLine("0.Выход");
        choice = Convert.ToInt32(Console.ReadLine());
        switch (choice) 
        {
            case 0:
                Console.WriteLine();
                break;
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
            case 5:
                break;
            case 6:
                break;
        }
    }
}
