using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SecurityLayer
{
    public class DataValidation
    {
        public static decimal isDecimalValid(string value)
        {
            decimal return_value = 0;
            bool successfullyParsed = decimal.TryParse(value, out return_value);
            if (successfullyParsed)
            {
                return_value = decimal.Parse(return_value.ToString("N2"));
            }
            return return_value;
        }
        public static string isDateValid(string value)
        {
            DateTime date;
            bool successfullyParsed = DateTime.TryParse(value, out date);
            
            if (!successfullyParsed)
            {
                date = DateTime.Parse("01/01/2000");
            }

            return date.ToString("dd/MM/yyyy");
        }
        public static int isIntValid(string value)
        {
            int return_value = 0;
            bool successfullyParsed = Int32.TryParse(value, out return_value);                       
            return return_value;
        }
        public static string ChangeToWords(decimal value)
        {
            string decimals = "";
            string input = Math.Round(value, 2).ToString();
            if (input.Contains("."))
            {
                decimals = input.Substring(input.IndexOf(".") + 1);                
                input = input.Remove(input.IndexOf("."));
            }
                        
            string strWords = GetWords(input);          

            int len = decimals.Length;
            if (len > 0)
                len = int.Parse(decimals);
            if (len > 0)
            {                
                strWords += " and " + GetWords(decimals) + " Fils";
            }

            strWords = strWords + " Only.";
            return strWords;
        }
        public static string GetWords(string input)
        {
            
            string[] seperators = { "", " Thousand ", " Million ", " Billion " };

            int i = 0;

            string strWords = "";

            while (input.Length > 0)
            {
               
                string _3digits = input.Length < 3 ? input : input.Substring(input.Length - 3);
                
                input = input.Length < 3 ? "" : input.Remove(input.Length - 3);

                int no = int.Parse(_3digits);
               
                _3digits = GetWord(no);

                
                if (_3digits != "")
                {
                    _3digits += seperators[i];
                }
                
                strWords = _3digits + strWords;
                
                i++;
            }
            return Regex.Replace(strWords, @"\s+", " ");
        }
        public static string GetWord(int no)
        {
            string[] Ones =
                {
                "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven",
            "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen"
        };

            string[] Tens = { "Ten", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };

            string word = "";

            if (no > 99 && no < 1000)
            {
                int i = no / 100;
                word = word + Ones[i - 1] + " Hundred ";
                no = no % 100;
            }

            if (no > 19 && no < 100)
            {
                int i = no / 10;
                word = word + Tens[i - 1] + " ";
                no = no % 10;
            }

            if (no > 0 && no < 20)
            {
                word = word + Ones[no - 1];
            }

            return word;
        }
        public static DateTime isDateTimeValid(string value)
        {
            DateTime date;
            bool successfullyParsed = DateTime.TryParse(value, out date);

            if (!successfullyParsed)
            {
                date = DateTime.Parse("01/01/2000");
            }

            return date;
        }
    }
}
