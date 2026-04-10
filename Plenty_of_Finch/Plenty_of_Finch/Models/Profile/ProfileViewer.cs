namespace Plenty_of_Finch.Models.Profile
{
    public class ProfileViewer
    {
        private int viewerID;
        private string fullName;
        private string species;
        private string profileImage;
        private DateTime viewedAt;


        public ProfileViewer()
        {
            viewerID = 0;
            fullName = "";
            species = "";
            profileImage = "";
        }

        public int ViewerID
        {
            get { return viewerID; }
            set { viewerID = value; }
        }

        public string FullName
        {
            get { return fullName; }
            set { fullName = value; }
        }

        public string Species
        {
            get { return species; }
            set { species = value; }
        }

        public string ProfileImage
        {
            get { return profileImage; }
            set { profileImage = value; }
        }

        public DateTime ViewedAt
        {
            get { return viewedAt; }
            set { viewedAt = value; }
        }
    }
}