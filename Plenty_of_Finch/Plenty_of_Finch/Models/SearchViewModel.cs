using Plenty_of_Finch.Models.Search;

namespace Plenty_of_Finch.Models

{
    public class SearchViewModel
    {

        private string selectedState;
        private string selectedCommitment;
        private string selectedAge;
        private string selectedWingspan;

        private List<string> stateOptions;
        private List<SearchResult> results;

        public SearchViewModel()
        {
            selectedState = "";
            selectedCommitment = "";
            selectedAge = "";
            selectedWingspan = "";
            results = new List<SearchResult>();
        }

        public string SelectedState
        {
            get { return selectedState; }
            set { selectedState = value; }
        }

        public string SelectedCommitment
        {
            get { return selectedCommitment; }
            set { selectedCommitment = value; }
        }

        public string SelectedAge
        {
            get { return selectedAge; }
            set { selectedAge = value; }
        }

        public string SelectedWingspan
        {
            get { return selectedWingspan; }
            set { selectedWingspan = value; }
        }

        public List<string> StateOptions
        {
            get { return stateOptions; }
            set { stateOptions = value; }
        }

        public List<SearchResult> Results
        {
            get { return results; }
            set { results = value; }
        }
    }
}
