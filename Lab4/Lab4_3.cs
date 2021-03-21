using System;
using System.IO;

namespace Lab4
{
    class Lab4_3
    {
        public static void Program(string FILE)
        {
            try
            {
                if (FILE == null) // якщо не передали файл з яким працювати, використовувати стандартний
                {
                    Storage.FILE_NAME = "Storage.txt";
                }
                else // інакше працювати з файлом який передали програмі
                {
                    Storage.FILE_NAME = FILE;
                }

                char x; // для збереження натиснутої клавіші
                do
                {
                    Console.WriteLine("\nГарячі клавіші:" +
                                  "\t[Д] -------- додавання записів\n" +
                                  "\t\t[Р] -------- редагування записів\n" +
                                  "\t\t[Delete] --- знищення записів\n" +
                                  "\t\t[В] -------- виведення інформації з файла на екран\n" +
                                  "\t\t[П] -------- пошук товару за його назвою\n" +
                                  "\t\t[С] -------- сортування за різними полями\n" +
                                  "\t\t[ESC] ---- вихід");

                    _ = Storage.TestInvNum(); // перевіряє чи у файлі є одинакові інвентарні номери, і якщо є то виводить їх в консоль, та вказує в яких рядках води знаходяться в базі
                    x = Console.ReadKey(true).KeyChar; // збереження натиснутої клавіші

                    switch (x)
                    {
                        case 'Д':
                        case 'д':
                        case 'L':
                        case 'l':
                            Storage.AddTovar(); // додавання записів в кінець файла
                            Console.Clear();
                            break;

                        case 'Р':
                        case 'р':
                        case 'H':
                        case 'h':
                            Storage.EditTovar(); // редагування записів
                            Console.Clear();
                            break;

                        case (char)ConsoleKey.Delete:
                        case (char)0:
                            Storage.DellTovar(); // знищення записів
                            Console.Clear();
                            break;

                        case 'В':
                        case 'в':
                        case 'D':
                        case 'd':
                            Console.Clear();
                            Storage.ViewTable(); // виведення інформації з файла на екран
                            break;

                        case 'П':
                        case 'п':
                        case 'G':
                        case 'g':
                            _ = Storage.ProductSearch(); // пошук товару за його назвою
                            break;

                        case 'С':
                        case 'с':
                        case 'C':
                        case 'c':
                            Console.Clear();
                            Storage.SortTovar(); // сортування за різними полями
                            break;

                        default: break;
                    }
                } while (x != (char)ConsoleKey.Escape); // якщо нажали ESC виходить з програми
            }
            catch (FileNotFoundException e) //якщо файл відсутній
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Перевірте правильність імені і шляху до файлу!");
                _ = Console.ReadKey(true); return;
            }
            catch (Exception e) // виводить причину помилки в консоль
            {
                Console.WriteLine("Помилка: " + e.Message);
                _ = Console.ReadKey(true); return;
            }
        }
    }
}
