using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WindowsFormsWorking;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Class1 class1 = new Class1();
            int expected = 30;
            int actual = class1.Add(10, 20);
            Assert.AreEqual(expected, actual);
        }
    }
}
