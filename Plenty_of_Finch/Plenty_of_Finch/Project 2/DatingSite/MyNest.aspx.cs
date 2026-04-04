using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DatingSite.DBConnection;


namespace DatingSite.Web_Forms
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

            // Handle remove from nest
            if (Request.QueryString["action"] != null && Request.QueryString["action"] == "remove" && Request.QueryString["birdID"] != null)
            {
                int currentUserID = Convert.ToInt32(Session["UserID"]);
                int removeBirdID = Convert.ToInt32(Request.QueryString["birdID"]);

                DataBaseConnection dbConnection = new DataBaseConnection();
                dbConnection.RemoveBirdFromNest(currentUserID, removeBirdID);

                Response.Redirect("MyNest.aspx");
            }

            if (!IsPostBack)
            {
                LoadMyNest();
                LoadUpcomingDates();
                LoadDateMatchDropdown();
                LoadPlannedDates();
            }
        }

        private void LoadMyNest()
        {
            int currentUserID = Convert.ToInt32(Session["UserID"]);

            DataBaseConnection dbConnection = new DataBaseConnection();
            DataSet dsNest = dbConnection.GetMyNest(currentUserID);

            litNestBirds.Text = BuildNestHTML(dsNest);
        }

        private string BuildNestHTML(DataSet dsNest)
        {
            if (dsNest == null || dsNest.Tables[0].Rows.Count == 0)
            {
                return "<p class='text-center' style='color: #94a3b8;'>Your nest is empty. Go to the Search page to find some birds!</p>";
            }

            string html = "";

            foreach (DataRow row in dsNest.Tables[0].Rows)
            {
                string birdID = row["BirdID"].ToString();
                string fullName = row["FirstName"].ToString() + " " + row["LastName"].ToString();
                string age = row["Age"].ToString();
                string species = row["Species"].ToString();
                string location = row["City"].ToString() + ", " + row["State"].ToString();
                string profileImage = row["ProfileImage"].ToString();

                if (string.IsNullOrEmpty(profileImage))
                {
                    profileImage = "https://placehold.co/300x300?text=No+Photo";
                }

                html += "<div class='card mb-3 p-3' style='background-color: #334155;'>";
                html += "<div class='d-flex align-items-center'>";
                html += "<img src='" + profileImage + "' class='rounded-circle border border-secondary me-3' style='width: 50px; height: 50px; object-fit: cover;' />";
                html += "<div class='flex-grow-1'>";
                html += "<strong style='color: #f8fafc;'>" + fullName + "</strong>";
                html += "<span class='text-muted ms-2'>Age " + age + "</span>";
                html += "<br />";
                html += "<span style='color: #94a3b8;'>" + species + " &bull; " + location + "</span>";
                html += "</div>";
                html += "<a href='DatingProfile.aspx?id=" + birdID + "' class='btn btn-sm me-2' style='background-color: #ef4444; color: white;'>View Profile</a>";
                html += "<a href='MyNest.aspx?action=remove&birdID=" + birdID + "' class='btn btn-sm btn-outline-danger'>Remove</a>";
                html += "</div>";
                html += "</div>";
            }

            return html;
        }

        private void LoadUpcomingDates()
        {
            int currentUserID = Convert.ToInt32(Session["UserID"]);

            DataBaseConnection dbConnection = new DataBaseConnection();
            DataSet dsAcceptedDates = dbConnection.GetAcceptedDates(currentUserID);

            litUpcomingDates.Text = BuildUpcomingDatesHTML(dsAcceptedDates);
        }

        private string BuildUpcomingDatesHTML(DataSet dsAcceptedDates)
        {
            if (dsAcceptedDates == null || dsAcceptedDates.Tables[0].Rows.Count == 0)
            {
                return "<p class='text-center' style='color: #94a3b8;'>No upcoming dates yet. Send or accept a date request!</p>";
            }

            string html = "";

            foreach (DataRow row in dsAcceptedDates.Tables[0].Rows)
            {
                string birdID = row["BirdID"].ToString();
                string fullName = row["FirstName"].ToString() + " " + row["LastName"].ToString();
                string age = row["Age"].ToString();
                string gender = row["Gender"].ToString();
                string species = row["Species"].ToString();
                string location = row["City"].ToString() + ", " + row["State"].ToString();
                string profileImage = row["ProfileImage"].ToString();
                string biography = row["Biography"].ToString();
                string occupation = row["Occupation"].ToString();
                string email = row["Email"].ToString();
                string phoneNumber = row["PhoneNumber"].ToString();
                string homeAddress = row["HomeAddress"].ToString();

                if (string.IsNullOrEmpty(profileImage))
                {
                    profileImage = "https://placehold.co/300x300?text=No+Photo";
                }

                html += "<div class='card mb-3 p-4' style='background-color: #334155;'>";

                html += "<div class='d-flex align-items-center mb-3'>";
                html += "<img src='" + profileImage + "' class='rounded-circle border border-secondary me-3' style='width: 70px; height: 70px; object-fit: cover;' />";
                html += "<div>";
                html += "<h5 class='mb-0' style='color: #f8fafc;'>" + fullName + "</h5>";
                html += "<span style='color: #94a3b8;'>" + species + " &bull; " + age + " &bull; " + gender + "</span>";
                html += "</div>";
                html += "<a href='DatingProfile.aspx?id=" + birdID + "' class='btn btn-sm ms-auto' style='background-color: #ef4444; color: white;'>View Profile</a>";
                html += "</div>";

                html += "<p style='color: #cbd5e1;'>" + biography + "</p>";

                html += "<div class='row'>";
                html += "<div class='col-md-6'>";
                html += "<p style='color: #94a3b8;'><strong style='color: #f8fafc;'>Location:</strong> " + location + "</p>";
                html += "<p style='color: #94a3b8;'><strong style='color: #f8fafc;'>Occupation:</strong> " + occupation + "</p>";
                html += "</div>";

                html += "<div class='col-md-6'>";
                html += "<h6 style='color: #22c55e; border-bottom: 1px solid #475569; padding-bottom: 5px;'>Contact Info</h6>";
                html += "<p style='color: #94a3b8;'><strong style='color: #f8fafc;'>Email:</strong> " + email + "</p>";
                html += "<p style='color: #94a3b8;'><strong style='color: #f8fafc;'>Phone:</strong> " + phoneNumber + "</p>";
                html += "<p style='color: #94a3b8;'><strong style='color: #f8fafc;'>Address:</strong> " + homeAddress + "</p>";
                html += "</div>";
                html += "</div>";

                html += "</div>";
            }

            return html;
        }

        private void LoadDateMatchDropdown()
        {
            int currentUserID = Convert.ToInt32(Session["UserID"]);

            DataBaseConnection dbConnection = new DataBaseConnection();
            DataSet dsAcceptedDates = dbConnection.GetAcceptedDates(currentUserID);

            ddlDateMatch.Items.Clear();
            ddlDateMatch.Items.Add(new ListItem("-- Select a match --", ""));

            if (dsAcceptedDates != null && dsAcceptedDates.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in dsAcceptedDates.Tables[0].Rows)
                {
                    string birdID = row["BirdID"].ToString();
                    string fullName = row["FirstName"].ToString() + " " + row["LastName"].ToString();
                    ddlDateMatch.Items.Add(new ListItem(fullName, birdID));
                }
            }
        }

        protected void btnPlanDate_Click(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                Response.Redirect("Login.aspx");
                return;
            }

            int currentUserID = Convert.ToInt32(Session["UserID"]);

            if (ddlDateMatch.SelectedValue == "")
            {
                lblMessage.Text = "Select a match.";
                lblMessage.CssClass = "d-block mb-3 fw-bold text-warning text-center";
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDateTime.Text))
            {
                lblMessage.Text = "Select a date and time.";
                lblMessage.CssClass = "d-block mb-3 fw-bold text-warning text-center";
                return;
            }

            if (string.IsNullOrWhiteSpace(txtLocation.Text))
            {
                lblMessage.Text = "Enter a location.";
                lblMessage.CssClass = "d-block mb-3 fw-bold text-warning text-center";
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDateDescription.Text))
            {
                lblMessage.Text = "Enter a description.";
                lblMessage.CssClass = "d-block mb-3 fw-bold text-warning text-center";
                return;
            }

            int otherBirdID = Convert.ToInt32(ddlDateMatch.SelectedValue);
            DateTime dateOfDate = DateTime.Parse(txtDateTime.Text);
            string location = txtLocation.Text;
            string description = txtDateDescription.Text;

            DataBaseConnection dbConnection = new DataBaseConnection();

            int requestID = dbConnection.GetAcceptedRequestID(currentUserID, otherBirdID);

            if (requestID == -1)
            {
                lblMessage.Text = "Could not find accepted date request.";
                lblMessage.CssClass = "d-block mb-3 fw-bold text-warning text-center";
                return;
            }

            bool success = dbConnection.CreatePlannedDate(requestID, currentUserID, dateOfDate, location, description);

            if (success)
            {
                lblMessage.Text = "Date planned successfully!";
                lblMessage.CssClass = "d-block mb-3 fw-bold text-success text-center";

                txtDateTime.Text = "";
                txtLocation.Text = "";
                txtDateDescription.Text = "";

                LoadPlannedDates();
            }
            else
            {
                lblMessage.Text = "Could not plan date. Please try again.";
                lblMessage.CssClass = "d-block mb-3 fw-bold text-warning text-center";
            }
        }

        private void LoadPlannedDates()
        {
            int currentUserID = Convert.ToInt32(Session["UserID"]);

            DataBaseConnection dbConnection = new DataBaseConnection();
            DataSet dsPlannedDates = dbConnection.GetPlannedDates(currentUserID);

            litPlannedDates.Text = BuildPlannedDatesHTML(dsPlannedDates);
        }

        private string BuildPlannedDatesHTML(DataSet dsPlannedDates)
        {
            if (dsPlannedDates == null || dsPlannedDates.Tables[0].Rows.Count == 0)
            {
                return "<p class='text-center' style='color: #94a3b8;'>No planned dates yet. Use the form above to plan one!</p>";
            }

            string html = "";

            foreach (DataRow row in dsPlannedDates.Tables[0].Rows)
            {
                string fullName = row["FirstName"].ToString() + " " + row["LastName"].ToString();
                string species = row["Species"].ToString();
                string profileImage = row["ProfileImage"].ToString();
                string dateOfDate = Convert.ToDateTime(row["DateOfDate"]).ToString("MMM dd, yyyy h:mm tt");
                string location = row["Location"].ToString();
                string description = row["Description"].ToString();

                if (string.IsNullOrEmpty(profileImage))
                {
                    profileImage = "https://placehold.co/300x300?text=No+Photo";
                }

                html += "<div class='card mb-3 p-3' style='background-color: #334155;'>";
                html += "<div class='d-flex align-items-center mb-2'>";
                html += "<img src='" + profileImage + "' class='rounded-circle border border-secondary me-3' style='width: 50px; height: 50px; object-fit: cover;' />";
                html += "<div>";
                html += "<strong style='color: #f8fafc;'>" + fullName + "</strong>";
                html += "<span class='text-muted ms-2'>(" + species + ")</span>";
                html += "</div>";
                html += "</div>";
                html += "<div class='ms-5'>";
                html += "<p style='color: #f8fafc;'><strong style='color: #ef4444;'>When:</strong> " + dateOfDate + "</p>";
                html += "<p style='color: #f8fafc;'><strong style='color: #ef4444;'>Where:</strong> " + location + "</p>";
                html += "<p style='color: #f8fafc;'><strong style='color: #ef4444;'>Plan:</strong> " + description + "</p>";
                html += "</div>";
                html += "</div>";
            }

            return html;
        }
    }
}