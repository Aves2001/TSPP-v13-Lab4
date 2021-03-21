using System;
using System.IO;

namespace Lab4
{
    public class Lab4_1 // Перше завдання
    {
        private static string FILE_NAME = null; // для збереження імені файла з яким потрібно працювати
        private static int CheckSizeArray() // провірка який розмір має мати масив
        {
            int size = 0; // кількість рядків в базі
            using (StreamReader f = new StreamReader(FILE_NAME))
            {
                while ((_ = f.ReadLine()) != null) { ++size; }
                f.Close();
            }
            return size;
        }
        public static void Program(string FILE)
        {
            try
            {
                if (FILE == null) // якщо не передали файл з яким працювати, використовувати стандартний
                {
                    FILE_NAME = "dbase.txt";
                }
                else // інакше працювати з файлом який передали програмі
                {
                    if (FILE.Length > 150)
                    {
                        throw new Exception("Кількість символів в назві файла не може перевищювати 150 символів.\nВказана назва файла: " + FILE);
                    }
                    FILE_NAME = FILE;
                }
                int size = CheckSizeArray(); // Присвоєння розміру яке буде у масива
                Student[] dbase = new Student[size]; // створення масива, в якому будуть зберігадись дані про студентів

                string s; // для збереження рядка з бази
                int i = 0; // індекс для масива dbase
                using (StreamReader f = new StreamReader(FILE_NAME))
                {
                    // запис рядка з бази в масив
                    while ((s = f.ReadLine()) != null)
                    {
                        dbase[i] = new Student(s); // порядково записує дані з бази у масив
                        Console.WriteLine("############################");
                        Console.WriteLine(dbase[i]); // виводить інформації про студента в консоль
                        Console.WriteLine();
                        ++i; // збільшення індекса
                    }
                    f.Close(); // закриття файла
                    Console.WriteLine("### Кінець файла ###\n");
                }
                //////////////////////////////////////////////////////////////////////////////
                uint amountOfStudents; //кількість студентів (лічильник)
                double summRating; //сумма рейтингу
                string lastName; // зразок для пошуку в базі

                Console.Write("Введіть прізвище студента:\n>");
                while ((lastName = Console.ReadLine()) != "")
                {
                    amountOfStudents = 0;
                    summRating = 0;
                    bool not_found = true; // якщо студента з таким прізвищем не знайдено, прапорель true
                    for (int j = 0; j < size; ++j) // цикл по масиву з студентами
                    {
                        // якщо вказане прізвище є в масиві з студентами
                        if (dbase[j].Compare(lastName) == 0)
                        {
                            //виводить їх на екран
                            Console.WriteLine("\n********************");
                            Console.WriteLine(dbase[j]);
                            ++amountOfStudents; // вивели студента на екран, лічильник +1
                            summRating += dbase[j].Rating; //сумма рейтингу поточного студента
                            not_found = false; // якщо такий студент є, флажок false
                        }
                    }
                    // якщо флажок true, виводить відповедне повідомлення
                    if (not_found)
                    {
                        Console.WriteLine("\nТакого студента немає");
                    }

                    // якщо лічильник більший за нуль, виводить середній рейтинг студента, та відповідне повідомлення
                    if (amountOfStudents > 0)
                    {
                        Student.StudentRating(Convert.ToInt32(summRating / amountOfStudents));
                    }
                    Console.Write("\nВведіть прізвище студента або Enter для завершення:\n>");
                }
            }
            catch (FileNotFoundException e) //якщо файл відсутній
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Перевірте правильність імені і шляху до файлу!");
                _ = Console.ReadKey(true); return;
            }
            catch (Exception e) // в любій не понятній ситуації виводить помилку на екран
            {
                Console.WriteLine("Помилка: " + e.Message);
                _ = Console.ReadKey(true); return;
            }
        }
    }
}
