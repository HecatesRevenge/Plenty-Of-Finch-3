namespace Plenty_of_Finch.Models.Login
{
    public class ForgotUsernameViewModel
    {
        private string email;
        private string securityQuestion;
        private string securityAnswer;
        private string retrievedUsername;
        private int step;
        private string errorMessage;
        private string successMessage;



        public ForgotUsernameViewModel()
        {
            email = "";
            securityQuestion = "";
            securityAnswer = "";
            retrievedUsername = "";
            step = 1;
            errorMessage = "";
            successMessage = "";
        }

        public string Email
        {
            get { return email; }
            set { email = value; }

        }

        public string SecurityQuestion
        {
            get { return securityQuestion; }
            set { securityQuestion = value; }
        }

        public string SecurityAnswer
        {
            get { return securityAnswer; }
            set { securityAnswer = value; }
        }

        public string RetrievedUsername
        {
            get { return retrievedUsername; }
            set { retrievedUsername = value; }
        }

        public int Step
        {
            get { return step; }
            set { step = value; }
        }

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { errorMessage = value; }
        }
        public string SuccessMessage
        {
            get { return successMessage; }
            set { successMessage = value; }
        }
    }
}
