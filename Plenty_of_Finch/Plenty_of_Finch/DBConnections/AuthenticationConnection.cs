using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace Plenty_of_Finch.DBConnections
{
    public class AuthenticationConnection
    {
        public int VerifyLogin(string username, string password)
        {
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "VerifyLogin";

            objCommand.Parameters.AddWithValue("@Username", username);
            objCommand.Parameters.AddWithValue("@Password", password);

            DBConnect objDB = new DBConnect();
            DataSet myDataSet = objDB.GetDataSetUsingCmdObj(objCommand);

            if (myDataSet != null && myDataSet.Tables[0].Rows.Count > 0)
            {
                return Convert.ToInt32(myDataSet.Tables[0].Rows[0][0]);
            }
            return -1;
        }

        public DataSet GetSecurityQuestion(string usernmae)
        {
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "GetSecurityQuestion";

            objCommand.Parameters.AddWithValue("@Username", usernmae);

            DBConnect objDB = new DBConnect();
            DataSet myDataSet = objDB.GetDataSetUsingCmdObj(objCommand);

            return myDataSet;
        }

        public bool VerifySecurityAnswer(string username, string question, string answer)
        {
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "VerifySecurityAnswer";

            objCommand.Parameters.AddWithValue("@Username", username);
            objCommand.Parameters.AddWithValue("@Question", question);
            objCommand.Parameters.AddWithValue("@Answer", answer);

            DBConnect objDB = new DBConnect();
            DataSet myDataSet = objDB.GetDataSetUsingCmdObj(objCommand);

            if (myDataSet != null && myDataSet.Tables[0].Rows.Count > 0)
            {
                int matchCount = Convert.ToInt32(myDataSet.Tables[0].Rows[0][0]);
                return (matchCount > 0);
            }
            return false;
        }

        public bool ResetPassword(string username, string newPassword)
        {
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "ResetPassword";

            objCommand.Parameters.AddWithValue("@Username", username);
            objCommand.Parameters.AddWithValue("@NewPassword", newPassword);

            DBConnect objDB = new DBConnect();
            int rowsAffected = objDB.DoUpdateUsingCmdObj(objCommand);
            return (rowsAffected > 0);
        }

        public string GetUsernameByEmail(string email)
        {
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "GetUsernameByEmail";

            objCommand.Parameters.AddWithValue("@Email", email);

            DBConnect objDB = new DBConnect();
            DataSet myDataSet = objDB.GetDataSetUsingCmdObj(objCommand);

            if (myDataSet != null && myDataSet.Tables[0].Rows.Count > 0)
            {
                return myDataSet.Tables[0].Rows[0]["Username"].ToString();
            }
            return "";
        }

        public DataSet GetSecurityQuestionByEmail(string email)
        {
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "GetSecurityQuestionByEmail";

            objCommand.Parameters.AddWithValue("@Email", email);

            DBConnect objDB = new DBConnect();
            DataSet myDataSet = objDB.GetDataSetUsingCmdObj(objCommand);
            return myDataSet;
        }

        public bool VerifySecurityAnswerByEmail(string email, string question, string answer)
        {
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "VerifySecurityAnswerByEmail";

            objCommand.Parameters.AddWithValue("@Email", email);
            objCommand.Parameters.AddWithValue("@Question", question);
            objCommand.Parameters.AddWithValue("@Answer", answer);

            DBConnect objDB = new DBConnect();
            DataSet myDataSet = objDB.GetDataSetUsingCmdObj(objCommand);

            if (myDataSet != null && myDataSet.Tables[0].Rows.Count > 0)
            {
                int matchCount = Convert.ToInt32(myDataSet.Tables[0].Rows[0][0]);
                return (matchCount > 0);
            }
            return false;
        }
        public int CreateAccount(string firstName, string lastName, string city,
           string state, string age, string gender, string username, string password,
           string email, string phoneNumber, string homeAddress,
           string securityQuestion1, string securityAnswer1,
           string securityQuestion2, string securityAnswer2,
           string securityQuestion3, string securityAnswer3)
        {
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "CreateAccount";

            objCommand.Parameters.AddWithValue("@FirstName", firstName);
            objCommand.Parameters.AddWithValue("@LastName", lastName);
            objCommand.Parameters.AddWithValue("@City", city);
            objCommand.Parameters.AddWithValue("@State", state);
            objCommand.Parameters.AddWithValue("@Age", age);
            objCommand.Parameters.AddWithValue("@Gender", gender);
            objCommand.Parameters.AddWithValue("@Username", username);
            objCommand.Parameters.AddWithValue("@Password", password);
            objCommand.Parameters.AddWithValue("@Email", email);
            objCommand.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
            objCommand.Parameters.AddWithValue("@HomeAddress", homeAddress);
            objCommand.Parameters.AddWithValue("@SecurityQuestion1", securityQuestion1);
            objCommand.Parameters.AddWithValue("@SecurityAnswer1", securityAnswer1);
            objCommand.Parameters.AddWithValue("@SecurityQuestion2", securityQuestion2);
            objCommand.Parameters.AddWithValue("@SecurityAnswer2", securityAnswer2);
            objCommand.Parameters.AddWithValue("@SecurityQuestion3", securityQuestion3);
            objCommand.Parameters.AddWithValue("@SecurityAnswer3", securityAnswer3);

            DBConnect objDB = new DBConnect();
            DataSet myDataSet = objDB.GetDataSetUsingCmdObj(objCommand);

            if (myDataSet != null && myDataSet.Tables[0].Rows.Count > 0)
            {
                return Convert.ToInt32(myDataSet.Tables[0].Rows[0][0]);
            }
            return -1;
        }

    }
}
