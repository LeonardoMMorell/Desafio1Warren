using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Application.Validators.ValidationExtensions
{
    public static class ValidationExtensions
    {
        public static bool IsValidFullname(this string completFullname)
        {
            string[] stringLimiting = completFullname.Split(' ');

            if (IsValidString(completFullname)) return false;

            return stringLimiting.Length > 1 && stringLimiting.Length < 7;
        }
            return false;

        public static bool IsValidString(this string letter)
        {
            //    if (letter.Trim() != letter
            //        || letter.Split(' ').Contains("")
            //        || letter.Split(' ').Any(_ => !char.IsUpper(_.First()))) return false;

            //    letter = letter.Replace(" ", string.Empty);
            //    if (ChecksIfTheFirstCharactersAreTheSame(letter)) return false;

            //    return letter.All(x => char.IsLetter(x));
            if (ChecksIfTheFirstCharactersAreTheSame(letter)
                || letter.Trim() != letter
                || letter.Split(' ').Contains("")
                || letter.Split(' ').Any(_ => !char.IsUpper(_.First()))) return false;

            return true;
        }

        public static bool ChecksIfTheFirstCharactersAreTheSame(this string characters)
        {
            return !characters.All(c => c.Equals(characters.First()));
        }

        public static int ToIntAt(this string value, Index index)
        {
            var indexValue = index.IsFromEnd
                ? value.Length - index.Value
                : index.Value;

            return (int)char.GetNumericValue(value, indexValue);
        }

        public static bool OnlyNumbers(this string numbers)
        {
            return numbers.All(x => x >= '0' && x <= '9');
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
            var idade = new DateTime(DateTime.Now.Subtract(birthdate).Ticks).Year - 1;
            return idade >= 18
                ? true
                : false;
        }
    }
}