using Npgsql;

namespace PermissionDB.Connectors
{
    public interface IDatabaseConnector
    {
        
    }
    
    public class DatabaseConnector : IDatabaseConnector
    {
        private static NpgsqlConnection _connection;

        public static void Initialize(NpgsqlConnection connection)
        {
            _connection = connection;
            CreateTablesIfNotExists();
        }

        private static void CreateTablesIfNotExists()
        {
            var command = new NpgsqlCommand("");
        }
    }
}