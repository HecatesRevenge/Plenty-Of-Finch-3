using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DatingSite.DBConnection;


namespace DatingSite.Web_Forms
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblError.Text = "";
            }

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            Validation validator = new Validation();

            string errorMessage = validator.RegistrationValidation(

                txtFirstName.Text,
                txtLastName.Text,
                txtAge.Text,
                ddlGender.SelectedValue,
                txtEmail.Text,
                txtCity.Text,
                txtState.Text,
                txtUsername.Text,
                txtPassword.Text
            );

            if (errorMessage != "")
            {
                lblError.Text = errorMessage;
                return;
            }

            AccountsDatabaseConnection accountsDB = new AccountsDatabaseConnection();

            int newUserID = accountsDB.CreateAccount(
                txtFirstName.Text,
                txtLastName.Text,
                txtCity.Text,
                txtState.Text,
                txtAge.Text,
                ddlGender.SelectedValue,
                txtUsername.Text,
                txtPassword.Text,
                txtEmail.Text,
                txtPhone.Text,
                txtAddress.Text
            );

            if (newUserID > 0)
            {
                Session["UserID"] = newUserID;
                Response.Redirect("MyProfile.aspx");
            }
            else if (newUserID == -1)
            {
                lblError.Text = "Username already exists. Please choose a different username.";
            }
            else
            {
                lblError.Text = "An error occurred while creating your account. Please try again.";
            }

        }
    }
}