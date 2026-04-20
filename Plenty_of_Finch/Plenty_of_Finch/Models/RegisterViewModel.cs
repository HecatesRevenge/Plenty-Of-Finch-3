namespace Plenty_of_Finch.Models
{
    public class RegisterViewModel
    {
        private string firstName;
        private string lastName;
        private string age;
        private string gender;
        private string email;
        private string phone;
        private string address;
        private string city;
        private string state;


        private string username;
        private string password;

        private string securityQuestion1;
        private string securityAnswer1;
        private string securityQuestion2;
        private string securityAnswer2;
        private string securityQuestion3;
        private string securityAnswer3;
        private List<string> securityQuestionOptions;

        private string errorMessage;



        public RegisterViewModel()
        {
            firstName = "";
            lastName = "";
            age = "";
            gender = "";
            phone = "";
            email = "";
            address = "";
            city = "";
            state = "";
            username = "";
            password = "";
            errorMessage = "";
            securityQuestion1 = "";
            securityAnswer1 = "";
            securityQuestion2 = "";
            securityAnswer2 = "";
            securityQuestion3 = "";
            securityAnswer3 = "";
            securityQuestionOptions = new List<string>();

        }

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public string Age
        {
            get { return age; }
            set { age = value; }
        }

        public string Gender
        {
            get { return gender; }
            set { gender = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }
        public string Address
        {
            get { return address; }
            set { address = value; }

        }

        public string City
        {
            get { return city; }
            set { city = value; }
        }

        public string State
        {
            get { return state; }
            set { state = value; }
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

        public string SecurityQuestion1
        {
            get { return securityQuestion1; }
            set { securityQuestion1 = value; }
        }

        public string SecurityAnswer1
        {
            get { return securityAnswer1; }
            set { securityAnswer1 = value; }
        }

        public string SecurityQuestion2
        {
            get { return securityQuestion2; }
            set { securityQuestion2 = value; }
        }
        public string SecurityAnswer2
        {
            get { return securityAnswer2; }
            set { securityAnswer2 = value; }
        }
        public string SecurityQuestion3
        {
            get { return securityQuestion3; }
            set { securityQuestion3 = value; }
        }
        public string SecurityAnswer3
        {
            get { return securityAnswer3; }
            set { securityAnswer3 = value; }
        }

        public List<string> SecurityQuestionOptions
        {
            get { return securityQuestionOptions; }
            set { securityQuestionOptions = value; }

        }

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { errorMessage = value; }
        }

    }
}
