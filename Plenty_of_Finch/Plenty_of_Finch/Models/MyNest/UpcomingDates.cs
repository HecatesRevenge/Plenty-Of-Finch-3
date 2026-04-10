using Microsoft.IdentityModel.Tokens;

namespace Plenty_of_Finch.Models.MyNest
{
    public class UpcomingDates
    {
        private int birdID;
        private string firstName;
        private string lastName;
        private int age;
        private string gender;
        private string species;
        private string city;
        private string state;
        private string profileImage;
        private string occupation;
        private string biography;
        private string email;
        private string phone;
        private string homeAddress;



        public UpcomingDates()
        {
            birdID = 0;
            firstName = "";
            lastName = "";
            age = 0;
            gender = "";
            species = "";
            city = "";
            state = "";
            profileImage = "";
            biography = "";
            occupation = "";
            email = "";
            phone = "";
            homeAddress = "";


        }

        public int BirdID
        {
            get { return birdID; }
            set { birdID = value; }
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

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public string Gender
        {
            get { return gender; }
            set { gender = value; }
        }

        public string Species
        {
            get { return species; }
            set { species = value; }
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

        public string ProfileImage
        {
            get { return profileImage; }
            set { profileImage = value; }
        }

        public string Occupation
        {
            get { return occupation; }
            set { occupation = value; }
        }

        public string Biography
        {
            get { return biography; }
            set { biography = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string PhoneNumber
        {
            get { return phone; }
            set { phone = value; }
        }
        public string HomeAddress
        {
            get { return homeAddress; }
            set { homeAddress = value; }
        }
    }
}


