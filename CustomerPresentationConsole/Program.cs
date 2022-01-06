using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerOutput;

namespace CustomerPresentationConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            // Un-comment the line below to see completion of the Yield
            //UpperLimit();

            // Un-comment the line below to see full version of code
            NumbersWithWords();

            System.Threading.Thread.Sleep(120000);
        }

        public static void UpperLimit()
        {
            int upperLimit = GetUpperLimit();

            CustomerOutput.CustomerOutput co = new CustomerOutput.CustomerOutput();
            foreach (string item in co.GetOutput(upperLimit))
                Console.WriteLine(item);
        }



        private static void NumbersWithWords()
        {
            int upperLimit = GetUpperLimit();
            List<CustomerInput> customerInputs = GetCustomerInputs();

            CustomerOutput.CustomerOutput co = new CustomerOutput.CustomerOutput();
            foreach (string item in co.GetOutput(upperLimit, customerInputs))
                Console.WriteLine(item);
        }

        #region Console input methods

        private static int GetUpperLimit()
        {
            int testInt = 0;

            Console.WriteLine("Enter The Upper Limit");
            string result = Console.ReadLine();

            while (!Int32.TryParse(result, out testInt))
            {
                Console.WriteLine("Not a valid number, try again.");
                result = Console.ReadLine();
            }

            return testInt;
        }

        private static List<CustomerInput> GetCustomerInputs()
        {
            List<CustomerInput> customerInputs = new List<CustomerInput>();

            Console.WriteLine("Add Numbers to find and Words to print below.");
            Console.WriteLine("Use the format Number, Word (ex:3,Bizz)");
            Console.WriteLine("Type Done when complete.");
            string result = "";

            // test string input
            string[] items = { "", ""};

            while (result.ToLower() != "done")
            {
                int testInt = 0;
                result = Console.ReadLine();
                if (result.ToLower() != "done")
                {
                    items = result.Split(',');
                    if (items.Length < 2 || !Int32.TryParse(items[0], out testInt))
                        Console.WriteLine("Incorrect format, pair has not been added");
                    else
                        customerInputs.Add(new CustomerInput { Number = testInt, Word = items[1].Trim()});
                }
            }

            return customerInputs;
        }

        #endregion
    }
}
