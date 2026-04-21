using System.Data.Common;
using BeicyMarket._2P.API.DataAccessProy.Interfaces;
using MySqlConnector;

namespace BeicyMarket._2P.API.DataAccessProy;

public class DbContextProy : IDbContextProy
{
    private readonly string _connectionString = 
        "Server=127.0.0.1;User=root;Database=BeicyMarket;Port=3306;Pwd=1234;";
    
    private MySqlConnection _connection;

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