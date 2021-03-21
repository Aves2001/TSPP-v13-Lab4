using System;
using System.Linq;

namespace Lab4
{
    public class Student // Клас використовується в першому завданні 4-ї лабораторної
    {
        // закриті поля класу 
        private string name;
        private string lastName;
        private string group;
        private int year;
        private string adress;
        private string passport;
        private int age;
        private string telephon;
        private double rating;


        // Доступ до полів класу, з перевіркою даних
        public string Name
        {
            get => name;
            set
            {
                // Перевірка чи в імені є якісь символи окрім буквів.
                TestIsLetter(value, "Невірно введено ім'я, використано заборонені символи");
                name = value;
            }
        }
        public string LastName
        {
            get => lastName;
            set
            {
                // Перевірка чи в прізвищю є якісь символи окрім буквів.
                TestIsLetter(value, "Невірно введено прізвище, використано заборонені символи");
                lastName = value;
            }
        }
        public string Group
        {
            get => group;
            set
            {
                // Перевірка чи в Групі є якісь символи окрім буквів, цифр і тире
                TestIsLetterIsNumberIsTire(value, "Невірно введено групу, використано заборонені символи");
                group = value;
            }
        }
        public int Year
        {
            get => year;
            set
            {
                // перевіряє чи вказаний рік поступання не більший за теперішній і чи не менший за 1980
                if (value > DateTime.Today.Year)
                {
                    throw new Exception("Студент не може поступити на навчання з майбутнього: " + value);
                }
                else if (value < 1980)
                {
                    throw new Exception("Вказаний не правдоподібний рік поступання, вказаний рік: " + value);
                }
                year = value;
            }
        }
        public string Adress { get => adress; set => adress = value; }
        public string Passport
        {
            get => passport;
            set
            {
                // Перевірка чи в паспорті є якісь символи окрім чисел
                TestIsNumber(value, "Невірно введено код паспорта, використано заборонені символи");

                if (value.Length != 9)
                {
                    throw new Exception("Невірна кількість чисел у номері паспорта: " + value + ", має бути 9-ть чисел");
                }
                passport = value;
            }
        }
        public int Age
        {
            get => age;
            set
            {
                // перевіряє чи вказана кількість років студента поміщяється в адекватні рамки
                if (value < 10)
                {
                    throw new Exception("Студентові не може бути менше 10 років, вказано: " + value);
                }
                else if (value > 100)
                {
                    throw new Exception("Студентові не може бути більше 100 років, вказано: " + value);
                }
                age = value;
            }
        }
        public string Telephon
        {
            get => telephon;
            set
            {
                // Перевірка чи в мобільному номері є якісь символи окрім чисел
                TestIsNumber(value, "У мобільному номері присутні заборонені символи");
                if (value.Length != 12)
                {
                    throw new Exception("Невірно вказано номер телефона: " + value + ", номер має бути в форматі: 380XXXXXXXXX");
                }
                telephon = value;
            }
        }
        public double Rating
        {
            get => rating;
            set
            {
                // перевірка чи вказаний рейтинг попадає в діапазон від 0 до 100
                if (value < 0 || value > 100)
                {
                    throw new Exception("Під рейтингом розуміється середній бал за 100 - ою системою. Він не може дорівнювати: " + value);
                }
                rating = value;
            }
        }

        public Student() // Конструктор без параметрів
        {
            // значення за замовчуванням
            Name = "Anonimous";
            LastName = "Anonimous";
            Group = "null";
            Year = 1980;
            Adress = "null";
            Passport = "000000000";
            Age = 10;
            Telephon = "000000000000";
            Rating = 0;
        }

        public Student(string s) // Конструктор з параметром
        {
            // Створення масива "х" в якому зберігаються дані студента
            string[] x = s.Split(';').Select(tag => tag.Trim()).ToArray();

            if (x.Length != 9) // Якщо вказані не всі дані, або їх забагато, повідомляє як має бути оформлена база
            {
                throw new Exception("Дані в базі мають бути в такому форматі: \n" +
                "         Ім'я; Прізвище; Група; Рік (поступання); Адреса; Паспорт; Років (студентові); Телефон; Рейтинг \n");
            }

            // // Перевірка чи там де мають бути лише числа, є лише числа, і повідомляє якщо це не так
            TestIsNumber(x[3], "Невірно введено рік поступання, використано заборонені символи");
            TestIsNumber(x[6], "Невірно введено рік, використано заборонені символи");
            TestIsNumber(x[8], "Невірно взакано рейтинг, використано заборонені символи");

            Name = x[0];
            LastName = x[1];
            Group = x[2];
            Year = Convert.ToInt32(x[3]);
            Adress = x[4];
            Passport = x[5];
            Age = Convert.ToInt32(x[6]);
            Telephon = x[7];
            Rating = Convert.ToDouble(x[8]);
        }

        public static void StudentRating(int R)
        {
            Console.Write("\nСередній рейтинг студента: {0}, ", R);
            if (R >= 90)
            {
                Console.Write("Вітаємо відмінника\n");
            }
            else if (R >= 75)
            {
                Console.Write("можна вчитися краще\n");
            }
            else
            {
                Console.Write("Варто більше уваги приділяти навчанню\n");
            }
        }
        public override string ToString() // в якому форматі виводити дані на екран
        {
            const int size = -12;
            return string.Format($"" +
                $"{"# Ім'я:",size}{Name}\n" +
                $"{"# Прізвище:",size}{LastName}\n" +
                $"{"# Група:",size}{Group}\n" +
                $"{"# Рік:",size}{Year}\n" +
                $"{"# Адреса:",size}{Adress}\n" +
                $"{"# Паспорт:",size}{Passport}\n" +
                $"{"# Років:",size}{Age}\n" +
                $"{"# Телефон:",size}{Telephon}\n" +
                $"{"# Рейтинг:",size}{Rating,3:F2}");
        }

        public int Compare(string LastName) // порівняння прізвища, якщо вони одинакові повертає 0
        {
            return string.Compare(this.LastName, LastName);
        }

        private static void TestIsLetter(string str, string ErrorMessage)
        {
            // Перевірка чи в str є якісь символи окрім літер, і якщо є то створює виключення з текстом ErrorMessage
            for (int i = 0; i < str.Length; i++)
            {
                if (!char.IsLetter(str[i]))
                {
                    Console.WriteLine("Причина помилки: \"{0}\"", str);
                    throw new Exception(ErrorMessage);
                }
            }
        }

        private static void TestIsLetterIsNumberIsTire(string str, string ErrorMessage)
        {
            // Перевірка чи в str є якісь символи окрім літер чисел і тире, і якщо є то створює виключення з текстом ErrorMessage
            for (int i = 0; i < str.Length; i++)
            {
                if (!char.IsLetter(str[i]) && !char.IsNumber(str[i]) && !(str[i] == '-'))
                {
                    Console.WriteLine("Причина помилки: \"{0}\"", str);
                    throw new Exception(ErrorMessage);
                }
            }
        }

        private static void TestIsNumber(string str, string ErrorMessage)
        {
            // Перевірка чи str є числом, і якщо не є то створює виключення з текстом ErrorMessage
            if (!double.TryParse(str, out _))
            {
                Console.WriteLine("Причина помилки: \"{0}\"", str);
                throw new Exception(ErrorMessage);
            }
        }
    }
}
