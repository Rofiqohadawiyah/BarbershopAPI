using Npgsql;

namespace BarbershopAPI.Helpers
{
    public class DBHelper
    {
        private NpgsqlConnection conn;

        public DBHelper(string connStr)
        {
            conn = new NpgsqlConnection(connStr);
            conn.Open();
        }

        public NpgsqlCommand GetCommand(string query)
        {
            return new NpgsqlCommand(query, conn);
        }

        public void Close()
        {
            conn.Close();
        }
    }
}