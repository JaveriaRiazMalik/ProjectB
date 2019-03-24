using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ProjectB
{
    class DataConnection
    {

        private static DataConnection instance;
        public string connectionstring;
        private SqlConnection connection;

        DataConnection()
        {

        }

        /// <summary>
        /// creates a data connection instance
        /// </summary>
        /// <returns>data connection </returns>
        public static DataConnection get_instance()
        {
            if (instance == null)
            {
                instance = new DataConnection();
            }
            return instance;
        }

        /// <summary>
        /// sets up data connection
        /// </summary>
        /// <returns>connection</returns>
        public SqlConnection Getconnection()
        {
            connection = new SqlConnection(connectionstring);
            if (connection.State != System.Data.ConnectionState.Open)
            {
                connection.Open();
            }
            return connection;
        }

        /// <summary>
        /// Closes the connection
        /// </summary>
        public void close()
        {
            if (connection != null)
            {
                connection.Close();
            }
        }

        /// <summary>
        /// reads the data
        /// </summary>
        /// <param name="query"></param>
        /// <returns>complete table</returns>
        public SqlDataReader Getdata(string query)
        {
            connection = Getconnection();
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataReader data = cmd.ExecuteReader();
            return data;

        }

        /// <summary>
        /// executes the query
        /// </summary>
        /// <param name="query"></param>
        /// <returns>gives the row after applying query </returns>
        public int Executequery(string query)
        {
            connection = Getconnection();
            SqlCommand cmd = new SqlCommand(query, connection);
            int row = cmd.ExecuteNonQuery();
            return row;
        }
        
        /// <summary>
        /// closes the connection
        /// </summary>
        public void Closeconnection()
        {
            if (connection != null)
            {
                connection.Close();
            }
        }
    }
}
