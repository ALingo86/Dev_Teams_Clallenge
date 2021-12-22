using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            void TimesTables()
            {
                int a = 1, b = 1;
                while (b <= 12)
                {
                    Console.WriteLine($"{a}X{b}=({a}*{b})");
                    b++;
                    while (a <= 5)
                    {
                        Console.WriteLine($"{a}X{b}=({a}*{b})");
                        b = 1;
                        a++;
                    }
                }

            }

        }

    }
}
