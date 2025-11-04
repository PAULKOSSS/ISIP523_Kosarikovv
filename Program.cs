using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

            public Person() { }

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

            public Student() { }

            public Student ChoiceStudent(List<Student> students)
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
                return choicedstudent;
            }

            

            public void Add(List<Student> students)
            {
                var (fio, dofb, number, email) = Create();
                Student student = new(fio, dofb, number, email);
                students.Add(student);
            }

            public void EnrollmentOnCourse(List<Course> courses, List<Student> students)
            {
                //Console.WriteLine("Все студенты:");
                //foreach (var student in students) student.PrintInfo();

                //string choicedstudentname;
                //while (true)
                //{
                //    Console.Write("Введите ФИО студента, которого надо записать: ");
                //    choicedstudentname = Console.ReadLine()?.Trim();

                //    if (!string.IsNullOrWhiteSpace(choicedstudentname))
                //    {
                //        break;
                //    }
                //    Console.WriteLine("Ошибка! Имя не может быть пустым. Попробуйте снова.");
                //}

                var choicedstudent = ChoiceStudent(students);
                

                //Console.WriteLine("Все курсы:");
                //foreach (var course in courses) course.ShowAllInfo();

                //string choicedcoursename;
                //while (true)
                //{
                //    Console.Write("Введите название курса, на который вас записать: ");
                //    choicedcoursename = Console.ReadLine()?.Trim();

                //    if (!string.IsNullOrWhiteSpace(choicedcoursename))
                //    {
                //        break;
                //    }
                //    Console.WriteLine("Ошибка! Название курса не может быть пустым. Попробуйте снова.");
                //}

                var choicedcourse = ChoiceCourse(courses);

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

            public Professor() { }

            public void Add(List<Professor> professors)
            {
                var (fio, dofb, number, email) = Create();
                Professor professor = new(fio, dofb, number, email);
                professors.Add(professor);
            }

            public Professor ChoiceProfessor(List<Professor> professors)
            {
                Console.WriteLine("Все профессора:");
                foreach (var professor in professors) professor.PrintInfo();

                string choicedprofessorname;
                while (true)
                {
                    Console.Write("Введите ФИО профессора, которого надо назначить: ");
                    choicedprofessorname = Console.ReadLine()?.Trim();

                    if (!string.IsNullOrWhiteSpace(choicedprofessorname))
                    {
                        break;
                    }
                    Console.WriteLine("Ошибка! Имя не может быть пустым. Попробуйте снова.");
                }

                var choicedprofessor = professors.FirstOrDefault(s => s.FIO == choicedprofessorname);
                return choicedprofessor;
            }

            public void EnrollmentOnCourse(List<Course> courses, List<Professor> professors)
            {

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

            public Course() { }

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
                Console.WriteLine("");
            }
        }

        static Course ChoiceCourse(List<Course> courses)
        {
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
            return choicedcourse;
        }

        static void PrintAllInfo(List<Student> students, List<Professor> professors, List<Course> courses)
        {
            Console.WriteLine("Полная информация о системе");
            Console.WriteLine("Студенты:");
            foreach (var student in students)
            {
                student.PrintInfo();
                student.ShowAllCoursesOfStudent();
            }
            Console.WriteLine("Профессора:");
            foreach (var prof in professors) prof.PrintInfo();
            Console.WriteLine("Курсы");
            foreach (var course in courses)
            {
                course.ShowAllInfo();
                course.ShowAllStudentsOnCourse();
            }
        }

        static void Start(List<Student> students, List<Professor> professors, List<Course> courses)
        {
            int choice;
            Console.WriteLine("### Приложение для управления университетом ###");
            while (true) {
                Console.WriteLine("Меню для пользователя:");
                Console.WriteLine("1. Добавить нового студента");
                Console.WriteLine("2. Просмотр всех студентов");
                Console.WriteLine("3. Запись студента на курс");
                Console.WriteLine("4. Просмотр всех курсов, на которые записан студент");
                Console.WriteLine("5. Добавть нового преподавателя");
                Console.WriteLine("6. Просмотр всех преподавателей");
                Console.WriteLine("7. Назначение преподавателя на курс");
                Console.WriteLine("8. Добавить новый курс");
                Console.WriteLine("9. Просмотр всех курсов");
                Console.WriteLine("10. Просмотр списка студентов, записанных на курс");
                Console.WriteLine("11. Просмотр всей доступной информации");
                Console.WriteLine("12. Выход");
                while (true)
                {
                    Console.Write("Введите пункт из меню: ");
                    string input = Console.ReadLine()?.Trim();

                    if (int.TryParse(input, out choice))
                    {
                        if (choice >= 1 && choice <= 12)
                        {
                            break;
                        }
                        Console.WriteLine("Ошибка! Число должно совпадать пункту меню.");
                    }
                    else
                    {
                        Console.WriteLine("Ошибка! Введите целое число.");
                    }
                }

                Student student = new();
                Professor professor = new();
                Course course = new();

                switch (choice) {
                    case 1:
                        {
                            student.Add(students);
                            break;
                        }
                    case 2:
                        {
                            foreach (var stud in students) stud.PrintInfo();
                            break;
                        }
                    case 3:
                        {
                            student.EnrollmentOnCourse(courses, students);
                            break;
                        }
                    case 4:
                        {
                            var stud = student.ChoiceStudent(students);
                            stud.ShowAllCoursesOfStudent();
                            break;
                        }
                    case 5:
                        professor.Add(professors);
                        break;
                    case 6:
                        foreach (var prof in professors) prof.PrintInfo();
                        break;
                    case 7:
                        break;
                    case 8:
                        course.CreateNewCourse(courses);
                        break;
                    case 9:
                        foreach (var cor in courses) cor.ShowAllInfo();
                        break;
                    case 10:
                        {
                            var cor = ChoiceCourse(courses);
                            cor.ShowAllStudentsOnCourse();
                            break;
                        }
                    case 11:
                        PrintAllInfo(students, professors, courses);
                        break;
                    case 12:
                        Console.WriteLine("Adios");
                        break;
                }
            }
        }

        static void Main(string[] args)
        {
            List<Student> students = new();
            List<Professor> professors = new();
            List<Course> courses = new();
            Start(students, professors, courses);
        }
    }
}
