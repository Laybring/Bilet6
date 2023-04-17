using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ekzam_6
{
    public class Connecting
    {

        private static string Connections = @"Data Source=LAYBRING\MSSQLSERVER02; Initial Catalog=ExamUsers;Integrated Security=True";
        private SqlConnection connection = new SqlConnection(Connections);

        public void Open() 
        {

            if (connection.State == System.Data.ConnectionState.Closed)
            {

                connection.Open();

            }
        
        }

        public void Close() 
        {

            if (connection.State == System.Data.ConnectionState.Open)
            {

                connection.Close();

            }
        
        }

        public SqlConnection GetConnection() 
        {
        
        return connection;
        
        }

    }
}
