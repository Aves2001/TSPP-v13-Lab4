using System;
using System.IO;
using System.Linq;

namespace Lab4
{
    public class Storage
    {
        private const int maxLength = -20;
        private static string file_name;
        private string inventoryNumber, productName, weight, price, number;

        public static string FILE_NAME
        {
            get => file_name;
            set
            {
                if (value.Length > 150)
                {
                    throw new Exception("Кількість символів в назві файла не може перевищювати 150 символів.\nВказана назва файла: " + value);
                }
                file_name = value;
            }
        }
        public string InventoryNumber
        {
            get => inventoryNumber;
            set
            {
                TestMaxLength(value);
                if (value.Equals("null")) { }
                else
                {
                    TestIsNumber(value, "Введено невірний Інвентарний номер");
                    inventoryNumber = Convert.ToString(int.Parse(value));
                }
                inventoryNumber = value;
            }
        }
        public string ProductName
        {
            get => productName;
            set
            {
                TestMaxLength(value);
                productName = value;
            }
        }
        public string Weight
        {
            get => weight;
            set
            {
                TestMaxLength(value);
                TestIsNumber(value, "Введено невірну вагу, використано заборонені символи");
                if (value.Equals("null")) { weight = "null"; }
                else if (!int.TryParse(value, out _))
                {
                    weight = Convert.ToString(double.Parse(value) / 0.001);
                }
                else
                {
                    weight = value;
                }
            }
        }
        public string Price
        {
            get => price;
            set
            {
                TestMaxLength(value);
                TestIsNumber(value, "Введено невірну ціну, використано заборонені символи");
                price = value;
            }
        }
        public string Number
        {
            get => number;
            set
            {
                TestMaxLength(value);
                TestIsNumber(value, "Введено невірну кількість, використано заборонені символи");
                number = value;
            }
        }

        public Storage()
        {
            InventoryNumber = "null";
            ProductName = "null";
            Weight = "null";
            Price = "null";
            Number = "null";
        }
        public Storage(string s)
        {
            // Створення масива "х" в якому зберігаються дані студента
            string[] x = s.Split(';').Select(tag => tag.Trim()).Where(tag => !string.IsNullOrEmpty(tag)).ToArray();

            if (x.Length != 5) // Якщо вказані не всі дані, або їх забагато, повідомляє як має бути оформлена база
            {
                throw new Exception("\nДані в базі мають бути в такому форматі: Інвентарний номер; назва товару; вага; ціна; кількість\n" +
                "\nПричина помилки: " + s);
            }

            InventoryNumber = x[0];
            ProductName = x[1];
            Weight = x[2];
            Price = x[3];
            Number = x[4];
        }

        public override string ToString() // в якому форматі виводити дані на екран
        {
            string Weights = Weight;
            string Prices = Price;
            if (double.TryParse(Weight, out double res) && res > 999)
            {
                res *= 0.001;
                Weights = Convert.ToString(res) + " кг.";
            }
            else if (int.TryParse(Weight, out _))
            {
                Weights += " г.";
            }
            else if (double.TryParse(Weight, out _))
            {
                Weights += " кг.";
            }
            if (!Prices.Equals("null"))
            {
                Prices += " грн.";
            }
            return string.Format($"{"|"}{InventoryNumber,maxLength} {"|"}{ProductName,maxLength * 2} {"|"}{Weights,maxLength + 7} {"|"}{Prices,maxLength + 7} {"|"}{Number,maxLength + 11}|\n" +
                                 "=========================================================================================================");
        }

        public static void ViewTable()
        {
            Storage[] tovar = InputStorage();
            if (tovar.Length > 0)
            {
                TableCap();
                foreach (Storage item in tovar)
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                Console.WriteLine("Файл порожній");
            }
        }

        public static void ViewTable(Storage[] tovar)
        {

            if (tovar.Length > 0)
            {
                TableCap();
                foreach (Storage item in tovar)
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                Console.WriteLine("Файл порожній");
            }
        }

        public static void ViewTable(Storage tovar)
        {
            TableCap();
            Console.WriteLine(tovar);
        }

        public static void TableCap()
        {
            Console.WriteLine("=========================================================================================================");
            Console.WriteLine("|  Інвентарний номер  |               Назва  товару             |     Вага     |     Ціна     |Кількість|");
            Console.WriteLine("=========================================================================================================");
        }
        ///////////////////////////////////////////////////////////////////////
        public static int CheckSizeArray() // провірка який розмір має мати масив
        {
            int size = 0;
            using (StreamReader f = new StreamReader(FILE_NAME))
            {
                while ((_ = f.ReadLine()) != null) { ++size; }
                f.Close();
                return size;
            }
        }

        public static Storage[] InputStorage()
        {
            // створення масива для роботи з базою даних, розміром - кількість записів (рядків) в базі
            Storage[] tovar = new Storage[CheckSizeArray()];
            using (StreamReader f = new StreamReader(FILE_NAME))
            {
                string s; // для збереження рядка з бази даних
                int i = 0; // індекс для масива
                while ((s = f.ReadLine()) != null) // запис рядка з бази в масив
                {
                    tovar[i] = new Storage(s);
                    ++i;
                }
                f.Close(); // закриття файла
            }
            return tovar;
        }

        public static void OutputStorage(Storage[] tovar)
        {
            using (StreamWriter f = new StreamWriter(FILE_NAME))
            {
                foreach (Storage item in tovar)
                {
                    f.Write(item.InventoryNumber + "; ");
                    f.Write(item.ProductName + "; ");
                    f.Write(item.Weight + "; ");
                    f.Write(item.Price + "; ");
                    f.WriteLine(item.Number);
                }
                f.Close(); // закриття файла
            }
        }

        public static void OutputStorage(Storage tovar)
        {
            using (StreamWriter f = new StreamWriter(FILE_NAME, true))
            {
                f.Write(tovar.InventoryNumber + "; ");
                f.Write(tovar.ProductName + "; ");
                f.Write(tovar.Weight + "; ");
                f.Write(tovar.Price + "; ");
                f.WriteLine(tovar.Number);
                f.Close(); // закриття файла
            }
        }
        ///////////////////////////////////////////////////////////////////////
        public static void AddTovar()
        {
            Storage newTovar = new Storage();
            if (FILE_NAME != "Storage_test.txt")
            {
                char x;
                do
                {
                    Console.WriteLine("\nІнвентарний номер:");
                    newTovar.InventoryNumber = ReadInvNum();

                    Console.WriteLine("Назву товару:");
                    newTovar.ProductName = TestIsLetter();

                    Console.WriteLine("Вагу:");
                    newTovar.Weight = TestIsNumber();

                    Console.WriteLine("Ціну:");
                    newTovar.Price = TestIsNumber();

                    Console.WriteLine("Кількість:");
                    newTovar.Number = TestIsNumber();

                    Console.Clear();
                    ViewTable(newTovar);
                    Console.WriteLine("Для збереження натисніть [Enter]");
                    Console.WriteLine("Для скасування додавання натисніть будьяку клавішу");

                    x = Console.ReadKey(true).KeyChar;

                    if (x == (char)ConsoleKey.Escape) { return; }
                } while (x != (char)ConsoleKey.Enter);
            }
            else
            {
                newTovar.InventoryNumber = "null";
                newTovar.ProductName = "null";
                newTovar.Weight = "null";
                newTovar.Price = "null";
                newTovar.Number = "null";
            }
            OutputStorage(newTovar);
        }

        public static void EditTovar()
        {
            Storage[] tovar = InputStorage();

            ViewTable(tovar);
            string[] test = new string[tovar.Length];
            test = tovar.Select(tag => tag.InventoryNumber).ToArray();
            int index;
            do
            {
                Console.Write("Введіть Інвентарний номер товару який потрібно редагувати: \n>");
                string invNum = Console.ReadLine();

                index = Array.IndexOf(test, invNum);
                if (index != -1)
                {
                    char x = 'z';
                    do
                    {
                        Console.Clear();
                        Console.WriteLine("\n");
                        if (x == '0')
                        {
                            Console.WriteLine("====================================Такого пункта немає===================================\n");
                        }
                        ViewTable(tovar[index]);
                        Console.WriteLine("Виберіть що саме потрібно редагувати:");
                        Console.WriteLine("[1] Інвентарний номер");
                        Console.WriteLine("[2] Назву товару");
                        Console.WriteLine("[3] Вагу");
                        Console.WriteLine("[4] Ціну");
                        Console.WriteLine("[5] Кількість");
                        Console.WriteLine("[ESC] Вихід");
                        x = Console.ReadKey(true).KeyChar;

                        switch (x)
                        {
                            case (char)ConsoleKey.Escape:
                                Console.WriteLine("++++++++++++");
                                break;

                            case '1':
                                tovar[index].InventoryNumber = ReadInvNum(tovar);
                                break;

                            case '2':
                                tovar[index].ProductName = TestIsLetter();
                                break;

                            case '3':
                                tovar[index].Weight = TestIsNumber();
                                break;

                            case '4':
                                tovar[index].Price = TestIsNumber();
                                break;

                            case '5':
                                tovar[index].Number = TestIsNumber();
                                break;

                            default:
                                x = '0';
                                break;
                        }
                        Console.WriteLine("==");
                    } while (x != (char)ConsoleKey.Escape);
                }
            } while (index == -1);
            OutputStorage(tovar);
        }

        public static void DellTovar()
        {
            Storage[] tovar = InputStorage();
            ViewTable(tovar);
            Console.Write("\nВведіть Інвентарний номер товару який потрібно видалити:\n>");
            string delInv = Console.ReadLine();

            for (int i = 0; i < tovar.Length; i++)
            {
                if (int.Parse(tovar[i].InventoryNumber).Equals(int.Parse(delInv)))
                {
                    tovar = tovar.Where(val => val != tovar[i]).ToArray();
                }
            }
            OutputStorage(tovar);
        }

        public static int TestInvNum()
        {
            int num = 0;
            Storage[] tovar = InputStorage();
            for (int i = 0; i < tovar.Length - 1; i++)
            {
                for (int j = 0; j < tovar.Length - 1; j++)
                {
                    if ((2 + j) - (1 + i) == 0)
                    {
                        continue;
                    }
                    else if (tovar[i].InventoryNumber.Equals(tovar[1 + j].InventoryNumber))
                    {
                        num++;
                        Console.WriteLine("\nТовари:");
                        TableCap();
                        Console.WriteLine("" +
                                            tovar[i] + "\n" +
                                            tovar[1 + j] + "\n" +
                                            "\nМають одинакові інвентарні номери\n" +
                                            "В базі ці записи знаходяться у рядках: " + (1 + i) + " --- " + (2 + j) +
                                            "\n------------------------------------------------------------------------------------------");
                    }
                }
            }
            return num;
        }
        private static bool TestInvNum(Storage[] tovar, Storage newTovar)
        {
            foreach (var item in tovar)
            {
                if (item.InventoryNumber.Equals(newTovar.InventoryNumber))
                {
                    return true;
                }
            }
            return false;
        }
        private static string ReadInvNum(Storage[] tovar)
        {
            bool ok;
            Storage tovars = new Storage();
            do
            {
                tovars.InventoryNumber = TestIsNumber();
                ok = TestInvNum(tovar, tovars);
                if (ok)
                {
                    Console.WriteLine("Товар з таким інвентарним номером уже є, задайте інший або відредагуйте дані уже існуючого товару");
                }
            } while (ok);
            return tovars.InventoryNumber;
        }
        private static string ReadInvNum()
        {
            Storage[] tovar = InputStorage();
            bool ok;
            Storage tovars = new Storage();
            do
            {
                tovars.InventoryNumber = TestIsNumber();
                ok = TestInvNum(tovar, tovars);
                if (ok)
                {
                    Console.WriteLine("Товар з таким інвентарним номером уже є, задайте інший або відредагуйте дані уже існуючого товару");
                }
            } while (ok);
            return tovars.InventoryNumber;
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public static int ProductSearch()
        {
            Storage[] tovar = InputStorage();

            string tovarSearch = TestIsLetter();
            int num = 0;
            for (int i = 0; i < tovar.Length; i++)
            {
                if (tovar[i].ProductName.Contains(tovarSearch))
                {
                    TableCap();
                    for (int j = i; j < tovar.Length; j++)
                    {
                        if (tovar[j].ProductName.Contains(tovarSearch))
                        {
                            num++;
                            Console.WriteLine(tovar[j]);
                        }
                    }
                    break;
                }
            }
            Console.WriteLine("\nЗнайдено записів = {0}\n", num);
            return num;
        }

        public static void SortTovar()
        {
            Storage[] tovar = InputStorage();
            char x;
            string pole = "null";
            do
            {
                Console.WriteLine("Виберіть за яким полем виконати сортування:\n");

                Console.WriteLine("[1] --- Інвентарний номер");
                Console.WriteLine("[2] --- Назва товару");
                Console.WriteLine("[3] --- Вага");
                Console.WriteLine("[4] --- Ціна");
                Console.WriteLine("[5] --- Кількість");

                Console.WriteLine("\n[ESC] --- Вихід\n");

                Console.Write(">");
                x = Console.ReadKey(true).KeyChar;
                Console.Clear();
                switch (x)
                {
                    case (char)ConsoleKey.Escape:
                        break;

                    case '1':
                        Array.Sort(tovar, (a, b) => CompareInventoryNumber(a, b));
                        OutputStorage(tovar);
                        pole = "Інвентарний номер";
                        break;

                    case '2':
                        Array.Sort(tovar, (a, b) => CompareProductName(a, b));
                        OutputStorage(tovar);
                        pole = "Назва товару";
                        break;

                    case '3':
                        Array.Sort(tovar, (a, b) => CompareWeight(a, b));
                        OutputStorage(tovar);
                        pole = "Вага";
                        break;

                    case '4':
                        Array.Sort(tovar, (a, b) => ComparePrice(a, b));
                        OutputStorage(tovar);
                        pole = "Ціна";
                        break;

                    case '5':
                        Array.Sort(tovar, (a, b) => CompareNumber(a, b));
                        OutputStorage(tovar);
                        pole = "Кількість";
                        break;

                    default:
                        x = '0';
                        Console.WriteLine("\nПомилка: Такого пункта немає\n\n");
                        break;
                }
            } while (x == '0');
            if (!pole.Equals("null"))
            {
                Console.WriteLine("База відcортована за полем: " + pole);
            }
        }
        private static int CompareInventoryNumber(Storage a, Storage b)
        {
            _ = double.TryParse(a.InventoryNumber, out double A);
            _ = double.TryParse(b.InventoryNumber, out double B);
            return A.CompareTo(B);
        }
        private static int CompareProductName(Storage a, Storage b)
        {
            return a.ProductName.CompareTo(b.ProductName);
        }
        private static int CompareWeight(Storage a, Storage b)
        {
            _ = double.TryParse(a.Weight, out double A);
            _ = double.TryParse(b.Weight, out double B);
            return A.CompareTo(B);
        }
        private static int ComparePrice(Storage a, Storage b)
        {
            _ = double.TryParse(a.Price, out double A);
            _ = double.TryParse(b.Price, out double B);
            return A.CompareTo(B);
        }
        private static int CompareNumber(Storage a, Storage b)
        {
            _ = double.TryParse(a.Number, out double A);
            _ = double.TryParse(b.Number, out double B);
            return A.CompareTo(B);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private static void TestIsNumber(string str, string ErrorMessage)
        {
            if (str.Equals("null"))
            {
                return;
            }
            // Перевірка чи str є числом, і якщо не є то створює виключення з текстом ErrorMessage
            if (!double.TryParse(str, out _))
            {
                Console.WriteLine("Причина помилки: \"{0}\"", str);
                throw new Exception(ErrorMessage);
            }
        }

        private static bool TestIsNumber(string str)
        {
            if (!double.TryParse(str, out _))
            {
                return false;
            }
            return true;
        }
        private static string TestIsNumber()
        {
            string tmp;
            bool tmp_bool;
            do
            {
                Console.Write(">");
                tmp = Console.ReadLine();
                if (tmp == null || tmp.Equals(""))
                {
                    return "null";
                }
                tmp_bool = TestIsNumber(tmp);
                if (!tmp_bool)
                {
                    Console.WriteLine("Помилка введіть ще раз!");
                }
            } while (!tmp_bool);
            return tmp;
        }
        private static string TestIsLetter()
        {
            string tmp;
            bool tmp_bool;
            do
            {
                Console.Write(">");
                tmp = Console.ReadLine();

                if (tmp == null || tmp.Equals(""))
                {
                    return "null";
                }
                tmp_bool = TestIsLetter(tmp);
                if (!tmp_bool)
                {
                    Console.WriteLine("Помилка введіть ще раз!");
                }
            } while (!tmp_bool);
            return tmp;
        }
        private static bool TestIsLetter(string str)
        {
            if (str.Length > -maxLength)
            {
                return false;
            }
            return true;
        }

        private static void TestMaxLength(string str)
        {
            if (str.Length > -maxLength * 2)
            {
                Console.WriteLine("Причина помилки: " + str);
                throw new Exception("Кількість символів не може бути довша за " + (-maxLength * 2) + " символів");
            }
        }
    }
}
