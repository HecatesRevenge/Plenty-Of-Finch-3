namespace Plenty_of_Finch.Helpers
{
    public class SecurityQuestions
    {
        public static List<string> GetSecurityQuestion()
        {

            List<string> questions = new List<string>();
            questions.Add("What is your favorite seed?");
            questions.Add("What city were you hatched in?");
            questions.Add("What is your wing color?");
            questions.Add("What was the name of your first nest?");
            questions.Add("What is your mother's maiden name?");
            questions.Add("What was your first pet's name?");
            questions.Add("What street did you grow up on?");
            questions.Add("What is your favorite perching spot?");
            return questions;
        }
    }
}

