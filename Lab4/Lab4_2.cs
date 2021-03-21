using System;
using System.IO;

namespace Lab4
{
    class Lab4_2
    {
        private static string FILE_NAME;  // для збереження імені файла з яким потрібно працювати
        public static int CheckSizeArray() // провірка який розмір має мати масив
        {
            int size = 0; // кількість рядків в базі
            StreamReader f = new StreamReader(FILE_NAME);
            while ((_ = f.ReadLine()) != null) { ++size; }
            f.Close();
            return size;
        }

        public static void Program(string FILE)
        {
            try
            {
                if (FILE == null) // якщо не передали файл з яким працювати, використовувати стандартний
                {
                    FILE_NAME = "Meteorological_Observations.txt";
                }
                else // інакше працювати з файлом який передали програмі
                {
                    if (FILE.Length > 150)
                    {
                        throw new Exception("Кількість символів в назві файла не може перевищювати 150 символів.\nВказана назва файла: " + FILE);
                    }
                    FILE_NAME = FILE;
                }

                // створення масива для роботи з базою даних, розміром - кількість записів (рядків) в базі
                MeteorologicalObservations[] metObs = new MeteorologicalObservations[CheckSizeArray()];
                string s; // для збереження рядка з бази даних
                int i = 0; // індекс для масива
                using (StreamReader f = new StreamReader(FILE_NAME))
                {
                    while ((s = f.ReadLine()) != null) // запис рядка з бази в масив
                    {
                        metObs[i] = new MeteorologicalObservations(s);
                        ++i;
                    }
                    f.Close(); // закриття файла
                }

                // Сортування масива за атмосферним тиском
                Array.Sort(metObs, MeteorologicalObservations.CompareAtmosphericPressure);

                Console.WriteLine("\n       Метеорологічні спостереження\n    протягом лютого 2021р. в Чернівцях\n");
                MeteorologicalObservations.ViewArray(metObs); // вивід масива в консоль

                Console.WriteLine("\n  Два дні з найбільшим перепадом тиску:");

                MeteorologicalObservations.ViewArray // ViewTable --- виводить масив в консоль
                (   // TheLargestPressureDrop --- Повертає два дні з найбільшим перепадом тиску
                    MeteorologicalObservations.TheLargestPressureDrop(metObs)
                );

                _ = Console.ReadKey(true); // пауза
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
