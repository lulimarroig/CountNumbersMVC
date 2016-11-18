using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
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
                ViewBag.Message = "The input is not in the correct format. The corresponding format is: [x,y,z]";
            }
            else
            {
                ViewBag.Message = createOutput(result);
            }

            return View("Index");
        }

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
                        return null;
                    }

                }
            }
            return numbers;
        }

        private string createOutput(int[] numbers)
        {
            string output = "SAlidaaaa";

            return output;
        }
    }
}