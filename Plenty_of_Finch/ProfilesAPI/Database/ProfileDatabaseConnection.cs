using Microsoft.Data.SqlClient;
using ProfileAPI.DataAccess;
using System.Data;

namespace ProfilesAPI.Database
{
    public class ProfileDatabaseConnection
    {

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

        public DataSet GetAllBirdProfiles()
        {
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "GetAllBirdProfiles";

            DBConnect objDB = new DBConnect();
            DataSet myDataSet = objDB.GetDataSetUsingCmdObj(objCommand);
            return myDataSet;
        }


        public int CreateDatingProfile(int birdID, string biography, string profileImage,
       string species, string wingSpan, string commitmentType, string goals,
       string plumage, string ageRange, string occupation, string favoriteSeed,
       bool isVisible)
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
            objCommand.Parameters.AddWithValue("@Occupation", occupation);
            objCommand.Parameters.AddWithValue("@FavoriteSeed", favoriteSeed);
            objCommand.Parameters.AddWithValue("@IsVisible", isVisible);

            DBConnect objDB = new DBConnect();
            DataSet myDataSet = objDB.GetDataSetUsingCmdObj(objCommand);

            if (myDataSet != null && myDataSet.Tables[0].Rows.Count > 0)
            {
                return Convert.ToInt32(myDataSet.Tables[0].Rows[0][0]);
            }
            return -1;
        }

        public bool UpdateBirdProfile(int birdID, string biography, string profileImage,
            string species, string wingSpan, string commitmentType, string goals,
            string plumage, string ageRange, string occupation, string favoriteSeed,
            bool isVisible)
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

        public bool AddBirdToNest(int userID, int savedBirdID)
        {
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "AddBirdToNest";

            objCommand.Parameters.AddWithValue("@UserID", userID);
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

        public bool DateRequest(int senderID, int receiverID)
        {
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "DateRequest";

            objCommand.Parameters.AddWithValue("@SenderID", senderID);
            objCommand.Parameters.AddWithValue("@ReceiverID", receiverID);

            DBConnect objDB = new DBConnect();
            int rowsAffected = objDB.DoUpdateUsingCmdObj(objCommand);
            return (rowsAffected > 0);
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

        public bool LogProfileView(int viewerID, int viewedBirdID)
        {
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "LogProfileView";

            objCommand.Parameters.AddWithValue("@ViewerID", viewerID);
            objCommand.Parameters.AddWithValue("@ViewedID", viewedBirdID);

            DBConnect objDB = new DBConnect();
            int rowsAffected = objDB.DoUpdateUsingCmdObj(objCommand);
            return (rowsAffected > 0);
        }

        public int GetProfileViewCount(int birdID)
        {
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "GetProfileViewCount";

            objCommand.Parameters.AddWithValue("@BirdID", birdID);

            DBConnect objDB = new DBConnect();
            DataSet myDataSet = objDB.GetDataSetUsingCmdObj(objCommand);

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

            DBConnect objDB = new DBConnect();
            DataSet myDataSet = objDB.GetDataSetUsingCmdObj(objCommand);
            return myDataSet;
        }

        public DataSet SearchByAgeRange(string ageRange)
        {
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "SearchByAgeRange";

            objCommand.Parameters.AddWithValue("@AgeRange", ageRange);

            DBConnect objDB = new DBConnect();
            DataSet myDataSet = objDB.GetDataSetUsingCmdObj(objCommand);
            return myDataSet;
        }

        public DataSet SearchByCommitment(string commitmentType)
        {
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "SearchByCommitmentType";

            objCommand.Parameters.AddWithValue("@CommitmentType", commitmentType);

            DBConnect objDB = new DBConnect();
            DataSet myDataSet = objDB.GetDataSetUsingCmdObj(objCommand);
            return myDataSet;
        }





    }
}
