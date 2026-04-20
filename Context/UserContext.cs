using Npgsql;
using BarbershopAPI.Models;

namespace BarbershopAPI.Context
{
    public class UserContext
    {
        private string _connStr;

        public UserContext(string connStr)
        {
            _connStr = connStr;
        }

        public List<User> GetAll()
        {
            var list = new List<User>();
            using var conn = new NpgsqlConnection(_connStr);
            conn.Open();

            var cmd = new NpgsqlCommand("SELECT * FROM users WHERE deleted_at IS NULL", conn);
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                list.Add(new User
                {
                    id_user = reader.GetInt32(0),
                    nama = reader.GetString(1),
                    email = reader.GetString(2),
                    password = reader.GetString(3)
                });
            }

            return list;
        }

        public User GetById(int id)
        {
            using var conn = new NpgsqlConnection(_connStr);
            conn.Open();

            var cmd = new NpgsqlCommand("SELECT * FROM users WHERE id_user=@id AND deleted_at IS NULL", conn);
            cmd.Parameters.AddWithValue("@id", id);

            var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return new User
                {
                    id_user = reader.GetInt32(0),
                    nama = reader.GetString(1),
                    email = reader.GetString(2),
                    password = reader.GetString(3)
                };
            }

            return null;
        }

        public bool EmailExists(string email)
        {
            using var conn = new NpgsqlConnection(_connStr);
            conn.Open();

            var cmd = new NpgsqlCommand("SELECT COUNT(*) FROM users WHERE email=@e", conn);
            cmd.Parameters.AddWithValue("@e", email);

            return (long)cmd.ExecuteScalar() > 0;
        }

        public void Insert(User user)
        {
            using var conn = new NpgsqlConnection(_connStr);
            conn.Open();

            var cmd = new NpgsqlCommand(
                "INSERT INTO users (nama,email,password) VALUES (@n,@e,@p)", conn);

            cmd.Parameters.AddWithValue("@n", user.nama);
            cmd.Parameters.AddWithValue("@e", user.email);
            cmd.Parameters.AddWithValue("@p", user.password);

            cmd.ExecuteNonQuery();
        }

        public bool Update(int id, User user)
        {
            using var conn = new NpgsqlConnection(_connStr);
            conn.Open();

            var cmd = new NpgsqlCommand(
                "UPDATE users SET nama=@n,email=@e,password=@p,updated_at=NOW() WHERE id_user=@id",
                conn);

            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@n", user.nama);
            cmd.Parameters.AddWithValue("@e", user.email);
            cmd.Parameters.AddWithValue("@p", user.password);

            return cmd.ExecuteNonQuery() > 0;
        }

        public bool Delete(int id)
        {
            using var conn = new NpgsqlConnection(_connStr);
            conn.Open();

            var cmd = new NpgsqlCommand(
                "UPDATE users SET deleted_at=NOW() WHERE id_user=@id AND deleted_at IS NULL",
                conn);

            cmd.Parameters.AddWithValue("@id", id);

            return cmd.ExecuteNonQuery() > 0;
        }
    }
}