using System.Data.Common;
using BeicyMarket._2P.API.DataAccessProy.Interfaces;
using MySqlConnector;

namespace BeicyMarket._2P.API.DataAccessProy;

public class DbContextProy : IDbContextProy
{
    private readonly string _connectionString;
    private MySqlConnection _connection;

    // Constructor que recibe la cadena de conexión
    public DbContextProy(string connectionString)
    {
        _connectionString = connectionString;
    }

    public DbConnection Connection
    {
        get
        {
            if (_connection == null)
            {
                _connection = new MySqlConnection(_connectionString);
            }
            return _connection;
        }
    }
}