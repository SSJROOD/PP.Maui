using MySql.Data.MySqlClient;
using PP.Library.DTO;
using PP.Library.Models;
using PP.Library.Services;
using System.Data.Common;
using System.Windows.Input;

namespace PP.API.Database
{
    public class ClientDatabase
    {

        private static ClientDatabase? instance;
        private static object _lock = new object();

        public static ClientDatabase Current
        {
            get
            {
                lock (_lock)
                {
                    if (instance == null)
                    {
                        instance = new ClientDatabase();
                    }
                }
                return instance;
            }
        }
        private static string server = "localhost";
        private static string database = "PP_DB";
        private static string username = "root";
        private static string password = "355341";
        private static string? myconnection;

        private ClientDatabase()
        {
            myconnection = $"Server={server};Database={database};Uid={username};Pwd={password}";
        }
        public Client GetClient(int id)
        {
            var client = new Client();
            using (var connection = new MySqlConnection(myconnection))
            {
                connection.Open();

                var getQuery = $"SELECT * FROM clients WHERE Id = {id}";
                using (var command = new MySqlCommand(getQuery, connection))
                {

                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        client = new Client
                        {
                            Id = (int)reader["Id"],
                            Name = reader["Name"].ToString(),
                            OpenDate = (DateTime)reader["OpenDate"],
                            IsActive = (Boolean)reader["IsActive"]
                        };

                        return client;
                    }

                }
            }

            return client;
        }


        public Client AddOrUpdate(Client client)
        {
            using (var connection = new MySqlConnection(myconnection))
            {
                connection.Open();
                if (client.Id > 0)
                {
                    var updateQuery = "UPDATE clients SET Name = @Name, OpenDate = @OpenDate, IsActive = @IsActive WHERE Id = @Id";
                    using (var command = new MySqlCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Id", client.Id);
                        command.Parameters.AddWithValue("@Name", client.Name);
                        command.Parameters.AddWithValue("@OpenDate", client.OpenDate);
                        command.Parameters.AddWithValue("@IsActive", client.IsActive);
                        command.ExecuteNonQuery();
                    }
                }
                else
                {
                    var insertQuery = "INSERT INTO clients (Name, OpenDate, IsActive) VALUES (@Name, @OpenDate, @IsActive)";
                    using (var command = new MySqlCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Name", client.Name);
                        command.Parameters.AddWithValue("@OpenDate", client.OpenDate);
                        command.Parameters.AddWithValue("@IsActive", client.IsActive);
                        command.ExecuteNonQuery();
                        client.Id = (int)command.LastInsertedId;
                    }
                }
            }
            return client;
        }


        public IEnumerable<Client> Search(string query = "")
        {
            var results = new List<Client>();
            using (var connection = new MySqlConnection(myconnection))
            {
                connection.Open();

                var searchQuery = $"SELECT * FROM clients WHERE Name LIKE {query} LIMIT 100";
                using (var command = new MySqlCommand(searchQuery, connection))
                {

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var client = new Client
                            {
                                Id = (int)reader["Id"],
                                Name = reader["Name"].ToString(),
                                OpenDate = (DateTime)reader["OpenDate"],
                                IsActive = (bool)reader["IsActive"]
                            };

                            results.Add(client);
                        }
                    }
                }
            }

            return results;
        }


        public List<Client> Get()
        {
            var results = new List<Client>();
            using (var conn = new MySqlConnection(myconnection))
            {
                var sql = "select* FROM clients";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    conn.Open();
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        results.Add(new Client
                        {
                            Id = (int)reader[0],
                            Name = reader[1]?.ToString() ?? string.Empty,
                            OpenDate = (DateTime)reader[2],
                            IsActive = (Boolean)reader[3]
                        });
                    }
                }
            }

            return results;
        }

        public Client Delete(int id)
        {
            var client = GetClient(id);
            if (client != null)
            {
                using (var connection = new MySqlConnection(myconnection))
                {
                    connection.Open();

                    var deleteQuery = $"DELETE FROM clients WHERE Id = {id}";
                    using (var command = new MySqlCommand(deleteQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
                return client;
            }

            return client ?? new Client();
        }
    }
}
