namespace Plenty_of_Finch.Models.Profile
{
    public class Notification
    {
        private string text;
        private string cssClass;

        public Notification()
        {
            text = "";
            cssClass = "alert-info";
        }

        public string Text
        {
            get { return text; }
            set { text = value; }
        }

        public string CssClass
        {
            get { return cssClass; }
            set { cssClass = value; }
        }
    }
}
