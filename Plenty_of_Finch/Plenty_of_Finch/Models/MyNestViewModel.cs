using Microsoft.AspNetCore.Mvc.Rendering;
using Plenty_of_Finch.Models.MyNest;


namespace Plenty_of_Finch.Models
{
    public class MyNestViewModel
    {

        private List<NestBirdProfiles> nestBirdProfiles;
        private List<PlannedDates> plannedDates;
        private List<UpcomingDates> upcomingDates;
        private List<SelectListItem> matchOptions;

        private string matchID;
        private DateTime dateTime;
        private string location;
        private string description;

        private string message;
        private bool messageVisible;

        public MyNestViewModel()
        {
            nestBirdProfiles = new List<NestBirdProfiles>();
            plannedDates = new List<PlannedDates>();
            upcomingDates = new List<UpcomingDates>();
            matchOptions = new List<SelectListItem>();
            matchID = "";
            dateTime = DateTime.Now;
            location = "";
            description = "";
            message = "";
            messageVisible = false;
        }

        public List<NestBirdProfiles> NestBirdProfiles
        {
            get { return nestBirdProfiles; }
            set { nestBirdProfiles = value; }
        }

        public List<PlannedDates> PlannedDates
        {
            get { return plannedDates; }
            set { plannedDates = value; }
        }

        public List<UpcomingDates> UpcomingDates
        {
            get { return upcomingDates; }
            set { upcomingDates = value; }
        }

        public List<SelectListItem> MatchOptions
        {
            get { return matchOptions; }
            set { matchOptions = value; }
        }

        public string MatchID
        {
            get { return matchID; }
            set { matchID = value; }
        }

        public DateTime DateTime
        {
            get { return dateTime; }
            set { dateTime = value; }
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

        public string Message
        {
            get { return message; }
            set { message = value; }
        }

        public bool MessageVisible
        {
            get { return messageVisible; }
            set { messageVisible = value; }
        }
    }
}
