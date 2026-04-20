namespace Plenty_of_Finch.Models
{
    public class LoginViewModel
    {
        private string username;
        private string password;
        private bool rememberMe;
        private string errorMessage;

        public LoginViewModel()
        {
            username = "";
            password = "";
            rememberMe = false;
            errorMessage = "";
        }

        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public bool RememberMe
        {
            get { return rememberMe; }
            set { rememberMe = value; }
        }

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { errorMessage = value; }
        }
    }
}