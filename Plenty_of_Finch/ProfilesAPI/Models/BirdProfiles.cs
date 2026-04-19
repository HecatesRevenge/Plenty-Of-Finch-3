namespace ProfilesAPI.Models
{
    public class BirdProfiles
    {
        private int birdID;
        private string firstName;
        private string lastName;
        private int age;
        private string gender;
        private string city;
        private string state;
        private string profileImage;

        private string biography;

        private string goals;
        private string commitmentType;
        private string ageRange;

        private string species;
        private string wingspan;
        private string favoriteSeed;
        private string plumage;
        private string occupation;

        private int totalLikes;
        private bool isVisible;

        private string email;
        private string phoneNumber;
        private string homeAddress;
        private int zipCode;
        public BirdProfiles()
        {
            birdID = 0;
            firstName = "";
            lastName = "";
            age = 0;
            gender = "";
            city = "";
            state = "";
            profileImage = "";

            biography = "";

            goals = "";
            commitmentType = "";
            ageRange = "";

            species = "";
            wingspan = "";
            favoriteSeed = "";
            plumage = "";
            occupation = "";

            totalLikes = 0;
            isVisible = true;

            email = "";
            phoneNumber = "";
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


        public string Biography
        {
            get { return biography; }
            set { biography = value; }
        }

        public string Goals
        {
            get { return goals; }
            set { goals = value; }
        }

        public string CommitmentType
        {
            get { return commitmentType; }
            set { commitmentType = value; }
        }

        public string AgeRange
        {
            get { return ageRange; }
            set { ageRange = value; }
        }



        public string Species
        {
            get { return species; }
            set { species = value; }
        }

        public string Wingspan
        {
            get { return wingspan; }
            set { wingspan = value; }
        }

        public string FavoriteSeed
        {
            get { return favoriteSeed; }
            set { favoriteSeed = value; }
        }

        public string Plumage
        {
            get { return plumage; }
            set { plumage = value; }

        }

        public string Occupation
        {
            get { return occupation; }
            set { occupation = value; }
        }

        public int TotalLikes
        {
            get { return totalLikes; }
            set { totalLikes = value; }
        }

        public bool IsVisible
        {
            get { return isVisible; }
            set { isVisible = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }

        public string HomeAddress
        {
            get { return homeAddress; }
            set { homeAddress = value; }
        }


    }


}
