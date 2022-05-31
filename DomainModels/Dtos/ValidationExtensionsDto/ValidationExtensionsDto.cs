using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DomainModels.Dtos.ValidationExtensionsDto
{
    public static class ValidationExtensionsDto
    {
        public static bool IsValidDocument(this string cpf)
        {
            var expression = "[0-9]{3}\\.?[0-9]{3}\\.?[0-9]{3}\\-?[0-9]{2}";
            return Regex.Match(cpf, expression).Success;
        }
        public static bool IsValidCellPhone(this string cellPhone)
        {
            var expression = "[0-9]{2}?[0-9]{4}?[0-9]{4}";
            return Regex.Match(cellPhone, expression).Success;
        }
        public static bool IsValidPostalCode(this string postalCode)
        {
            var expression = "[0-9]{5}\\-?[0-9]{3}";
            return Regex.Match(postalCode, expression).Success;
        }
    }
}