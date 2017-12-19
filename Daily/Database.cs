using System;
using System.Data.SqlClient;
using Con

namespace GetYearToDate
{
    public class Database
    {
        private string connStr = string.Empty;

        public Database()
        {
            connStr = Config.GetDbConfig();
        }

        public bool InsertDailyPrice(string stockSymbol, DateTime date, decimal price)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;
            string curFile = string.Empty;

            try
            {
                conn = new SqlConnection(connStr);
                cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = Constants.INSERT_DAILY_PRICE;
                cmd.CommandType = System.Data.CommandType.Text;

                cmd.Parameters.Add(new SqlParameter("@StockSymbol", stockSymbol));
                cmd.Parameters.Add(new SqlParameter("@price", price));
                cmd.Parameters.Add(new SqlParameter("@date", date));

                conn.Open();

                cmd.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseDbObjects(conn, cmd, null);
            }
        }

        private void CloseDbObjects(SqlConnection conn, SqlCommand cmd, SqlDataReader rdr)
        {
            if (conn != null)
            {
                conn.Close();
                conn.Dispose();
                conn = null;
            }

            if (cmd != null)
            {
                cmd.Dispose();
                cmd = null;
            }

            if (rdr != null)
            {
                rdr.Close();
                rdr.Dispose();
                rdr = null;
            }
        }
    }
}
