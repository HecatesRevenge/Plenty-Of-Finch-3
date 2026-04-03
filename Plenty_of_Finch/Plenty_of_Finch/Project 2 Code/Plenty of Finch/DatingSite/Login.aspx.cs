using DatingSite.DBConnection;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace DatingSite.Web_Forms
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblError.Text = "";
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Validation validator = new Validation();
            string errorMessage = validator.LoginValidation(txtUsername.Text, txtPassword.Text);

            if (errorMessage != "")
            {
                lblError.Text = errorMessage;
                return;
            }

            AuthDataBaseConnection authDB = new AuthDataBaseConnection();
            int userID = authDB.VerifyLogin(txtUsername.Text, txtPassword.Text);

            if (userID > 0)
            {
                Session["UserID"] = userID;
                Response.Redirect("Search.aspx");
            }
            else
            {
                lblError.Text = "Invalid username or password.";
            }
        }
    }
}

