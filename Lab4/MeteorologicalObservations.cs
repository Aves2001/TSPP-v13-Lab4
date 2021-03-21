using System;
using System.Linq;

namespace Lab4
{
    public class MeteorologicalObservations
    {
        private string date;
        private double temperature;
        private double atmosphericPressure;

        public string Date
        {
            get => date;
            set
            {
                TestIsDate(value);
                date = value;
            }
        }
        public double Temperature
        {
            get => temperature;
            set => temperature = value;
        }
        public double AtmosphericPressure
        {
            get => atmosphericPressure;
            set => atmosphericPressure = value;
        }

        public MeteorologicalObservations()
        {
            Date = "01.01.0001";
            Temperature = 0;
            AtmosphericPressure = 0;
        }

        public MeteorologicalObservations(string s)
        {
            // Створення масива "х" в якому зберігаються дані студента
            string[] x = s.Split(';').Select(tag => tag.Trim()).ToArray();

            if (x.Length != 3) // Якщо вказані не всі дані, або їх забагато, повідомляє як має бути оформлена база
            {
                throw new Exception("Дані в базі мають бути в такому форматі: \n" +
                "         дата, температура, атмосферний тиск \n");
            }

            TestIsNumber(x[1], "Невірно введено температуру, використано заборонені символи");
            TestIsNumber(x[2], "Невірно введено атмосферний тиск, використано заборонені символи");

            Date = x[0];
            Temperature = double.Parse(x[1]);
            AtmosphericPressure = double.Parse(x[2]);
        }

        public override string ToString() // в якому форматі виводити дані на екран
        {
            const int size = -12;
            return string.Format($"{"|"}{Date,size} {"|"}{Temperature + "°",size} {"|"}{AtmosphericPressure + "мм",size}|\n" +
                                 "==========================================");
        }

        // порівняння дати
        public static int CompareDate(MeteorologicalObservations a, MeteorologicalObservations b)
        {
            return a.Date.CompareTo(b.Date);
        }

        // порівняння атмосферного тиску
        public static int CompareAtmosphericPressure(MeteorologicalObservations a, MeteorologicalObservations b)
        {
            return a.AtmosphericPressure.CompareTo(b.AtmosphericPressure);
        }

        public static void ViewArray(MeteorologicalObservations[] metObs)
        {
            Console.WriteLine("==========================================");
            Console.WriteLine("|    Дата     | Температура |    Тиск    |");
            Console.WriteLine("==========================================");
            foreach (MeteorologicalObservations item in metObs)
            {
                Console.WriteLine(item);
            }
        }

        // Повертає два дні з найбільшим перепадом тиску
        public static MeteorologicalObservations[] TheLargestPressureDrop(MeteorologicalObservations[] metObs1)
        {
            MeteorologicalObservations[] metObs = new MeteorologicalObservations[metObs1.Length];
            Array.Copy(metObs1, metObs, metObs1.Length);

            // Сортування масива по даті
            Array.Sort(metObs, CompareDate);

            // Max - для збереження двох днів з найбільшим перепадом тиску
            MeteorologicalObservations[] Max = new MeteorologicalObservations[2];

            // х - масив в якому зберігаються дані про перепади тиску на кожні два дні
            double[] x = new double[metObs.Length - 1];

            // цикл в якому тиск сьогодні віднімається від тиску завтра і так далі, результат зберігається з додатнім знаком
            for (int i = 0; i < x.Length; i++)
            {
                double tmp = metObs[i].AtmosphericPressure - metObs[1 + i].AtmosphericPressure;
                if (tmp < 0)
                {
                    x[i] = -tmp;
                }
                else
                {
                    x[i] = tmp;
                }
            }
            //for (int i = 0; i < x.Length; i++)
            //{
            //    Console.WriteLine("{0,2} = {1}", 01 + i, x[i]);
            //}
            double max = x.Max(); // знаходження максимального перепаду тиску (це буде перший день)
            int index = Array.IndexOf(x, max);// збереження індекса де він знаходиться в масиві (x)
            Max[0] = metObs[index];      // збереження першого
            Max[1] = metObs[1 + index]; // та другого дня, з найбільшим перепадом тиску

            return Max;
        }

        private void TestIsDate(string s)
        {
            if (!DateTime.TryParseExact(s, "dd.mm.yyyy", null, System.Globalization.DateTimeStyles.None, out _))
            {
                Console.WriteLine("Причина помилки: " + s);
                throw new Exception("Невірний формат дати\n" +
                                    "Дата має бути у форматі: \"dd.mm.yyyy\"");
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
