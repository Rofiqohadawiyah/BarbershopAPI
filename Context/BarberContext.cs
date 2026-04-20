using Npgsql;
using BarbershopAPI.Models;

namespace BarbershopAPI.Context
{
    public class BarberContext
    {
        private string _connStr;

        public BarberContext(string connStr)
        {
            _connStr = connStr;
        }

        public List<Barber> GetAll()
        {
            var list = new List<Barber>();
            using var conn = new NpgsqlConnection(_connStr);
            conn.Open();

            var cmd = new NpgsqlCommand("SELECT * FROM barbers", conn);
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                list.Add(new Barber
                {
                    id_barber = reader.GetInt32(0),
                    nama = reader.GetString(1),
                    spesialis = reader.GetString(2)
                });
            }

            return list;
        }
    }
}