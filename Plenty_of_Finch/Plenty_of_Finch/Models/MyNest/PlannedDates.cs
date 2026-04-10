namespace Plenty_of_Finch.Models.MyNest
{
    public class PlannedDates
    {
        private string firstName;
        private string lastName;
        private string species;
        private string profileImage;
        private DateTime dateOfDate;
        private string location;
        private string description;

        public PlannedDates()
        {
            firstName = "";
            lastName = "";
            species = "";
            profileImage = "";
            dateOfDate = DateTime.Now;
            location = "";
            description = "";
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
        public DateTime DateOfDate
        {
            get { return dateOfDate; }
            set { dateOfDate = value; }
        }
        public string Location
        {
            get { return location; }
            set { location = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }
    }
}
