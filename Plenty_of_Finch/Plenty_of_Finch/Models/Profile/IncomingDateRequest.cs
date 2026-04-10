namespace Plenty_of_Finch.Models.Profile
{
    public class IncomingDateRequest
    {
        private int requestID;
        private string senderName;
        private string senderSpecies;
        private string requestStatus;
        private string profileImage;

        public IncomingDateRequest()
        {
            requestID = 0;
            senderName = "";
            senderSpecies = "";
            requestStatus = "";
            profileImage = "";
        }

        public int RequestID
        {
            get { return requestID; }
            set { requestID = value; }
        }

        public string SenderName
        {
            get { return senderName; }
            set { senderName = value; }
        }

        public string SenderSpecies
        {
            get { return senderSpecies; }
            set { senderSpecies = value; }
        }

        public string RequestStatus
        {
            get { return requestStatus; }
            set { requestStatus = value; }
        }

        public string ProfileImage
        {
            get { return profileImage; }
            set { profileImage = value; }
        }

    }
}
