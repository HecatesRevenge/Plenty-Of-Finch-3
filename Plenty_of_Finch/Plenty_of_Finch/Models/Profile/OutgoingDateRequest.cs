namespace Plenty_of_Finch.Models.Profile
{
    public class OutgoingDateRequest
    {
        private string recieverName;
        private string receiverSpecies;
        private string requestStatus;

        public OutgoingDateRequest()
        {
            recieverName = "";
            receiverSpecies = "";
            requestStatus = "";
        }

        public string RecieverName
        {
            get { return recieverName; }
            set { recieverName = value; }
        }

        public string ReceiverSpecies
        {
            get { return receiverSpecies; }
            set { receiverSpecies = value; }
        }
        public string RequestStatus
        {
            get { return requestStatus; }
            set { requestStatus = value; }
        }
    }
}
