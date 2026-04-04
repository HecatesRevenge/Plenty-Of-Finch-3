using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DatingSite.DBConnection
{
    public class AccountsDatabaseConnection
    {   // Main Connection String - used for the published web application and project submissions.
      //  String SqlConnectString = "server=cis-mssql1.temple.edu;Database=sp26_3342_tus45674;User id=tus45674;Password=zaaf9Cae4x; TrustServerCertificate=true";

        // Home Connection String - used for working from home using SSH Tunneling.
        String SqlConnectString = "server=127.0.0.1,5555;Database=sp26_3342_tus45674;User id=tus45674;Password=zaaf9Cae4x; TrustServerCertificate=true";

        SqlConnection myConnectionSql;
     

        public AccountsDatabaseConnection()
        {
            myConnectionSql = new SqlConnection(SqlConnectString);
        }

        public int CreateAccount(string firstName, string lastName, string city, string state, string age, string gender, string username, string password, string email, string phoneNumber, string homeAddress)
        {
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

                DBConnect objDB = new DBConnect();
                DataSet myDataSet = objDB.GetDataSetUsingCmdObj(objCommand);

                if (myDataSet != null && myDataSet.Tables[0].Rows.Count > 0)
                {
                    return Convert.ToInt32(myDataSet.Tables[0].Rows[0][0]);
                }
                else
                {
                    return -1;
                }
            }

        }




        public int CreateDatingProfile(int birdID, string biography, string profileImage, string species, string wingSpan, string commitmentType, string goals, string plumage, string ageRange, string occupation, string favoriteSeed, bool isVisible)
        {
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "CreateBirdProfile";

            objCommand.Parameters.AddWithValue("@BirdID", birdID);
            objCommand.Parameters.AddWithValue("@Biography", biography);
            objCommand.Parameters.AddWithValue("@ProfileImage", profileImage);
            objCommand.Parameters.AddWithValue("@Species", species);
            objCommand.Parameters.AddWithValue("@WingSpan", wingSpan);
            objCommand.Parameters.AddWithValue("@CommitmentType", commitmentType);
            objCommand.Parameters.AddWithValue("@Goals", goals);
            objCommand.Parameters.AddWithValue("@Plumage", plumage);
            objCommand.Parameters.AddWithValue("@AgeRange", ageRange);
            objCommand.Parameters.AddWithValue("@IsVisible", isVisible);
            objCommand.Parameters.AddWithValue("@Occupation", occupation);
            objCommand.Parameters.AddWithValue("@FavoriteSeed", favoriteSeed);

            DBConnect objDB = new DBConnect();
            DataSet myDataSet = objDB.GetDataSetUsingCmdObj(objCommand);

            if (myDataSet != null && myDataSet.Tables[0].Rows.Count > 0)
            {
                return Convert.ToInt32(myDataSet.Tables[0].Rows[0][0]);
            }
            else
            {
                return -1;
            }
        }



        public bool AddProfilePreferences(int profile, string text, string type)
        {
            {



                SqlCommand objCommand = new SqlCommand();
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "AddProfilePreferences";

                objCommand.Parameters.AddWithValue("@ProfileID", profile);
                objCommand.Parameters.AddWithValue("@Text", text);
                objCommand.Parameters.AddWithValue("@Type", type);

                DBConnect objDB = new DBConnect();
                int result = objDB.DoUpdateUsingCmdObj(objCommand);
                return result > 0;
            }





        }

        public DataSet GetProfilePreferences(int profileID)
        {
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "GetProfilePreferences";
            objCommand.Parameters.AddWithValue("@ProfileID", profileID);

            DBConnect objDB = new DBConnect();
            DataSet myDataSet = objDB.GetDataSetUsingCmdObj(objCommand);

            return myDataSet;
        }

        public void ClearProfilePreferences(int profileID)
        {
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "ClearProfilePreferences";
            objCommand.Parameters.AddWithValue("@ProfileID", profileID);
            DBConnect objDB = new DBConnect();
            objDB.DoUpdateUsingCmdObj(objCommand);
        }



    }
}