using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestLab4_2
{
    [TestClass]
    public class GetSet
    {
        [TestMethod]
        public void SetGetDate()
        {
            string TEST_STR = "01.02.2021";

            Lab4.MeteorologicalObservations date = new Lab4.MeteorologicalObservations()
            {
                Date = TEST_STR
            };
            bool res1 = date.Date.Equals(TEST_STR);
            Assert.IsTrue(res1);
        }
        [TestMethod]
        public void SetGetTemperature()
        {
            string TEST = "01.02.2021; 90; 123";
            double test = 90;

            Lab4.MeteorologicalObservations temperature = new Lab4.MeteorologicalObservations(TEST);

            bool res1 = temperature.Temperature.Equals(test);
            Assert.IsTrue(res1);
        }
        [TestMethod]
        public void SetGetAtmosphericPressure()
        {
            string TEST = "01.02.2021; 90; 123";
            double test = 123;

            Lab4.MeteorologicalObservations atmosphericPressure = new Lab4.MeteorologicalObservations(TEST);

            bool res1 = atmosphericPressure.AtmosphericPressure.Equals(test);
            Assert.IsTrue(res1);
        }
    }

    [TestClass]
    public class SetFail
    {
        [TestMethod]
        public void SetDateFail()
        {
            string TEST_STR = "asdasdasd";
            bool ok = false;
            try
            {
                Lab4.MeteorologicalObservations date = new Lab4.MeteorologicalObservations()
                {
                    Date = TEST_STR
                };
            }
            catch (System.Exception)
            {
                ok = true;
            }
            Assert.IsTrue(ok);
        }
        [TestMethod]
        public void SetDateTemperatureFail()
        {
            string TEST = "01.02.2021; 90sdf; 123";
            bool ok = false;
            try
            {
                Lab4.MeteorologicalObservations temperature = new Lab4.MeteorologicalObservations(TEST);
            }
            catch (System.Exception)
            {
                ok = true;
            }
            Assert.IsTrue(ok);
        }
        [TestMethod]
        public void SetDateAtmosphericPressureFail()
        {
            string TEST = "01.02.2021; 90; 123asd";
            bool ok = false;
            try
            {
                Lab4.MeteorologicalObservations atmosphericPressure = new Lab4.MeteorologicalObservations(TEST);
            }
            catch (System.Exception)
            {
                ok = true;
            }
            Assert.IsTrue(ok);
        }
    }


    [TestClass]
    public class Method
    {
        [TestMethod]
        public void CompareDate()
        {
            Lab4.MeteorologicalObservations test1 = new Lab4.MeteorologicalObservations("01.02.2021; 90; 123");
            Lab4.MeteorologicalObservations test2 = new Lab4.MeteorologicalObservations("01.02.2021; 190; 1234");

            int res = Lab4.MeteorologicalObservations.CompareDate(test1, test2);
            Assert.AreEqual(0, res);
        }

        [TestMethod]
        public void CompareAtmosphericPressure()
        {
            Lab4.MeteorologicalObservations test1 = new Lab4.MeteorologicalObservations("01.02.2021; 90; 123");
            Lab4.MeteorologicalObservations test2 = new Lab4.MeteorologicalObservations("02.03.2021; 190; 123");

            int res = Lab4.MeteorologicalObservations.CompareAtmosphericPressure(test1, test2);
            Assert.AreEqual(0, res);
        }

        [TestMethod]
        public void TheLargestPressureDrop()
        {
            Lab4.MeteorologicalObservations[] test = new Lab4.MeteorologicalObservations[4];
            test[0] = new Lab4.MeteorologicalObservations("04.02.2021; 90; 5");
            test[1] = new Lab4.MeteorologicalObservations("02.02.2021; 90; 2");
            test[2] = new Lab4.MeteorologicalObservations("01.02.2021; 90; 1");
            test[3] = new Lab4.MeteorologicalObservations("03.02.2021; 90; 4");

            Lab4.MeteorologicalObservations[] res = Lab4.MeteorologicalObservations.TheLargestPressureDrop(test);

            Assert.IsTrue(res[0].AtmosphericPressure.Equals(test[1].AtmosphericPressure));
            Assert.IsTrue(res[1].AtmosphericPressure.Equals(test[3].AtmosphericPressure));
        }
    }
}