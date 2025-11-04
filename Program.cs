namespace Pr5
{
    class Programm
    {
        class Person
        {
            public string FIO { get; private set; }
            public DateOnly DateOfBirth { get; private set; }
            public string PhoneNumber { get; private set; }
            public string Email { get; private set; }

            public Person(string fio, DateOnly dofb, string number, string email) 
            {
                FIO = fio;
                DateOfBirth = dofb;
                PhoneNumber = number;
                Email = email;
            }

            public void PrintInfo()
            {
                Console.WriteLine("Вся информация о человеке:");
                Console.WriteLine($"ФИО - {FIO}");
                Console.WriteLine($"Дата рождения - {DateOfBirth}");
                Console.WriteLine($"Номер телефона - {PhoneNumber}");
                Console.WriteLine($"Электронная почта - {Email}");
                Console.WriteLine("");
            }
        }

        static void Main(string[] args)
        {

        }
    }
}
