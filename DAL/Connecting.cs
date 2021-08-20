using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAL
{
    public class Connecting
    {
        SqlConnection GetConnection()
        {
            String connString = @"Data Source=DESKTOP-G5KUE39;Initial Catalog=QLCuaHangTapHoa;Integrated Security=True";
            try
            {
                SqlConnection conn = new SqlConnection(connString);
                return conn;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public DataTable GetTable(String sqlQuery)
        {
            SqlConnection conn = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter(sqlQuery, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public void ExecNonQuery(String sqlQuery)
        {
            SqlConnection conn = GetConnection();
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                SqlCommand cmd = new SqlCommand(sqlQuery, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public SqlDataReader DataReader(String sqlQuery)
        {
            SqlConnection conn = GetConnection();
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                SqlCommand cmd = new SqlCommand(sqlQuery, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                return reader;
                conn.Close();
            }
            catch (SqlException ex)
            {
                return null;
                MessageBox.Show(ex.Message);
            }
        }

       
    }
}
