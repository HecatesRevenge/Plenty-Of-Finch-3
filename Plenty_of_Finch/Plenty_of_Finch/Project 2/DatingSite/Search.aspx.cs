using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DatingSite.Classes;
using DatingSite.DBConnection;

namespace DatingSite
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["UserID"] == null)
            {
                Response.Redirect("Login.aspx");
                return;

            }

            if (!IsPostBack)
            {
                ddlState.DataSource = GetStateDropdown.GetStates();
                ddlState.DataTextField = "Value";
                ddlState.DataValueField = "Key";
                ddlState.DataBind();
                ddlState.Items.Insert(0, new ListItem("Any State", ""));
                LoadProfiles();
            }

        }


        private string BuildSearchResultsPage(DataSet dsProfiles)
        {
            if (dsProfiles == null || dsProfiles.Tables[0].Rows.Count == 0)
            {
                return "<div class='text-center p-5' style='background-color: #334155; border-radius: 8px;'>"
                     + "<h4 class='mt-3 text-white'>No match found.</h4>"
                     + "<p style='color: #94a3b8;'>There are no birds that match your search. Try adjusting your filters!</p>"
                     + "</div>";
            }

            string html = "<div class='row'>";

            foreach (DataRow row in dsProfiles.Tables[0].Rows)
            {
                string birdID = row["BirdID"].ToString();
                string fullName = row["FirstName"].ToString() + " " + row["LastName"].ToString();
                string age = row["Age"].ToString();
                string city = row["City"].ToString();
                string state = row["State"].ToString();
                string species = row["Species"].ToString();
                string profileImage = row["ProfileImage"].ToString();

                if (string.IsNullOrEmpty(profileImage))
                {
                    profileImage = "https://placehold.co/300x300?text=No+Photo";
                }

                html += "<div class='col mb-3' style='flex: 0 0 20%; max-width: 20%;'>";
                html += "<div class='card h-100' style='background-color: #334155; border: 1px solid #475569;'>";
                html += "<img src='" + profileImage + "' class='card-img-top' style='height: 120px; object-fit: cover;' />";
                html += "<div class='card-body p-2'>";
                html += "<h6 class='card-title mb-1' style='color: #f8fafc; font-size: 0.85rem;'>" + fullName + "</h6>";
                html += "<p class='mb-1' style='color: #94a3b8; font-size: 0.75rem;'>" + species + "</p>";
                html += "<p class='mb-1' style='color: #94a3b8; font-size: 0.75rem;'>Age " + age + " &bull; " + city + ", " + state + "</p>";
                html += "<a href='DatingProfile.aspx?id=" + birdID + "' class='btn btn-sm w-100' style='background-color: #ef4444; color: white; font-size: 0.75rem;'>View</a>";
                html += "</div>";
                html += "</div>";
                html += "</div>";
            }

            html += "</div>";
            return html;
        }
        private void LoadProfiles()
        {
            DataBaseConnection dbConnection = new DataBaseConnection();
            DataSet dsResults = null;

            if (ddlState.SelectedValue != "")
            {
                dsResults = dbConnection.SearchByState(ddlState.SelectedValue);
            }
            else if (ddlCommitment.SelectedValue != "")
            {
                dsResults = dbConnection.SearchByCommitment(ddlCommitment.SelectedValue);
            }
            else if (ddlAge.SelectedValue != "")
            {
                dsResults = dbConnection.SearchByAgeRange(ddlAge.SelectedValue);
            }
            else if (ddlWingspan.SelectedValue != "")
            {
                dsResults = dbConnection.SearchByWingSpan(ddlWingspan.SelectedValue);
            }
            else
            {
                dsResults = dbConnection.GetAllBirdProfiles();
            }

            litSearch.Text = BuildSearchResultsPage(dsResults);
        }

        protected void Filters_Changed(object sender, EventArgs e)
        {
            LoadProfiles();
        }


       
    }
}