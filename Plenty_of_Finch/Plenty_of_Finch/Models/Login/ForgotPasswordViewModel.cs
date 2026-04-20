namespace Plenty_of_Finch.Models.Login
{
    public class ForgotPasswordViewModel
    {

        private string username;
        private string securityQuestion;
        private string securityAnswer;
        private string newPassword;
        private string confirmPassword;
        private int step;
        private string errorMessage;
        private string successMessage;


        public ForgotPasswordViewModel()
        {
            username = "";
            securityQuestion = "";
            securityAnswer = "";
            newPassword = "";
            confirmPassword = "";
            step = 1;
            errorMessage = "";
            successMessage = "";
        }

        public string Username
        {
            get { return username; }
            set { username = value; }
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

        public string NewPassword
        {
            get { return newPassword; }
            set { newPassword = value; }
        }

        public string ConfirmPassword
        {
            get { return confirmPassword; }
            set { confirmPassword = value; }
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



