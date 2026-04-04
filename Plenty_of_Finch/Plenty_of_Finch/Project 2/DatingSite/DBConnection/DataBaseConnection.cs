using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DatingSite.DBConnection
{
    public class DataBaseConnection
    {
        // Main Connection String - used for the published web application and project submissions.
        //String SqlConnectString = "server=cis-mssql1.temple.edu;Database=sp26_3342_tus45674;User id=tus45674;Password=zaaf9Cae4x; TrustServerCertificate=true";

        // Home Connection String - used for working from home using SSH Tunneling.
        String SqlConnectString = "server=127.0.0.1,5555;Database=sp26_3342_tus45674;User id=tus45674;Password=zaaf9Cae4x; TrustServerCertificate=true";

        SqlConnection myConnectionSql;
   

        public DataBaseConnection()
        {
            myConnectionSql = new SqlConnection(SqlConnectString);
        }


        public DataSet GetBirdProfilePublic(int birdID)
        {
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "GetBirdProfilePublic";

            objCommand.Parameters.AddWithValue("@TargetBirdID", birdID);

            DBConnect objDB = new DBConnect();
            DataSet myDataSet = objDB.GetDataSetUsingCmdObj(objCommand);

            return myDataSet;
        }

        public DataSet GetBirdProfileFull(int birdID)
        {
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "GetBirdProfileFull";

            objCommand.Parameters.AddWithValue("@TargetBirdID", birdID);

            DBConnect objDB = new DBConnect();
            DataSet myDataSet = objDB.GetDataSetUsingCmdObj(objCommand);

            return myDataSet;
        }

        public bool CheckBirdInNest(int userID, int savedBirdID)
        {
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "CheckBirdInNest";

            objCommand.Parameters.AddWithValue("@UserID", userID);
            objCommand.Parameters.AddWithValue("@SavedBirdID", savedBirdID);

            DBConnect objDB = new DBConnect();
            DataSet myDataSet = objDB.GetDataSetUsingCmdObj(objCommand);

            if (myDataSet != null && myDataSet.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            return false;
        }

        public bool CheckAcceptedDateRequest(int userID, int targetBirdID)
        {
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "CheckAcceptedDateRequest";

            objCommand.Parameters.AddWithValue("@BirdID1", userID);
            objCommand.Parameters.AddWithValue("@BirdID2", targetBirdID);

            DBConnect objDB = new DBConnect();
            DataSet myDataSet = objDB.GetDataSetUsingCmdObj(objCommand);

            if (myDataSet != null && myDataSet.Tables[0].Rows.Count > 0)
            {
                int matchCount = Convert.ToInt32(myDataSet.Tables[0].Rows[0]["MatchCount"]);
                return (matchCount > 0);
            }
            return false;
        }

        public bool DateRequest(int senderID, int RecieverID)
        {
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "DateRequest";

            objCommand.Parameters.AddWithValue("@SenderID", senderID);
            objCommand.Parameters.AddWithValue("@ReceiverID", RecieverID);

            DBConnect odjDB = new DBConnect();
            int rowsAffected = odjDB.DoUpdateUsingCmdObj(objCommand);
            return (rowsAffected > 0);

        }

        public bool AddBirdToNest(int birdID, int savedBirdID)
        {

            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "AddBirdToNest";

            objCommand.Parameters.AddWithValue("@UserID", birdID);
            objCommand.Parameters.AddWithValue("@SavedBirdID", savedBirdID);

            DBConnect objDB = new DBConnect();
            int rowsAffected = objDB.DoUpdateUsingCmdObj(objCommand);

            return (rowsAffected > 0);

        }

        public bool IncrementTotalLikes(int birdID)
        {
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;

            objCommand.CommandText = "IncrementTotalLikes";

            objCommand.Parameters.AddWithValue("@BirdID", birdID);

            DBConnect objDB = new DBConnect();
            int rowsAffected = objDB.DoUpdateUsingCmdObj(objCommand);
            return (rowsAffected > 0);

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

        public bool LogProfileViews(int viewerID, int viewedBirdID)
        {
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "LogProfileView";

            objCommand.Parameters.AddWithValue("@ViewerID", viewerID);
            objCommand.Parameters.AddWithValue("@ViewedID", viewedBirdID);
            DBConnect objDB = new DBConnect();
            int rowsAffected = objDB.DoUpdateUsingCmdObj(objCommand);

            return rowsAffected > 0;
        }

        public int GetProfileViewCount(int birdID)
        {
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "GetProfileViewCount";

            objCommand.Parameters.AddWithValue("@BirdID", birdID);

            DBConnect odjDB = new DBConnect();
            DataSet myDataSet = odjDB.GetDataSetUsingCmdObj(objCommand);

            if (myDataSet != null && myDataSet.Tables[0].Rows.Count > 0)
            {
                return Convert.ToInt32(myDataSet.Tables[0].Rows[0]["TotalViews"]);

            }
            return 0;
        }

        public DataSet SearchByState(string state)
        {
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "SearchByState";

            objCommand.Parameters.AddWithValue("@State", state);

            DBConnect objDB = new DBConnect();
            DataSet myDataSet = objDB.GetDataSetUsingCmdObj(objCommand);
            return myDataSet;
        }

        public DataSet SearchByWingSpan(string wingSpan)
        {
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "SearchByWingSpan";

            objCommand.Parameters.AddWithValue("@WingSpan", wingSpan);

            DBConnect odjDB = new DBConnect();
            DataSet myDataSet = odjDB.GetDataSetUsingCmdObj(objCommand);
            return myDataSet;
        }

        public DataSet SearchByAgeRange(string ageRange)
        {
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = ("SearchByAgeRange");

            objCommand.Parameters.AddWithValue("@AgeRange", ageRange);

            DBConnect odjDB = new DBConnect();
            DataSet myDataSet = odjDB.GetDataSetUsingCmdObj(objCommand);
            return myDataSet;
        }

        public DataSet SearchByCommitment(string commitmentType)
        {
            SqlCommand odjCommand = new SqlCommand();
            odjCommand.CommandType = CommandType.StoredProcedure;
            odjCommand.CommandText = "SearchByCommitmentType";

            odjCommand.Parameters.AddWithValue("@CommitmentType", commitmentType);

            DBConnect odjDB = new DBConnect();
            DataSet myDataSet = odjDB.GetDataSetUsingCmdObj(odjCommand);
            return myDataSet;
        }

        public DataSet GetAllBirdProfiles()
        {
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;


            objCommand.CommandText = "GetAllBirdProfiles";

            DBConnect odjDB = new DBConnect();
            DataSet myDataSet = odjDB.GetDataSetUsingCmdObj(objCommand);
            return myDataSet;

        }

        public DataSet GetIncomingDateRequests(int receiverID)
        {
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "GetIncomingDateRequests";

            objCommand.Parameters.AddWithValue("@ReceiverID", receiverID);

            DBConnect objDB = new DBConnect();
            DataSet myDataSet = objDB.GetDataSetUsingCmdObj(objCommand);
            return myDataSet;
        }

        public DataSet GetOutgoingDateRequests(int senderID)
        {
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "GetOutgoingDateRequests";

            objCommand.Parameters.AddWithValue("@SenderID", senderID);

            DBConnect objDB = new DBConnect();
            DataSet myDataSet = objDB.GetDataSetUsingCmdObj(objCommand);
            return myDataSet;
        }

        public bool UpdateDateRequestStatus(int requestID, int receiverID, string status)
        {
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "UpdateDateRequestStatus";

            objCommand.Parameters.AddWithValue("@RequestID", requestID);
            objCommand.Parameters.AddWithValue("@ReceiverID", receiverID);
            objCommand.Parameters.AddWithValue("@NewStatus", status);

            DBConnect objDB = new DBConnect();
            int rowsAffected = objDB.DoUpdateUsingCmdObj(objCommand);
            return (rowsAffected > 0);
        }

        public DataSet GetMyNest(int userID)
        {
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "GetMyNest";

            objCommand.Parameters.AddWithValue("@UserID", userID);

            DBConnect objDB = new DBConnect();
            DataSet myDataSet = objDB.GetDataSetUsingCmdObj(objCommand);
            return myDataSet;
        }

        public DataSet GetAcceptedDates(int userID)
        {
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "GetAcceptedDates";

            objCommand.Parameters.AddWithValue("@UserID", userID);

            DBConnect objDB = new DBConnect();
            DataSet myDataSet = objDB.GetDataSetUsingCmdObj(objCommand);
            return myDataSet;
        }

        public bool CheckExistingDateRequest(int senderID, int receiverID)
        {
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "CheckExistingDateRequest";

            objCommand.Parameters.AddWithValue("@BirdID1", senderID);
            objCommand.Parameters.AddWithValue("@BirdID2", receiverID);

            DBConnect objDB = new DBConnect();
            DataSet myDataSet = objDB.GetDataSetUsingCmdObj(objCommand);

            if (myDataSet != null && myDataSet.Tables[0].Rows.Count > 0)
            {
                int matchCount = Convert.ToInt32(myDataSet.Tables[0].Rows[0]["MatchCount"]);
                return (matchCount > 0);
            }
            return false;
        }

        public bool CreatePlannedDate(int requestID, int plannerID, DateTime dateOfDate, string location, string description)
        {
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "CreatePlannedDate";

            objCommand.Parameters.AddWithValue("@RequestID", requestID);
            objCommand.Parameters.AddWithValue("@PlannerID", plannerID);
            objCommand.Parameters.AddWithValue("@DateOfDate", dateOfDate);
            objCommand.Parameters.AddWithValue("@Location", location);
            objCommand.Parameters.AddWithValue("@Description", description);

            DBConnect objDB = new DBConnect();
            int rowsAffected = objDB.DoUpdateUsingCmdObj(objCommand);
            return (rowsAffected > 0);
        }

        public DataSet GetPlannedDates(int userID)
        {
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "GetPlannedDates";

            objCommand.Parameters.AddWithValue("@UserID", userID);

            DBConnect objDB = new DBConnect();
            DataSet myDataSet = objDB.GetDataSetUsingCmdObj(objCommand);
            return myDataSet;
        }

        public int GetAcceptedRequestID(int userID, int otherBirdID)
        {
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "GetAcceptedRequestID";

            objCommand.Parameters.AddWithValue("@UserID", userID);
            objCommand.Parameters.AddWithValue("@OtherBirdID", otherBirdID);

            DBConnect objDB = new DBConnect();
            DataSet myDataSet = objDB.GetDataSetUsingCmdObj(objCommand);

            if (myDataSet != null && myDataSet.Tables[0].Rows.Count > 0)
            {
                return Convert.ToInt32(myDataSet.Tables[0].Rows[0]["RequestID"]);
            }
            return -1;
        }
        public bool RemoveBirdFromNest(int userID, int savedBirdID)
        {
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "RemoveBirdFromNest";

            objCommand.Parameters.AddWithValue("@UserID", userID);
            objCommand.Parameters.AddWithValue("@SavedBirdID", savedBirdID);

            DBConnect objDB = new DBConnect();
            int rowsAffected = objDB.DoUpdateUsingCmdObj(objCommand);
            return (rowsAffected > 0);
        }
        public DataSet GetProfileViewers(int viewedID)
        {
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "GetProfileViewers";

            objCommand.Parameters.AddWithValue("@ViewedID", viewedID);

            DBConnect objDB = new DBConnect();
            DataSet myDataSet = objDB.GetDataSetUsingCmdObj(objCommand);
            return myDataSet;
        }
        public bool UpdateBirdProfile(int birdID, string biography, string profileImage, string species, string wingSpan, string commitmentType, string goals, string plumage, string ageRange, string occupation, string favoriteSeed, bool isVisible)
        {
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "UpdateBirdProfile";

            objCommand.Parameters.AddWithValue("@BirdID", birdID);
            objCommand.Parameters.AddWithValue("@Biography", biography);
            objCommand.Parameters.AddWithValue("@ProfileImage", profileImage);
            objCommand.Parameters.AddWithValue("@Species", species);
            objCommand.Parameters.AddWithValue("@WingSpan", wingSpan);
            objCommand.Parameters.AddWithValue("@CommitmentType", commitmentType);
            objCommand.Parameters.AddWithValue("@Goals", goals);
            objCommand.Parameters.AddWithValue("@Plumage", plumage);
            objCommand.Parameters.AddWithValue("@AgeRange", ageRange);
            objCommand.Parameters.AddWithValue("@Occupation", occupation);
            objCommand.Parameters.AddWithValue("@FavoriteSeed", favoriteSeed);
            objCommand.Parameters.AddWithValue("@IsVisible", isVisible);

            DBConnect objDB = new DBConnect();
            int rowsAffected = objDB.DoUpdateUsingCmdObj(objCommand);
            return (rowsAffected > 0);
        }
    }
}