using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOutput
{
    public class CustomerOutput
    {
        public IEnumerable<string> GetOutput(int upperBound)
        {
            StringBuilder output = new StringBuilder();

            for (int i = 1; i < upperBound + 1; i++)
            {
                output.Append(i.ToString());

                if (i % 3 == 0)
                    output.Append(" Fizz");

                if (i % 5 == 0)
                    output.Append(" Buzz");

                yield return output.ToString();
                output.Clear();
            }
        }

        public IEnumerable<string> GetOutput(int upperBound, List<CustomerInput> customerInputs)
        {
            StringBuilder output = new StringBuilder();

            for (int i = 1; i < upperBound + 1; i++)
            {
                output.Append(i.ToString());

                foreach (CustomerInput customerInput in customerInputs)
                {
                    if (i % customerInput.Number == 0)
                        output.Append(" " + customerInput.Word);
                }

                yield return output.ToString();
                output.Clear();
            }
        }
    }
}
