using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Pr5
{
    class Programm
    {
        List<Student> student;
        List<Professor> professors;
        List<Course> courses;

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

            public (string, DateOnly, string, string) Create()
            {
                string fio, number, email;
                DateOnly dofb;

                Console.WriteLine("Добавление человека...");
                while (true)
                {
                    Console.Write("Введите ваше имя: ");
                    fio = Console.ReadLine()?.Trim();

                    if (!string.IsNullOrWhiteSpace(fio))
                    {
                        break;
                    }
                    Console.WriteLine("Ошибка! Имя не может быть пустым. Попробуйте снова.");
                }

                while (true)
                {
                    Console.Write("Введите ваш номер телефона: ");
                    number = Console.ReadLine()?.Trim();

                    if (!string.IsNullOrWhiteSpace(number))
                    {
                        break;
                    }
                    Console.WriteLine("Ошибка! Номер не может быть пустым. Попробуйте снова.");
                }

                while (true)
                {
                    Console.Write("Введите ваш адрес электронной почты: ");
                    email = Console.ReadLine()?.Trim();

                    if (!string.IsNullOrWhiteSpace(email))
                    {
                        break;
                    }
                    Console.WriteLine("Ошибка! Адрес электронной почты не может быть пустым. Попробуйте снова.");
                }

                while (true)
                {
                    Console.Write("Введите дату рождения (дд.мм.гггг): ");
                    string input = Console.ReadLine()?.Trim();

                    if (DateOnly.TryParseExact(input, "dd.MM.yyyy", null, System.Globalization.DateTimeStyles.None, out dofb))
                    {
                        break;
                    }
                    Console.WriteLine("Ошибка! Неверный формат даты. Используйте дд.мм.гггг");
                }

                return (fio, dofb, number, email);
            }

            //public abstract void Add();
        }


        class Student : Person 
        {
            public List<Course> courses_of_student;

            public Student(string fio, DateOnly dofb, string number, string email) : base(fio, dofb, number, email) { }

            public void Add(List<Student> students)
            {
                var (fio, dofb, number, email) = Create();
                Student student = new(fio, dofb, number, email);
                students.Add(student);
            }

            public void EnrollmentOnCourse(List<Course> courses, List<Student> students)
            {
                Console.WriteLine("Все студенты:");
                foreach (var student in students) student.PrintInfo();

                string choicedstudentname;
                while (true)
                {
                    Console.Write("Введите ФИО студента, которого надо записать: ");
                    choicedstudentname = Console.ReadLine()?.Trim();

                    if (!string.IsNullOrWhiteSpace(choicedstudentname))
                    {
                        break;
                    }
                    Console.WriteLine("Ошибка! Имя не может быть пустым. Попробуйте снова.");
                }

                var choicedstudent = students.FirstOrDefault(s => s.FIO == choicedstudentname);
                

                Console.WriteLine("Все курсы:");
                foreach (var course in courses) course.ShowAllInfo();

                string choicedcoursename;
                while (true)
                {
                    Console.Write("Введите название курса, на который вас записать: ");
                    choicedcoursename = Console.ReadLine()?.Trim();

                    if (!string.IsNullOrWhiteSpace(choicedcoursename))
                    {
                        break;
                    }
                    Console.WriteLine("Ошибка! Название курса не может быть пустым. Попробуйте снова.");
                }

                var choicedcourse = courses.FirstOrDefault(c => c.NameOfCourse == choicedcoursename);

                choicedstudent.courses_of_student.Add(choicedcourse);
                choicedcourse.StudentsOnCourse.Add(choicedstudent);
                Console.WriteLine($"Студент {choicedstudent.FIO} успешно добавлен на курс {choicedcourse.NameOfCourse}");
            }

            public void ShowAllCoursesOfStudent()
            {
                Console.WriteLine("Все курсы, на которые записан студент:");
                foreach (var course in courses_of_student) course.ShowAllInfo();
            }
        }

        class Professor : Person
        {
            public Professor(string fio, DateOnly dofb, string number, string email) : base(fio, dofb, number, email) { }

            public void Add(List<Professor> professors)
            {
                var (fio, dofb, number, email) = Create();
                Professor professor = new(fio, dofb, number, email);
                professors.Add(professor);
            }
        }

        class Course
        {
            public string NameOfCourse { get; private set; }
            public Professor ProfessorOfCourse { get; set; }
            public List<Student> StudentsOnCourse { get; set; }

            public Course(string nameOfCourse)
            {
                NameOfCourse = nameOfCourse;
            }

            public void CreateNewCourse(List<Course> courses)
            {
                string nameOfCourse;
                while (true)
                {
                    Console.Write("Введите название курса: ");
                    nameOfCourse = Console.ReadLine()?.Trim();

                    if (!string.IsNullOrWhiteSpace(nameOfCourse)) break;
                    Console.WriteLine("Ошибка! Название курса не может быть пустым. Попробуйте снова.");
                }

                Course course = new(nameOfCourse);
                Console.WriteLine($"Курс с названием {course.NameOfCourse} успешно создан; чтобы добавить преподавателя или студентов на курс выберите соответсвующие пункты в меню.");
                Console.WriteLine("");
            }



            public void ShowAllInfo()
            {
                Console.WriteLine($"Курс - {NameOfCourse}, ведет его {ProfessorOfCourse.FIO}");
                Console.WriteLine("");
            }

            public void ShowAllStudentsOnCourse()
            {
                Console.WriteLine("Студенты записанные на этот курс:");
                foreach (var student in StudentsOnCourse) Console.WriteLine($"{student.FIO}");
            }
        }

        static void PrintAllInfo()
        {

        }

        static void Start()
        {

        }

        static void Main(string[] args)
        {

        }
    }
}
