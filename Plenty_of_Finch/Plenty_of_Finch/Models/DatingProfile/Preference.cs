namespace Plenty_of_Finch.Models.DatingProfile
{
    public class Preference
    {
        private string preferenceType;
        private string preferenceText;

        public Preference()
        {
            preferenceText = "";
            preferenceType = "";
        }

        public string PreferenceType
        {
            get { return preferenceType; }
            set { preferenceType = value; }
        }

        public string PreferenceText
        {
            get { return preferenceText; }
            set { preferenceText = value; }
        }
    }
}
