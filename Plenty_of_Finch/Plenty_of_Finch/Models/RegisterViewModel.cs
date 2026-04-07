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
        private string zip;
        private string username;
        private string password;
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
            zip = "";
            username = "";
            password = "";
            errorMessage = "";

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

        public string ZipCode
        {
            get { return zip; }
            set { zip = value; }

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

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { errorMessage = value; }
        }

    }
}
