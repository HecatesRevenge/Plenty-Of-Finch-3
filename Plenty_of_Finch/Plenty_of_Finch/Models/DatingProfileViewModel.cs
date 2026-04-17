using Plenty_of_Finch.Models.DatingProfile;
using System.Reflection;

namespace Plenty_of_Finch.Models
{
    public class DatingProfileViewModel
    {

        private int birdID;
        private string fullName;
        private int age;
        private string gender;
        private string location;
        private string profileImage;

        private int totalLikes;
        private int totalViews;

        private string biography;

        private bool showContactInfo;
        private string email;
        private string phoneNumber;
        private string homeAddress;

        private List<Preference> likes;
        private List<Preference> dislikes;

        private string goals;
        private string commitmentType;
        private string ageRange;

        private string species;
        private string wingspan;
        private string favoriteSeed;
        private string plumage;
        private string occupation;


        //Buttons States
        private bool isOwnProfile;
        private bool alreadyInNest;
        private bool requestAlreadySent;

        //Page States
        private string message;
        private bool messageIsSuccess;

        public DatingProfileViewModel()
        {
            birdID = 0;
            fullName = "";
            age = 0;
            gender = "";
            location = "";
            profileImage = "";

            totalLikes = 0;
            totalViews = 0;

            biography = "";

            showContactInfo = false;
            email = "";
            phoneNumber = "";
            homeAddress = "";

            likes = new List<Preference>();
            dislikes = new List<Preference>();

            goals = "";
            commitmentType = "";
            ageRange = "";

            species = "";
            wingspan = "";
            favoriteSeed = "";
            plumage = "";
            occupation = "";

            isOwnProfile = false;
            alreadyInNest = false;
            requestAlreadySent = false;

            message = "";
            messageIsSuccess = true;
        }



        //Bird Identity 
        public int BirdID
        {
            get { return birdID; }
            set { birdID = value; }
        }

        public string FullName
        {
            get { return fullName; }
            set { fullName = value; }
        }

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public string Location
        {
            get { return location; }
            set { location = value; }
        }

        public string Gender
        {
            get { return gender; }
            set { gender = value; }
        }

        public string ProfileImage
        {
            get { return profileImage; }
            set { profileImage = value; }
        }





        public int TotalLikes
        {
            get { return totalLikes; }
            set { totalLikes = value; }
        }
        public int TotalViews
        {
            get { return totalViews; }
            set { totalViews = value; }
        }



        public string Biography
        {
            get { return biography; }
            set { biography = value; }
        }



        //Contact Info
        public bool ShowContactInfo
        {
            get { return showContactInfo; }
            set { showContactInfo = value; }
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


        public List<Preference> Likes
        {
            get { return likes; }
            set { likes = value; }
        }

        public List<Preference> Dislikes
        {
            get { return dislikes; }
            set { dislikes = value; }
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



        //Traits
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


        //Button States
        public bool IsOwnProfile
        {
            get { return isOwnProfile; }
            set { isOwnProfile = value; }
        }

        public bool AlreadyInNest
        {
            get { return alreadyInNest; }
            set { alreadyInNest = value; }
        }

        public bool RequestAlreadySent
        {
            get { return requestAlreadySent; }
            set { requestAlreadySent = value; }
        }


        public string Message
        {
            get { return message; }
            set { message = value; }
        }

        public bool MessageIsSuccess
        {
            get { return messageIsSuccess; }
            set { messageIsSuccess = value; }
        }

    }

}