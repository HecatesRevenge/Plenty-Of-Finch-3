using Plenty_of_Finch.Models.Profile;

namespace Plenty_of_Finch.Models
{
    public class MyProfileViewModel
    {
        private string biography;
        private string profileImage;
        private string species;
        private string wingspan;
        private string plumage;
        private string occupation;
        private string favoriteSeed;
        private string commitmentType;
        private string goals;
        private string ageRange;
        private bool isVisible;

        private string likes;
        private string dislikes;

        private string pageTitle;
        private string message;
        private bool isExistingProfile;

        private List<Notification> notifications;

        private List<IncomingDateRequest> incomingRequests;
        private List<OutgoingDateRequest> outgoingRequests;

        private List<ProfileViewer> profileViewers;
        private int totalProfileViews;

        public MyProfileViewModel()
        {
            biography = "";
            profileImage = "";
            species = "";
            wingspan = "";
            plumage = "";
            occupation = "";
            favoriteSeed = "";
            commitmentType = "";
            goals = "";
            ageRange = "";
            isVisible = true;

            likes = "";
            dislikes = "";

            pageTitle = "My Profile";
            message = "";
            isExistingProfile = false;

            notifications = new List<Notification>();
            incomingRequests = new List<IncomingDateRequest>();
            outgoingRequests = new List<OutgoingDateRequest>();
            profileViewers = new List<ProfileViewer>();
            totalProfileViews = 0;
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

        public string FavoriteSeed
        {
            get { return favoriteSeed; }
            set { favoriteSeed = value; }
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

        public string AgeRange
        {
            get { return ageRange; }
            set { ageRange = value; }
        }

        public bool IsVisible
        {
            get { return isVisible; }
            set { isVisible = value; }
        }

        public string Likes
        {
            get { return likes; }
            set { likes = value; }
        }   

        public string Dislikes
        {
            get { return dislikes; }
            set { dislikes = value; }
        }

        public string PageTitle
        {
            get { return pageTitle; }
            set { pageTitle = value; }
        }

        public string Message
        {
            get { return message; }
            set { message = value; }
        }

        public bool IsExistingProfile
        {
            get { return isExistingProfile; }
            set { isExistingProfile = value; }
        }

        public List<Notification> Notifications
        {
            get { return notifications; }
            set { notifications = value; }
        }

        public List<IncomingDateRequest> IncomingRequests
        {
            get { return incomingRequests; }
            set { incomingRequests = value; }
        }

        public List<OutgoingDateRequest> OutgoingRequests
        {
            get { return outgoingRequests; }
            set { outgoingRequests = value; }
        }

        public List<ProfileViewer> ProfileViewers
        {
            get { return profileViewers; }
            set { profileViewers = value; }
        }

        public int TotalProfileViews
        {
            get { return totalProfileViews; }
            set { totalProfileViews = value; }
        }

    }
}
