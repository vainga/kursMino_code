using KursCode.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace KursCode.MVVM.Model.Managers
{
    public class viewFormatManager : iviewModelFormatManager
    {
        public string FormatNumeric(string input)
        {
            string digitsOnly = Regex.Replace(input, "[^0-9]", "");

            return digitsOnly;
        }

        public string FormatLetter(string input)
        {
            string lettersOnly = Regex.Replace(input, "[^a-zA-Zа-яА-Я]", "");

            return lettersOnly;
        }

        public string RemoveSpaces(string input)
        {
            string stringWithoutSpaces = Regex.Replace(input, "\\s", "");

            return stringWithoutSpaces;
        }

        public string FormatPhoneNumber(string input)
        {
            string digitsOnly = Regex.Replace(input, "[^0-9]", "");

            if (digitsOnly.Length > 0)
            {
                if (digitsOnly.Length <= 11)
                {
                    digitsOnly = "+7" + digitsOnly.Substring(1);
                    return Regex.Replace(digitsOnly, @"(\d{1})(\d{3})(\d{3})(\d{2})(\d{2})", "$1-$2-$3-$4-$5");
                }
                else
                {
                    digitsOnly = digitsOnly.Substring(0, 11);
                    return FormatPhoneNumber(digitsOnly);
                }
            }

            return string.Empty;
        }
    }
}
