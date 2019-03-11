using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Common.Tests
{
    [TestClass()]
    public class ArrayEditTests
    {
        [TestMethod()]
        public void ArraySortTest()
        {
            string[] testSample = {"Tue", "Thu", "Mon", "Sun", "Fri", "Wed", "Sat"};
            string[] resultSample = { "Fri", "Mon", "Sat", "Sun", "Thu", "Tue", "Wed" };

            string[] testResult = ArrayEdit.ArraySortWithExceptDuplication(testSample);

            if(testResult.Length != testSample.Length)
            {
                Assert.Fail();
            }


            for (int i = 0; i < testResult.Length; i++)
            {
                if(testResult[i] != resultSample[i])
                {
                    Assert.Fail();
                }
            }

            Assert.AreEqual(true,true);
        }

        [TestMethod()]
        public void ExceptDuplicationTest()
        {
            string[] testSample = { "Wed", "Tue", "Thu", "Thu", "Thu", "Mon", "Sun", "Mon", "Fri", "Wed", "Sat" };
            string[] resultSample = { "Fri", "Mon", "Sat", "Sun", "Thu", "Tue", "Wed" };

            string[] testResult = ArrayEdit.ArraySortWithExceptDuplication(testSample);

            if (testResult.Length != 7)
            {
                Assert.Fail();
            }

            for (int i = 0; i < testResult.Length; i++)
            {
                if (testResult[i] != resultSample[i])
                {
                    Assert.Fail();
                }
            }

            Assert.AreEqual(true, true);
        }
    }
}