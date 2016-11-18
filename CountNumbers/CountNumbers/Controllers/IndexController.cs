using System.Web.Mvc;

namespace CountNumbers.Controllers
{
    public class IndexController : Controller
    {
        // GET: Index
        public ActionResult Index()
        {
            ViewBag.Message = "";
            return View();
        }

        [HttpPost]
        public ActionResult Submit(string numbers)
        {
            int[] result = validateInput(numbers);
            if (result == null)
            {
                ViewBag.Message = "Error";
            }
            else
            {
                ViewBag.Message = createOutput(result);
            }

            return View("Index");
        }


        /**This method validates the input from the user:
         * It validates the '[' and ']' symbols and then try to parse the data
         * In case the input is correct it returns an array with the corresponding data
         * If the input is invlaid it returns a null array.
         **/
        private int[] validateInput(string input)
        {
            int[] numbers = null;

            if (input != null && input != "" && input.StartsWith("[") && input.EndsWith("]"))
            {
                input = input.Replace('[', ' ');
                input = input.Replace(']', ' ');
                
                string[] inputs = input.Split(',');
                numbers = new int[inputs.Length];
                for (int i = 0; i < inputs.Length; i++)
                {
                    string currentInput = inputs[i].Trim();

                    int currentNum;
                    if (int.TryParse(currentInput, out currentNum))
                    {
                        numbers[i] = currentNum;
                    }
                    else
                    {
                        //The entry could not be mapped as a number, the the input is not valid
                        return null;
                    }

                }
            }
            return numbers;
        }

        /** This method is in charge of generating the output for a valid array of integers
         *  It orders the array in ascending order
         *  Then it loops through the numbers in the array counting the repeated ones
         *  It adds a number to the output when it appears three or more times in the sequence 
         **/
        private string createOutput(int[] numbers)
        {
            string output = "[";

            System.Array.Sort(numbers);
            int size = numbers.Length - 1;

            int actual = numbers[size];
            int count = 0;
            for (int i = size; i>= 0; i--)
            {
                if(actual == numbers[i])
                {
                    count++;
                }else
                {
                    if(count > 2)
                    {
                        output += actual + ",";
                    }
                    count = 1;
                    actual = numbers[i];
                }
            }

            if (count > 2)
            {
                output += actual;
            }else
            {
                if (output.EndsWith(","))
                {
                    output.Remove(output.Length - 1);
                }
            }

            return output + "]";
        }
    }
}