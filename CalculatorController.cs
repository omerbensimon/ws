using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace OnlineCalculator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        // GET api/calculator/GetFiveRandomNumbers
        [HttpGet("GetFiveRandomNumbers")]
        public List<int> GetFiveRandomNumbers()
        {
            var numbers = new List<int>();
            var rnd = new Random();
            int count = 0;

            while (count < 5)
            {
                int newNum = rnd.Next(1, 21); // generate a random number between 1- 20

                if (!numbers.Contains(newNum))
                {
                    numbers.Add(newNum);
                    count++;
                }
            }

            return numbers;
        }
        [HttpGet("CamelCaseFunction")]
        public string CamelCaseFunction(string str)
        {
            if (String.IsNullOrEmpty(str))
                return "is null or empty";
            str = str.ToLower();
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
            str = textInfo.ToTitleCase(str);
            str = str.Replace(" ", string.Empty);
            return str;
        }
        [HttpGet("FourDigitToList")]
        public List<int> FourDigitToList(int number)
        {
            var numbersList = new List<int>();
            string str = number.ToString();
            int i = 0;
            if(str.Length == 4)
            {
                while (i < 4)
                {
                    numbersList.Add(int.Parse(str[i].ToString()));
                    i++;
                }
                return numbersList;
            }
            return null;
        }
        [HttpGet("MaxNumber")]
        public int MaxNumber(int first, int seconed, int third)
        {
            int max = Math.Max(first, Math.Max(seconed, third));
            return max;
        }
        [HttpGet("WordInText")]
        public string WordInText(string text, int position)
        {
            if (String.IsNullOrEmpty(text))
                return "is null or empty";

            text = text.Split(' ')[position];
            return text;
        }
        [HttpGet("StarFunction")]
        public string StarFunction(int number)
        {
            string star = "";
            star = star.PadRight(number, '*');    
            return star;
        }
    }
}
