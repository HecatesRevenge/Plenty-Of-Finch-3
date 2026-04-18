using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace ProfileAPI.DataAccess
{
    public class DBConnect
    {
        // Main Connection String - used for the published web application and project submissions.
        String SqlConnectString = "server=cis-mssql1.temple.edu;Database=sp26_3342_tus45674;User id=tus45674;Password=zaaf9Cae4x; TrustServerCertificate=true";

        // Home Connection String - used for working from home using SSH Tunneling.
        //String SqlConnectString = "server=127.0.0.1,5555;Database=sp26_3342_tus45674;User id=tus45674;Password=zaaf9Cae4x; TrustServerCertificate=true";

        SqlConnection myConnectionSql;
        SqlCommand objCmd;
        DataSet ds;

        public DBConnect()
        {
            myConnectionSql = new SqlConnection(SqlConnectString);
        }

        public DataSet GetDataSet(String SqlSelect)
        {
            SqlDataAdapter myDataAdapter = new SqlDataAdapter(SqlSelect, myConnectionSql);
            DataSet myDataSet = new DataSet();
            myDataAdapter.Fill(myDataSet);
            ds = myDataSet;
            return myDataSet;
        }

        public DataSet GetDataSetUsingCmdObj(SqlCommand theCommand)
        {
            theCommand.Connection = myConnectionSql;
            SqlDataAdapter myDataAdapter = new SqlDataAdapter(theCommand);
            DataSet myDataSet = new DataSet();
            myDataAdapter.Fill(myDataSet);
            ds = myDataSet;
            return myDataSet;
        }

        public int DoUpdate(String SqlManipulate)
        {
            objCmd = new SqlCommand(SqlManipulate, myConnectionSql);
            try
            {
                myConnectionSql.Open();
                int ret = objCmd.ExecuteNonQuery();
                myConnectionSql.Close();
                return ret;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public int DoUpdateUsingCmdObj(SqlCommand theCommandObject)
        {
            try
            {
                theCommandObject.Connection = myConnectionSql;
                theCommandObject.Connection.Open();
                int ret = theCommandObject.ExecuteNonQuery();
                theCommandObject.Connection.Close();
                return ret;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public void CloseConnection()
        {
            try
            {
                myConnectionSql.Close();
            }
            catch (Exception ex)
            {
                // Catch exception created when trying to close a closed connection.
            }
        }

        ~DBConnect()
        {
            try
            {
                myConnectionSql.Close();
            }
            catch (Exception ex)
            {
                // Catch exception created when trying to close a closed connection.
            }
        }
    }
}
