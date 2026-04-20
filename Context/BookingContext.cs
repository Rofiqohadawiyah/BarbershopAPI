using Npgsql;

namespace BarbershopAPI.Context
{
    public class BookingContext
    {
        private string _connStr;

        public BookingContext(string connStr)
        {
            _connStr = connStr;
        }

        public bool UserExists(int id)
        {
            using var conn = new NpgsqlConnection(_connStr);
            conn.Open();

            var cmd = new NpgsqlCommand("SELECT COUNT(*) FROM users WHERE id_user=@id", conn);
            cmd.Parameters.AddWithValue("@id", id);
            return (long)cmd.ExecuteScalar() > 0;
        }

        public bool BarberExists(int id)
        {
            using var conn = new NpgsqlConnection(_connStr);
            conn.Open();

            var cmd = new NpgsqlCommand("SELECT COUNT(*) FROM barbers WHERE id_barber=@id", conn);
            cmd.Parameters.AddWithValue("@id", id);
            return (long)cmd.ExecuteScalar() > 0;
        }

        public List<object> GetAll()
        {
            var list = new List<object>();
            using var conn = new NpgsqlConnection(_connStr);
            conn.Open();

            string query = @"SELECT 
                                bk.id_booking,
                                u.nama,
                                b.nama,
                                bk.tanggal,
                                bk.jam
                             FROM bookings bk
                             JOIN users u ON bk.user_id=u.id_user
                             JOIN barbers b ON bk.barber_id=b.id_barber";

            var cmd = new NpgsqlCommand(query, conn);
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                list.Add(new
                {
                    id_booking = reader.GetInt32(0),
                    nama_user = reader.GetString(1),
                    nama_barber = reader.GetString(2),
                    tanggal = reader.GetDateTime(3),
                    jam = reader.GetTimeSpan(4)
                });
            }
            return list;
        }

        public void Insert(int u, int b, DateTime t, TimeSpan j)
        {
            using var conn = new NpgsqlConnection(_connStr);
            conn.Open();

            string query = "INSERT INTO bookings (user_id,barber_id,tanggal,jam) VALUES (@u,@b,@t,@j)";
            var cmd = new NpgsqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@u", u);
            cmd.Parameters.AddWithValue("@b", b);
            cmd.Parameters.AddWithValue("@t", t);
            cmd.Parameters.AddWithValue("@j", j);
            cmd.ExecuteNonQuery();
        }
    }
}