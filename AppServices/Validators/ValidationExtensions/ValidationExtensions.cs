using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace AppServices
{
    public static class ValidationExtensions
    {
        public static bool IsValidFullName(this string completFullName)
        {
            string[] strings = completFullName.Trim().ToLower().Split(' ');
            if (strings.Length > 1)
            {
                return true;
            }
            return false;



            //if (completFullName.All(x => x >= 'a' && x <= 'z' ))
            //{
            //     return true;
            //}
            //completFullName.All(x => x != '0' && x != '9'); //return false; parei aqui
            //return false;
        }

        public static bool ValidDigit(this char validDigit)
        {
            char.IsLetter(validDigit);
            return true;
        }

        public static int ToIntAt(this string value, Index index)
        {
            var indexValue = index.IsFromEnd
                ? value.Length - index.Value
                : index.Value;

            return (int)char.GetNumericValue(value, indexValue);
        }

        public static bool OnlyLetters(this string letters)
        {
            letters.ToLower().All(x => x >= 'a' && x <= 'z');
            string.IsNullOrWhiteSpace(letters);
            return letters.Length > 0;
        }

        public static bool OnlyNumbers(this string numbers)
        {
            return numbers.All(x => x >= '0' && x <= '9');
        }

        public static bool ApproveAge(this DateTime birthdate)
        {
            var idade = DateTime.UtcNow.Year - birthdate.Year;
            if (idade >= 18) return true;
            return false;
        }
    }
}