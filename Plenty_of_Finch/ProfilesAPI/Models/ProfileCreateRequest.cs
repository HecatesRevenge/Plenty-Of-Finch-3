namespace ProfilesAPI.Models
{
    public class ProfileCreateRequest
    {
        private int birdID;
        private string biography;
        private string profileImage;
        private string species;
        private string wingspan;
        private string commitmentType;
        private string goals;
        private string plumage;
        private string ageRange;
        private string occupation;
        private string favoriteSeed;
        private bool isVisible;

        public ProfileCreateRequest()
        {
            birdID = 0;
            biography = "";
            profileImage = "";
            species = "";
            wingspan = "";
            commitmentType = "";
            goals = "";
            plumage = "";
            ageRange = "";
            occupation = "";
            favoriteSeed = "";
            isVisible = false;
        }

        public int BirdID
        {
            get { return birdID; }
            set { birdID = value; }
        }

        public string Biography
        {
            get { return biography; }
            set { biography = value; }
        }

        public string ProfileImage
        {
            get { return profileImage; }
            set { profileImage = value; }
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

        public string CommitmentType
        {
            get { return commitmentType; }
            set { commitmentType = value; }
        }

        public string Goals
        {
            get { return goals; }
            set { goals = value; }
        }
        public string Plumage
        {
            get { return plumage; }
            set { plumage = value; }
        }

        public string AgeRange
        {
            get { return ageRange; }
            set { ageRange = value; }
        }

        public string Occupation
        {
            get { return occupation; }
            set { occupation = value; }
        }

        public string FavoriteSeed
        {
            get { return favoriteSeed; }
            set { favoriteSeed = value; }
        }

        public bool IsVisible
        {
            get { return isVisible; }
            set { isVisible = value; }
        }
    }
}

