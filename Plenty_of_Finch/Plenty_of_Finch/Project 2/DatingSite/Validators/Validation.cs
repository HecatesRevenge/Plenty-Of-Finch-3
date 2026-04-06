using System;
using System.Collections.Generic;
using System.Web;

namespace DatingSite
{
    public class Validation
    {
        public string RegistrationValidation(string firstName, string lastName, string age, string gender,
            string email, string city, string state, string username, string password, string zipCode, string username1)
        {

            if (string.IsNullOrWhiteSpace(firstName))
                return "First name is required.";

            if (string.IsNullOrWhiteSpace(lastName))
                return "Last name is required.";

            if (string.IsNullOrWhiteSpace(age))
                return "Age is required.";

            int ageNum;
            if (!int.TryParse(age, out ageNum))
                return "Age must be a number.";

            if (ageNum < 18)
                return "You must be at least 18 years old.";

            if (string.IsNullOrWhiteSpace(gender))
                return "Please select a gender.";

            if (string.IsNullOrWhiteSpace(email))
                return "Email is required.";

            if (string.IsNullOrWhiteSpace(city))
                return "City is required.";

            if (string.IsNullOrWhiteSpace(state))
                return "State is required.";

            if (state.Length != 2)
                return "State must be a 2-letter abbreviation.";

            if (string.IsNullOrWhiteSpace(username))
                return "Username is required.";

            if (string.IsNullOrWhiteSpace(password))
                return "Password is required.";

            // All checks passed
            return "";
        }

        public string LoginValidation(string username, string password)
        {
            if (string.IsNullOrEmpty(username))
            {
                return "Username required";
            }

            if (string.IsNullOrEmpty(password))
            {
                return "Password required";
            }
            return "";
        }

        internal string RegistrationValidation(string firstName, string lastName, string age, string gender, string email, string phone, string address, string city, string state, string zipCode, string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}
