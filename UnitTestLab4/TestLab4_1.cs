using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestLab4_1
{
    [TestClass]
    public class GetSet
    {
        [TestMethod]
        public void SetGetName()
        {
            string TEST_STR = "TestName";

            Lab4.Student student = new Lab4.Student
            {
                Name = TEST_STR
            };
            bool res = student.Name.Equals(TEST_STR);
            Assert.IsTrue(res);
        }
        [TestMethod]
        public void SetGetLastName()
        {
            string TEST_STR = "TestLastName";

            Lab4.Student student = new Lab4.Student
            {
                LastName = TEST_STR
            };
            bool res1 = student.LastName.Equals(TEST_STR);
            Assert.IsTrue(res1);
        }
        [TestMethod]
        public void SetGetGroup()
        {
            string TEST_STR = "K-21";
            /////////////// Set
            Lab4.Student student = new Lab4.Student
            {
                Group = TEST_STR
            };

            bool res1 = student.Group.Equals(TEST_STR);
            Assert.IsTrue(res1);
        }

        [TestMethod]
        public void SetGetYear()
        {
            int TEST_STR = 2020;
            /////////////// Set
            Lab4.Student student = new Lab4.Student
            {
                Year = TEST_STR
            };

            bool res1 = student.Year.Equals(TEST_STR);
            Assert.IsTrue(res1);
        }
        [TestMethod]
        public void SetGetAdress()
        {
            string TEST_STR = "TestAdress, asd asd asd2 23";

            Lab4.Student student = new Lab4.Student
            {
                Adress = TEST_STR
            };

            bool res1 = student.Adress.Equals(TEST_STR);
            Assert.IsTrue(res1);
        }

        [TestMethod]
        public void SetGetPassport()
        {
            string TEST_STR = "111222333";
            /////////////// Set
            Lab4.Student student = new Lab4.Student
            {
                Passport = TEST_STR
            };

            bool res1 = student.Passport.Equals(TEST_STR);
            Assert.IsTrue(res1);
        }
        [TestMethod]
        public void SetGetAge()
        {
            int TEST_STR = 18;
            /////////////// Set
            Lab4.Student student = new Lab4.Student
            {
                Age = TEST_STR
            };

            bool res1 = student.Age.Equals(TEST_STR);
            Assert.IsTrue(res1);
        }
        [TestMethod]
        public void SetGetTelephon()
        {
            string TEST_STR = "380999999999";
            /////////////// Set
            Lab4.Student student = new Lab4.Student
            {
                Telephon = TEST_STR
            };

            bool res1 = student.Telephon.Equals(TEST_STR);
            Assert.IsTrue(res1);
        }
        [TestMethod]
        public void SetGetRating()
        {
            double TEST_STR = 12.3;
            /////////////// Set
            Lab4.Student student = new Lab4.Student
            {
                Rating = TEST_STR
            };

            bool res1 = student.Rating.Equals(TEST_STR);
            Assert.IsTrue(res1);
        }
    }

    [TestClass]
    public class SetFail
    {
        [TestMethod]
        public void SetNameFail()
        {
            string TEST_STR = "TestN@me";

            Lab4.Student student = new Lab4.Student();
            bool res = false;
            try
            {
                student.Name = TEST_STR;
            }
            catch (System.Exception)
            {
                res = true;
            }
            Assert.IsTrue(res);
        }
        [TestMethod]
        public void SetLastNameFail()
        {
            string TEST_STR = "TestLastN@me";

            Lab4.Student student = new Lab4.Student();
            bool res = false;
            try
            {
                student.LastName = TEST_STR;
            }
            catch (System.Exception)
            {
                res = true;
            }
            Assert.IsTrue(res);
        }
        [TestMethod]
        public void SetGroupFail()
        {
            bool res = false;
            try
            {
                Lab4.Student student = new Lab4.Student
                {
                    Group = "k@21"
                };
            }
            catch (System.Exception)
            {
                res = true;
            }
            Assert.IsTrue(res);
        }

        [TestMethod]
        public void SetYearFail()
        {
            Lab4.Student student = new Lab4.Student();
            bool res1 = false;
            bool res2 = false;
            try
            {
                student.Year = 1950;
            }
            catch (System.Exception)
            {
                res1 = true;
            }

            try
            {
                student.Year = 2050;
            }
            catch (System.Exception)
            {
                res2 = true;
            }
            Assert.IsTrue(res1);
            Assert.IsTrue(res2);
        }

        [TestMethod]
        public void SetPassportFail()
        {
            bool res1 = false;

            try
            {
                Lab4.Student student = new Lab4.Student
                {
                    Passport = "123"
                };
            }
            catch (System.Exception)
            {
                res1 = true;
            }
            Assert.IsTrue(res1);
        }

        [TestMethod]
        public void SetAgeFail()
        {
            Lab4.Student student = new Lab4.Student();
            bool res1 = false;
            bool res2 = false;
            bool res3 = false;

            try
            {
                student.Age = 123;
            }
            catch (System.Exception)
            {
                res1 = true;
            }

            try
            {
                student.Age = -15;
            }
            catch (System.Exception)
            {
                res2 = true;
            }

            try
            {
                student.Age = int.Parse("23@");
            }
            catch (System.Exception)
            {
                res3 = true;
            }
            Assert.IsTrue(res1);
            Assert.IsTrue(res2);
            Assert.IsTrue(res3);
        }

        [TestMethod]
        public void SetTelephonFail()
        {
            Lab4.Student student = new Lab4.Student();
            bool res1 = false;
            bool res2 = false;

            try
            {
                student.Telephon = "12345";
            }
            catch (System.Exception)
            {
                res1 = true;
            }

            try
            {
                student.Telephon = "38099999999*";
            }
            catch (System.Exception)
            {
                res2 = true;
            }

            Assert.IsTrue(res1);
            Assert.IsTrue(res2);
        }

        [TestMethod]
        public void SetRatingFail()
        {
            Lab4.Student student = new Lab4.Student();
            bool res1 = false;
            bool res2 = false;

            try
            {
                student.Rating = -2;
            }
            catch (System.Exception)
            {
                res1 = true;
            }
            try
            {
                student.Rating = 102;
            }
            catch (System.Exception)
            {
                res2 = true;
            }

            Assert.IsTrue(res1);
            Assert.IsTrue(res2);
        }
    }

    [TestClass]
    public class Method
    {
        [TestMethod]
        public void Compare()
        {
            Lab4.Student student = new Lab4.Student();
            int res1 = student.Compare("Anonimous");

            student = new Lab4.Student("Хвалимир; Куртяк; К-21; 2019; Geroev Stalingrada Ul., bld. 23, appt. 104; 000000127; 22; 380961111115; 55");
            int res2 = student.Compare("Куртяк");

            Assert.AreEqual(0, res1);
            Assert.AreEqual(0, res2);
        }
    }
}
