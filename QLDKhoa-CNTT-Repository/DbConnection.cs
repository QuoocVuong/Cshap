using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using System.IO;
using System.Data;

namespace QLDKhoa_CNTT.DAL
{
    public class DbConnection
    {
        private string _connectionString; // Không còn là static

        public DbConnection() // Constructor không static
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            IConfiguration configuration = builder.Build();

            _connectionString = configuration.GetConnectionString("QuanLyDiemKhoaCNTT");
        }

        public string GetConnectionString() // Không còn là static
        {
            return _connectionString;
        }

        public SqlConnection GetSqlConnection() // Không còn là static
        {
            return new SqlConnection(_connectionString);
        }
        public DataTable load(string query)
        {
            using (SqlConnection connection = GetSqlConnection())
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);
                            return dataTable;
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Error loading data: " + ex.Message);

                    return null;
                }
            }
        }
    }
}