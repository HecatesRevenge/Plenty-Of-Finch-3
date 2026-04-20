using System;

namespace Plenty_of_Finch.Validators
{
    public class Validations
    {

        public string LoginValidation(string username, string password)
        {
            if (string.IsNullOrEmpty(username))
                return "Username required";

            if (string.IsNullOrEmpty(password))
                return "Password required";

            return "";
        }
        public string SecurityQuestionValidation(string question1, string answer1,
            string question2, string answer2, string question3, string answer3)
        {
            if (string.IsNullOrWhiteSpace(question1) || string.IsNullOrWhiteSpace(answer1) ||
                string.IsNullOrWhiteSpace(question2) || string.IsNullOrWhiteSpace(answer2) ||
                string.IsNullOrWhiteSpace(question3) || string.IsNullOrWhiteSpace(answer3))
                return "All three security questions and answers are required.";

            if (question1 == question2 || question1 == question3 || question2 == question3)
                return "Please select three different security questions.";

            return "";
        }
        public string RegistrationValidation(string firstName, string lastName, string age, string gender,
           string email, string city, string state, string username, string password)
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

            return "";
        }

        

        
    }
}
