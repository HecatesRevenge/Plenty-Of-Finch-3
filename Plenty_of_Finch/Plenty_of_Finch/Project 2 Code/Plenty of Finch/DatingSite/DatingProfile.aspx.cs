
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DatingSite.Classes;
using DatingSite.DBConnection;


namespace DatingSite
{
    public partial class ShowProfile : System.Web.UI.Page
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
                string selectedBirdID = Request.QueryString["id"].ToString();
                LoadBirdProfiles(selectedBirdID);
            }
        }


        private void LoadBirdProfiles(string birdID)
        {
            int currentUserID = Convert.ToInt32(Session["UserID"]);
            int targetBirdID = Convert.ToInt32(birdID);

            DataBaseConnection dbConnection = new DataBaseConnection();

            bool hasAcceptedDate = dbConnection.CheckAcceptedDateRequest(currentUserID, targetBirdID);

            DataSet dsProfile;

            //Users can't see the full profiele details especially since it contains contact info if a date hasnt be accepted. 
            if (hasAcceptedDate)
            {
                dsProfile = dbConnection.GetBirdProfileFull(targetBirdID);
            }
            else
            {
                dsProfile = dbConnection.GetBirdProfilePublic(targetBirdID);
            }

            if (dsProfile == null || dsProfile.Tables[0].Rows.Count == 0)
            {
                Response.Redirect("Search.aspx");
                return;
            }

            DataRow bord = dsProfile.Tables[0].Rows[0];


            lblName.Text = bord["FirstName"].ToString() + " " + bord["LastName"].ToString();
            lblGender.Text = bord["Gender"].ToString();
            lblAge.Text = bord["Age"].ToString();
            lblLocation.Text = bord["City"].ToString() + ", " + bord["State"].ToString();

            string imgPath = bord["ProfileImage"].ToString();

            if (string.IsNullOrEmpty(imgPath))
            {
                imgPath = "https://placehold.co/300x300?text=No+Photo";
            }

            //Make sure to get images from the website
            imgProfile.ImageUrl = imgPath;

            txtbBio.Text = bord["Biography"].ToString();

            lblGoal.Text = bord["Goals"].ToString();

            lblCommitment.Text = bord["CommitmentType"].ToString();
            lblAgeRange.Text = bord["AgeRange"].ToString();
            lblSpecies.Text = bord["Species"].ToString();
            lblWingspan.Text = bord["WingSpan"].ToString();
            lblSeed.Text = bord["FavoriteSeed"].ToString();
            lblPlumage.Text = bord["Plumage"].ToString();
            lblOccupation.Text = bord["Occupation"].ToString();

            lblTotalLikes.Text = bord["TotalLikes"].ToString();

            if (hasAcceptedDate)
            {
                pnlContactInfo.Visible = true;
                lblEmail.Text = bord["Email"].ToString();
                lblPhone.Text = bord["PhoneNumber"].ToString();
                lblAddress.Text = bord["HomeAddress"].ToString();
            }

            LoadProfilePreferences(targetBirdID);

            bool inNest = dbConnection.CheckBirdInNest(currentUserID, targetBirdID);

            if (inNest)
            {
                btnLike.Enabled = false;
                btnLike.Text = "Already in Your Nest";
                btnLike.CssClass = "btn btn-secondary w-100 mt-2";
            }

            if (currentUserID == targetBirdID)
            {
                btnLike.Visible = false;
                btnRequestDate.Visible = false;
            }

            bool hasExistingRequest = dbConnection.CheckExistingDateRequest(currentUserID, targetBirdID);

            if (hasExistingRequest)
            {
                btnRequestDate.Enabled = false;
                btnRequestDate.Text = "Request Sent";
                btnRequestDate.CssClass = "btn btn-secondary w-100 mt-2";
            }

            dbConnection.LogProfileViews(currentUserID, targetBirdID);
            int totalViews = dbConnection.GetProfileViewCount(targetBirdID);
            lblTotalViews.Text = totalViews.ToString();



        }

        private void LoadProfilePreferences(int profileID)
        {
            DataBaseConnection dataBaeConnection = new DataBaseConnection();
            DataSet dsPreference = dataBaeConnection.GetProfilePreferences(profileID);

            if (dsPreference == null || dsPreference.Tables[0].Rows.Count == 0)
            {
                litLikes.Text = "<p class='text-muted'>No likes listed</p>";
                litDislikes.Text = "<p class='text-muted'>No dislikes listed</p>";
                return;
            }

            string likesHTML = "";
            string dislikesHTML = "";

            foreach (DataRow row in dsPreference.Tables[0].Rows)
            {
                string prefText = row["PreferenceText"].ToString();
                string prefType = row["PreferenceType"].ToString();

                if (prefType == "Like")
                {
                    likesHTML += "<div class='form-check'>";
                    likesHTML += "<input type='checkbox' class='form-check-input' checked='checked' disabled='disabled' />";
                    likesHTML += "<label class='form-check-label text-muted'>" + prefText + "</label>";
                    likesHTML += "</div>";
                }
                else if (prefType == "Dislike")
                {
                    dislikesHTML += "<div class='form-check'>";
                    dislikesHTML += "<input type='checkbox' class='form-check-input' checked='checked' disabled='disabled' />";
                    dislikesHTML += "<label class='form-check-label text-muted'>" + prefText + "</label>";
                    dislikesHTML += "</div>";
                }
            }

            if (string.IsNullOrEmpty(likesHTML))
            {
                likesHTML = "<p class='text-muted'>No likes listed</p>";
            }
            if (string.IsNullOrEmpty(dislikesHTML))
            {
                dislikesHTML = "<p class='text-muted'>No dislikes listed</p>";
            }

            litLikes.Text = likesHTML;
            litDislikes.Text = dislikesHTML;



        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                Response.Redirect("Login.aspx");
                return;
            }

            int currentUserID = Convert.ToInt32(Session["UserID"]);
            int savedBird = Convert.ToInt32(Request.QueryString["id"]);

            DataBaseConnection dbConnection = new DataBaseConnection();

            bool alreadyInNest = dbConnection.CheckBirdInNest(currentUserID, savedBird);

            if (alreadyInNest)
            {
                btnLike.Enabled = false;
                btnLike.Text = "Already in Your Nest";
                btnLike.CssClass = "btn btn-secondary w-100 mt-2";
                return;

            }

            dbConnection.AddBirdToNest(currentUserID, savedBird);
            dbConnection.IncrementTotalLikes(savedBird);

            int currentLikes = int.Parse(lblTotalLikes.Text);
            lblTotalLikes.Text = (currentLikes + 1).ToString();

            lblMessage.Text = "Bird added to your nest!";
            btnLike.Enabled = false;
            btnLike.Text = "Already in Your Nest";
            btnLike.CssClass = "btn btn-secondary w-100 mt-2";
        }

        protected void btnRequestDate_Click(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                Response.Redirect("Login.aspx");
                return;
            }

            int currentUserID = Convert.ToInt32(Session["UserID"]);
            int receiverID = Convert.ToInt32(Request.QueryString.Get("id"));

            DataBaseConnection dbConnection = new DataBaseConnection();
            bool success = dbConnection.DateRequest(currentUserID, receiverID);


            if (success)
            {
                lblMessage.Text = "Date request sent!";
                btnRequestDate.Enabled = false;
                btnRequestDate.Text = "Request Sent";
                btnRequestDate.CssClass = "btn btn-secondary w-100 mt-2";
            }

            else
            {
                lblMessage.Text = "Could not send date request. Already sent request.";
                lblMessage.CssClass = "d-block mt-2 fw-bold text-warning";
            }
        }
    }


}
