using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace UnitTestLab4_3
{
    [TestClass]
    public class GetSet
    {
        [TestMethod]
        public void SetGetInventoryNumber()
        {
            string test = "1";
            Lab4.Storage storage = new Lab4.Storage
            {
                InventoryNumber = test
            };
            Assert.IsTrue(storage.InventoryNumber.Equals(test));
        }

        [TestMethod]
        public void SetGetProductName()
        {
            string test = "SSD 120 GB";
            Lab4.Storage storage = new Lab4.Storage
            {
                ProductName = test
            };
            Assert.IsTrue(storage.ProductName.Equals(test));
        }

        [TestMethod]
        public void SetGetWeight()
        {
            string test = "450", test2 = "1500";
            Lab4.Storage storage = new Lab4.Storage
            {
                Weight = test
            };
            Assert.IsTrue(storage.Weight.Equals(test));

            storage.Weight = test2;
            Assert.IsTrue(storage.Weight.Equals(test2));
        }

        [TestMethod]
        public void SetGetPrice()
        {
            string test = "500";
            Lab4.Storage storage = new Lab4.Storage
            {
                Price = test
            };
            Assert.IsTrue(storage.Price.Equals(test));
        }

        [TestMethod]
        public void SetGetNumber()
        {
            string test = "3";
            Lab4.Storage storage = new Lab4.Storage
            {
                Number = test
            };
            Assert.IsTrue(storage.Number.Equals(test));
        }
    }

    [TestClass]
    public class SetFail
    {
        [TestMethod]
        public void SetInventoryNumberFail()
        {
            bool ok = false, ok2 = false;
            
            string test = "12das", test2 = "11111111111111111111111111111";

            try
            {
                Lab4.Storage storage = new Lab4.Storage
                {
                    InventoryNumber = test
                };
            }
            catch (System.Exception)
            {
                ok = true;
            }
            Assert.IsTrue(ok);

            try
            {
                Lab4.Storage storage = new Lab4.Storage
                {
                    InventoryNumber = test2
                };
            }
            catch (System.Exception)
            {
                ok2 = true;
            }
            Assert.IsTrue(ok2);
        }

        [TestMethod]
        public void SetProductNameFail()
        {
            bool ok = false;

            string test = "11111111111111111111111111111";

            try
            {
                Lab4.Storage storage = new Lab4.Storage
                {
                    ProductName = test
                };
            }
            catch (System.Exception)
            {
                ok = true;
            }
            Assert.IsTrue(ok);
        }

        [TestMethod]
        public void SetWeightFail()
        {
            bool ok = false, ok2 = false;

            string test = "15h", test2 = "11111111111111111111111111111";
            try
            {
                Lab4.Storage storage = new Lab4.Storage
                {
                    Weight = test
                };
            }
            catch (System.Exception)
            {
                ok = true;
            }
            Assert.IsTrue(ok);

            try
            {
                Lab4.Storage storage = new Lab4.Storage
                {
                    Weight = test2
                };
            }
            catch (System.Exception)
            {
                ok2 = true;
            }
            Assert.IsTrue(ok2);
        }

        [TestMethod]
        public void SetPriceFail()
        {
            bool ok = false, ok2 = false;

            string test = "15h", test2 = "11111111111111111111111111111";
            try
            {
                Lab4.Storage storage = new Lab4.Storage
                {
                    Price = test
                };
            }
            catch (System.Exception)
            {
                ok = true;
            }
            Assert.IsTrue(ok);

            try
            {
                Lab4.Storage storage = new Lab4.Storage
                {
                    Price = test2
                };
            }
            catch (System.Exception)
            {
                ok2 = true;
            }
            Assert.IsTrue(ok2);
        }

        [TestMethod]
        public void SetNumberFail()
        {
            bool ok = false, ok2 = false;

            string test = "15h", test2 = "11111111111111111111111111111";
            try
            {
                Lab4.Storage storage = new Lab4.Storage
                {
                    Number = test
                };
            }
            catch (System.Exception)
            {
                ok = true;
            }
            Assert.IsTrue(ok);

            try
            {
                Lab4.Storage storage = new Lab4.Storage
                {
                    Number = test2
                };
            }
            catch (System.Exception)
            {
                ok2 = true;
            }
            Assert.IsTrue(ok2);
        }
    }

    [TestClass]
    public class Method
    {
        [TestMethod]
        public void CheckSizeArray()
        {
            Lab4.Storage.FILE_NAME = "Storage_test.txt";

            Lab4.Storage[] test = new Lab4.Storage[3];
            test[0] = new Lab4.Storage("0001; Test 2; 1; 6; 5");
            test[1] = new Lab4.Storage("0002; Test 2; 1; 6; 5");
            test[2] = new Lab4.Storage("0003; Test 2; 1; 6; 5");

            Lab4.Storage.OutputStorage(test);
            Assert.AreEqual(test.Length, Lab4.Storage.CheckSizeArray());
        }

        [TestMethod]
        public void InputStorage_OutputStorage()
        {
            Lab4.Storage.FILE_NAME = "Storage_test.txt";

            Lab4.Storage[] test = new Lab4.Storage[3];
            test[0] = new Lab4.Storage("1; Test 2; 1; 6; 5");
            test[1] = new Lab4.Storage("2; Test 2; 1; 6; 5");
            test[2] = new Lab4.Storage("3; Test 2; 1; 6; 5");

            Lab4.Storage.OutputStorage(test);

            Lab4.Storage[] test2 = Lab4.Storage.InputStorage();
            Assert.AreEqual("1", test2[0].InventoryNumber);
            Assert.AreEqual("2", test2[1].InventoryNumber);
            Assert.AreEqual("3", test2[2].InventoryNumber);

            Lab4.Storage newTest = new Lab4.Storage("4; Test 2; 1; 6; 5");
            Lab4.Storage.OutputStorage(newTest);

            Lab4.Storage[] test3 = Lab4.Storage.InputStorage();
            Assert.AreEqual("4", test3[3].InventoryNumber);
        }

        [TestMethod]
        public void AddTovar()
        {
            Lab4.Storage.FILE_NAME = "Storage_test.txt";
            using (StreamWriter f = new StreamWriter("Storage_test.txt"))
            {
                Lab4.Storage tovar = new Lab4.Storage("0; 1; 2; 3; 4");

                f.Write(tovar.InventoryNumber + "; ");
                f.Write(tovar.ProductName + "; ");
                f.Write(tovar.Weight + "; ");
                f.Write(tovar.Price + "; ");
                f.WriteLine(tovar.Number);
                
                f.Close(); // закриття файла
            }
                Lab4.Storage.AddTovar();
            Lab4.Storage[] test = Lab4.Storage.InputStorage();
            Assert.AreEqual("null", test[1].InventoryNumber);
            Assert.AreEqual("null", test[1].ProductName);
            Assert.AreEqual("null", test[1].Weight);
            Assert.AreEqual("null", test[1].Price);
            Assert.AreEqual("null", test[1].Number);
        }

        [TestMethod]
        public void TestInvNum()
        {
            Lab4.Storage.FILE_NAME = "Storage_test.txt";

            Lab4.Storage[] test = new Lab4.Storage[3];
            test[0] = new Lab4.Storage("1; Test 1; 1; 6; 5");
            test[1] = new Lab4.Storage("2; null; 1; 6; 5");
            test[2] = new Lab4.Storage("1; Test 3; 1; 6; 5");
            Lab4.Storage.OutputStorage(test);

            int res = Lab4.Storage.TestInvNum();
            Assert.AreEqual(1, res);
        }

        [TestMethod]
        public void ProductSearch()
        {
            Lab4.Storage.FILE_NAME = "Storage_test.txt";

            Lab4.Storage[] test = new Lab4.Storage[3];
            test[0] = new Lab4.Storage("1; Test 1; 1; 6; 5");
            test[1] = new Lab4.Storage("2; null; 1; 6; 5");
            test[2] = new Lab4.Storage("3; Test 3; 1; 6; 5");
            Lab4.Storage.OutputStorage(test);

            int res = Lab4.Storage.ProductSearch();
            Assert.AreEqual(1, res);
        }
    }
}
