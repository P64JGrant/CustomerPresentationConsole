using System;
using System.Collections.Generic;
using System.Text;
using CustomerOutput;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestCustomerOutput
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestGetOutputMethod()
        {
            CustomerOutput.CustomerOutput co = new CustomerOutput.CustomerOutput();
            IEnumerable<string> results = co.GetOutput(30);
            bool test = false;

            foreach (string result in results)
                if (result.Contains("15 Fizz Buzz"))
                    test = true;

            // test for expected data
            Assert.IsTrue(test, "Passed Test");
        }

        [TestMethod]
        public void TestGetOutputWithCustomerInputMethod()
        {
            List<CustomerInput> ci = new List<CustomerInput>()
            {
                new CustomerInput{ Number = 3, Word = "Fuzz" },
                new CustomerInput{ Number = 5, Word = "Bizz" }
            };

            CustomerOutput.CustomerOutput co = new CustomerOutput.CustomerOutput();
            IEnumerable<string> results = co.GetOutput(30, ci);
            bool test = false;

            foreach (string result in results)
                if (result.Contains("15 Fuzz Bizz"))
                    test = true;

            // test for expected data
            Assert.IsTrue(test, "Passed Test");
        }
    }
}
