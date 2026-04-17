namespace Plenty_of_Finch.Models.Search
{
    public class SearchResult
    {

        private int birdID;
        private string firstName;
        private string lastName;
        private int age;
        private string city;
        private string state;
        private string species;
        private string profileImage;

        public SearchResult()
        {
            birdID = 0;
            firstName = "";
            lastName = "";
            age = 0;
            city = "";
            state = "";
            species = "";
            profileImage = "";
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

        public string Species
        {
            get { return species; }
            set
            {
                species = value;
            }
        }

        public string ProfileImage
        {
            get { return profileImage; }
            set { profileImage = value; }
        }
    }
}
