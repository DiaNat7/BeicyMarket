using System.Data.Common;

namespace BeicyMarket._2P.API.DataAccessProy.Interfaces;

public interface IDbContextProy
{
    DbConnection Connection { get; }
}