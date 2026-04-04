using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace DatingSite.DBConnection
{
    public class AuthDataBaseConnection
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
            else
            {
                return -1;
            }
        }
    }

}





