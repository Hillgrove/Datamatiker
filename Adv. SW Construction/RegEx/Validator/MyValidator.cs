using System.Text.RegularExpressions;

namespace Validator
{
    public class MyValidator
    {
        // Letters without any digits and at least 1 char long
        public bool ValidateFirstName(string firstName)
        {
            string pattern = @"^[A-Z][a-zA-Z]+$";
            Regex rg = new Regex(pattern);
            Match match = rg.Match(firstName);

            return match.Success ? true : false;
        }

        // Letters without any digits and at least 1 char long
        public bool ValidateSirName(string sirName)
        {
            string pattern = @"^[A-Z][a-zA-Z]+$";
            Regex rg = new Regex(pattern);
            Match match = rg.Match(sirName);

            return match.Success ? true : false;
        }

        // Letters without any digits and at least 1 char long
        public bool ValidateStreet(string street)
        {
            string pattern = @"^[A-Z][a-zA-Z]+$";
            Regex rg = new Regex(pattern);
            Match match = rg.Match(street);

            return match.Success ? true : false;
        }

        // Number could be the values 1-999 but no longer than three digits although it
        // could be followed by several letters incl. digits e.g. 167 B, 1 i.e. number 167 B 1st floor
        public bool ValidateStreeNumber(string streetNumber)
        {
            string pattern = @"^(?:[1-9][0-9]{0,2})(?:(?=\D).+)?$";
            Regex rg = new Regex(pattern);
            Match match = rg.Match(streetNumber);

            return match.Success ? true : false;
        }
        
        // always 4 digits
        public bool ValidatePostalZip(string postalZip)
        {
            string pattern = @"^\d{4}$";
            Regex rg = new Regex(pattern);
            Match match = rg.Match(postalZip);

            return match.Success ? true : false;
        }

        // Letters without any digits and at least 1 char long
        public bool ValidatePostalCity(string postalCity)
        {
            string pattern = @"^[A-Za-z]+$";
            Regex rg = new Regex(pattern);
            Match match = rg.Match(postalCity);

            return match.Success ? true : false;
        }
        
        // always 8 digits long, but could be prefixed with e.g. +45 and perhaps a space
        public bool ValidatePhoneNr(string phoneNr)
        {
            string pattern = @"^(\+\d{2} ?)?\d{8}$";
            Regex rg = new Regex(pattern);
            Match match = rg.Match(phoneNr);

            return match.Success ? true : false;
        }

        // E-mail is the normal letters, digits, hyphen, dot, underscore then ‘@’ and the domain
        public bool ValidateEmail(string email)
        {
            
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            Regex rg = new Regex(pattern);
            Match match = rg.Match(email);

            return match.Success ? true : false;
        }
    }
}
