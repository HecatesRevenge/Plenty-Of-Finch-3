using DatingSite.DBConnection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DatingSite
{
    public partial class MyProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null) { Response.Redirect("Login.aspx"); return; }

            if (Request.QueryString["action"] != null && Request.QueryString["requestID"] != null)
            {
                string action = Request.QueryString["action"].ToString();
                int requestID = Convert.ToInt32(Request.QueryString["requestID"]);
                int currentUserID = Convert.ToInt32(Session["UserID"]);

                DataBaseConnection dbConnection = new DataBaseConnection();

                if (action == "accept")
                {
                    dbConnection.UpdateDateRequestStatus(requestID, currentUserID, "Accepted");
                }
                else if (action == "decline")
                {
                    dbConnection.UpdateDateRequestStatus(requestID, currentUserID, "Declined");
                }

                Response.Redirect("MyProfile.aspx");
            }

            if (!IsPostBack)
            {
                LoadExistingProfile();
                LoadDateRequests();
                LoadProfileViewers();
                LoadNotifications();
            }
        }

        private void LoadExistingProfile()
        {
            int currentUserID = Convert.ToInt32(Session["UserID"]);

            DataBaseConnection dbConnection = new DataBaseConnection();
            DataSet dsProfile = dbConnection.GetBirdProfileFull(currentUserID);

            if (dsProfile != null && dsProfile.Tables[0].Rows.Count > 0)
            {
                DataRow profileRow = dsProfile.Tables[0].Rows[0];

                lblPageTitle.Text = "Edit Your Dating Profile";

                txtBiography.Text = profileRow["Biography"].ToString();
                txtProfileImage.Text = profileRow["ProfileImage"].ToString();
                txtSpecies.Text = profileRow["Species"].ToString();
                txtWingspan.Text = profileRow["WingSpan"].ToString();
                txtPlumage.Text = profileRow["Plumage"].ToString();
                txtOccupation.Text = profileRow["Occupation"].ToString();
                txtFavoriteSeed.Text = profileRow["FavoriteSeed"].ToString();
                ddlCommitmentType.SelectedValue = profileRow["CommitmentType"].ToString();
                txtGoals.Text = profileRow["Goals"].ToString();
                txtAgeRange.Text = profileRow["AgeRange"].ToString();
                chkVisible.Checked = Convert.ToBoolean(profileRow["IsVisible"]);

                LoadExistingPreferences(currentUserID);
            }
            else
            {
                lblPageTitle.Text = "Create Your Dating Profile";
            }
        }

        private void LoadNotifications()
        {
            int currentUserID = Convert.ToInt32(Session["UserID"]);

            DataBaseConnection dbConnection = new DataBaseConnection();
            DataSet dsIncoming = dbConnection.GetIncomingDateRequests(currentUserID);
            DataSet dsOutgoing = dbConnection.GetOutgoingDateRequests(currentUserID);

            string html = "";

            if (dsOutgoing != null && dsOutgoing.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in dsOutgoing.Tables[0].Rows)
                {
                    string requestStatus = row["RequestStatus"].ToString();
                    if (requestStatus == "Accepted")
                    {
                        string receiverName = row["FirstName"].ToString() + " " + row["LastName"].ToString();
                        html += "<div class='alert alert-success text-center mx-auto mb-2' style='max-width: 900px;'>";
                        html += "You matched with <strong>" + receiverName + "</strong>! Visit <a href='MyNest.aspx'>My Nest</a> to plan a date.";
                        html += "</div>";
                    }
                }
            }

            if (dsIncoming != null && dsIncoming.Tables[0].Rows.Count > 0)
            {
                int pendingCount = 0;
                foreach (DataRow row in dsIncoming.Tables[0].Rows)
                {
                    if (row["RequestStatus"].ToString() == "Pending")
                    {
                        pendingCount++;
                    }
                }

                if (pendingCount > 0)
                {
                    html += "<div class='alert alert-warning text-center mx-auto mb-2' style='max-width: 900px;'>";
                    html += "You have <strong>" + pendingCount.ToString() + "</strong> pending date request(s). Scroll down to view them.";
                    html += "</div>";
                }
            }

            litNotifications.Text = html;
        }


        private void LoadExistingPreferences(int profileID)
        {
            AccountsDatabaseConnection accountsDatabase = new AccountsDatabaseConnection();
            DataSet dsPreferences = accountsDatabase.GetProfilePreferences(profileID);

            if (dsPreferences == null || dsPreferences.Tables[0].Rows.Count == 0)
            {
                return;
            }

            string likes = "";
            string dislikes = "";

            foreach (DataRow row in dsPreferences.Tables[0].Rows)
            {
                string preferenceType = row["PreferenceType"].ToString();
                string preferenceText = row["PreferenceText"].ToString();

                if (preferenceType == "Like")
                {
                    if (likes != "") likes += "\n";
                    likes += preferenceText;
                }
                else if (preferenceType == "Dislike")
                {
                    if (dislikes != "") dislikes += "\n";
                    dislikes += preferenceText;
                }
            }

            txtLikes.Text = likes;
            txtDislikes.Text = dislikes;
        }


        private void SavePreferences(int profileID)
        {
            AccountsDatabaseConnection accountsDatabase = new AccountsDatabaseConnection();

            accountsDatabase.ClearProfilePreferences(profileID);

            string[] likes = txtLikes.Text.Split('\n');
            for (int i = 0; i < likes.Length; i++)
            {
                if (likes[i].Trim() != "")
                {
                    accountsDatabase.AddProfilePreferences(profileID, likes[i].Trim(), "Like");
                }
            }

            string[] dislikes = txtDislikes.Text.Split('\n');
            for (int i = 0; i < dislikes.Length; i++)
            {
                if (dislikes[i].Trim() != "")
                {
                    accountsDatabase.AddProfilePreferences(profileID, dislikes[i].Trim(), "Dislike");
                }
            }
        }



        protected void btnSaveProfile_Click(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                Response.Redirect("Login.aspx");
                return;
            }

            int currentUserID = Convert.ToInt32(Session["UserID"]);

            DataBaseConnection dbConnection = new DataBaseConnection();
            DataSet existingProfile = dbConnection.GetBirdProfileFull(currentUserID);

            AccountsDatabaseConnection accountsDatabase = new AccountsDatabaseConnection();

            if (existingProfile != null && existingProfile.Tables[0].Rows.Count > 0)
            {
                dbConnection.UpdateBirdProfile(
                    currentUserID,
                    txtBiography.Text,
                    txtProfileImage.Text,
                    txtSpecies.Text,
                    txtWingspan.Text,
                    ddlCommitmentType.SelectedValue,
                    txtGoals.Text,
                    txtPlumage.Text,
                    txtAgeRange.Text,
                    txtOccupation.Text,
                    txtFavoriteSeed.Text,
                    chkVisible.Checked
                );
            }
            else
            {
                accountsDatabase.CreateDatingProfile(
                    currentUserID,
                    txtBiography.Text,
                    txtProfileImage.Text,
                    txtSpecies.Text,
                    txtWingspan.Text,
                    ddlCommitmentType.SelectedValue,
                    txtGoals.Text,
                    txtPlumage.Text,
                    txtAgeRange.Text,
                    txtOccupation.Text,
                    txtFavoriteSeed.Text,
                    chkVisible.Checked
                );
            }

            SavePreferences(currentUserID);

            lblMessage.Text = "Profile saved successfully!";
            lblPageTitle.Text = "Edit Your Dating Profile";
        }


        private void LoadDateRequests()
        {
            int currentUserID = Convert.ToInt32(Session["UserID"]);

            DataBaseConnection dbConnection = new DataBaseConnection();

            DataSet dsIncoming = dbConnection.GetIncomingDateRequests(currentUserID);
            DataSet dsOutgoing = dbConnection.GetOutgoingDateRequests(currentUserID);

            litIncomingRequests.Text = BuildIncomingDateRequestsPage(dsIncoming);
            litOutgoingRequests.Text = BuildOutGoingDateRequestsPage(dsOutgoing);
        }

        private string BuildIncomingDateRequestsPage(DataSet dsRequests)
        {
            if (dsRequests == null || dsRequests.Tables[0].Rows.Count == 0)
            {
                return "<p class='text'>No incoming date requests</p>";
            }

            string html = "";

            foreach (DataRow row in dsRequests.Tables[0].Rows)
            {
                string requestID = row["RequestID"].ToString();
                string senderName = row["FirstName"].ToString() + " " + row["LastName"].ToString();
                string senderSpecies = row["Species"].ToString();
                string requestStatus = row["RequestStatus"].ToString();
                string profileImage = row["ProfileImage"].ToString();

                if (string.IsNullOrEmpty(profileImage))
                {
                    profileImage = "https://placehold.co/300x300?text=No+Photo";
                }

                html += "<div class='card mb-2 p-3' style='background-color: #334155;'>";
                html += "<div class='d-flex align-items-center'>";
                html += "<img src='" + profileImage + "' alt='Profile' style='width: 60px; height: 60px; object-fit: cover; border-radius: 50%; margin-right: 15px;' />";
                html += "<div style='flex: 1;'>";
                html += "<strong style='color: #f8fafc;'>" + senderName + "</strong>";
                html += "<span class='text ms-2'>(" + senderSpecies + ")</span>";
                html += "</div>";

                if (requestStatus == "Pending")
                {
                    html += "<div>";
                    html += "<a href='MyProfile.aspx?action=accept&requestID=" + requestID + "' class='btn btn-sm' style='background-color: #22c55e; color: white;'>Accept</a> ";
                    html += "<a href='MyProfile.aspx?action=decline&requestID=" + requestID + "' class='btn btn-sm' style='background-color: #ef4444; color: white;'>Decline</a>";
                    html += "</div>";
                }
                else
                {
                    string badgeColor = requestStatus == "Accepted" ? "#22c55e" : "#ef4444";
                    html += "<span class='badge' style='background-color: " + badgeColor + ";'>" + requestStatus + "</span>";
                }

                html += "</div>";
                html += "</div>";
            }

            return html;
        }

        private string BuildOutGoingDateRequestsPage(DataSet dsRequests)
        {
            if (dsRequests == null || dsRequests.Tables[0].Rows.Count == 0)
            {
                return "<p class='text'>No outgoing date requests</p>";
            }

            string html = "";

            foreach (DataRow row in dsRequests.Tables[0].Rows)
            {
                string receiverName = row["FirstName"].ToString() + " " + row["LastName"].ToString();
                string receiverSpecies = row["Species"].ToString();
                string requestStatus = row["RequestStatus"].ToString();

                string badgeColor = "#f59e0b";
                if (requestStatus == "Accepted") badgeColor = "#22c55e";
                if (requestStatus == "Declined") badgeColor = "#ef4444";

                html += "<div class='card mb-2 p-3' style='background-color: #334155;'>";
                html += "<div class='d-flex justify-content-between align-items-center'>";
                html += "<div>";
                html += "<strong style='color: #f8fafc;'>" + receiverName + "</strong>";
                html += "<span class='text ms-2'>(" + receiverSpecies + ")</span>";
                html += "</div>";
                html += "<span class='badge' style='background-color: " + badgeColor + ";'>" + requestStatus + "</span>";
                html += "</div>";
                html += "</div>";
            }

            return html;
        }

        private void LoadProfileViewers()
        {
            int currentUserID = Convert.ToInt32(Session["UserID"]);

            DataBaseConnection dbConnection = new DataBaseConnection();
            DataSet dsViewers = dbConnection.GetProfileViewers(currentUserID);

            int totalViews = dbConnection.GetProfileViewCount(currentUserID);
            lblTotalProfileViews.Text = "Total profile views: " + totalViews.ToString();

            litProfileViewers.Text = BuildProfileViewersHTML(dsViewers);
        }

        private string BuildProfileViewersHTML(DataSet dsViewers)
        {
            if (dsViewers == null || dsViewers.Tables[0].Rows.Count == 0)
            {
                return "<p class='text-center' style='color: #94a3b8;'>No one has viewed your profile yet.</p>";
            }

            string html = "";
            string currentViewerID = "";

            foreach (DataRow row in dsViewers.Tables[0].Rows)
            {
                string viewerID = row["ViewerID"].ToString();
                string fullName = row["FirstName"].ToString() + " " + row["LastName"].ToString();
                string species = row["Species"].ToString();
                string profileImage = row["ProfileImage"].ToString();
                string viewedAt = Convert.ToDateTime(row["ViewedAt"]).ToString("MMM dd, yyyy h:mm tt");

                if (string.IsNullOrEmpty(profileImage))
                {
                    profileImage = "default.png";
                }

                if (viewerID != currentViewerID)
                {
                    if (currentViewerID != "")
                    {
                        html += "</div>";
                        html += "</div>";
                    }

                    currentViewerID = viewerID;

                    html += "<div class='card mb-3 p-3' style='background-color: #334155;'>";
                    html += "<div class='d-flex align-items-center mb-2'>";
                    html += "<img src='Images/" + profileImage + "' class='rounded-circle border border-secondary me-3' style='width: 40px; height: 40px; object-fit: cover;' />";
                    html += "<div>";
                    html += "<strong style='color: #f8fafc;'>" + fullName+ "</strong>";
                    html += "<span class='text-muted ms-2'>(" + species + ")</span>";
                    html += "</div>";
                    html += "<a href='DatingProfile.aspx?id=" + viewerID + "' class='btn btn-sm ms-auto' style='background-color: #ef4444; color: white;'>View Profile</a>";
                    html += "</div>";
                    html += "<div class='ms-5'>";
                }

                html += "<div style='color: #94a3b8; font-size: 0.9em;'>Viewed on " + viewedAt + "</div>";
            }

            if (currentViewerID != "")
            {
                html += "</div>";
                html += "</div>";
            }

            return html;
        }



        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }
    }
}