
using System.Data;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;


namespace apiTesting
{
    public class Databasestuff
    {
            public int checkLogin(string username, string password)
            {
                string connectionString = "server=127.0.0.1,5555; Database=sp26_3342_tup20353; User id = tup20353; Password = Hebee9jeed; Encrypt=True;TrustServerCertificate=True;";
                SqlConnection conn;
                conn = new SqlConnection(connectionString);
                SqlCommand objcommand = new SqlCommand();
                conn.Open();
                objcommand.Connection = conn;
                objcommand.CommandType = CommandType.StoredProcedure;
                objcommand.CommandText = "checkLogin";
                SqlParameter inputParameter = new SqlParameter("@username", username);
                objcommand.Parameters.Add(inputParameter);
            inputParameter = new SqlParameter("@password", password);
            objcommand.Parameters.Add(inputParameter);
            var result = objcommand.ExecuteScalar();

            if (result != null)
            {
                conn.Close();
                return 1;
            }
            else
            {
                conn.Close();
                return 0;
            }

        }
        
    }
}
