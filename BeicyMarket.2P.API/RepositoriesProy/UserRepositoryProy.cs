using BeicyMarket._2P.API.DataAccessProy;
using BeicyMarket._2P.API.RepositoriesProy.Interfaces;
using BeicyMarket._2P.CORE.EntitiesProy;
using Dapper.Contrib.Extensions;
using Dapper;

namespace BeicyMarket._2P.API.RepositoriesProy;

public class UserRepositoryProy :  IUserRepositoriesProy
{
    private readonly DbContextProy _dbContext;

    public UserRepositoryProy(DbContextProy dbContext)
    {
        _dbContext = dbContext;
    }

    // Al reemplazar el NotImplementedException por esto, se arregla el Error 500
    public async Task<UserProy> SaveAsync(UserProy user)
    {
        var id = await _dbContext.Connection.InsertAsync(user);
        user.Id = (int)id;
        return user;
    }

    public async Task<UserProy> UpdateAsync(UserProy user)
    {
        await _dbContext.Connection.UpdateAsync(user);
        return user;
    }

    public async Task<List<UserProy>> GetAllAsync()
    {
        var users = await _dbContext.Connection.GetAllAsync<UserProy>();
        return users.ToList();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var user = await _dbContext.Connection.GetAsync<UserProy>(id);
        if (user == null) return false;
        
        return await _dbContext.Connection.DeleteAsync(user);
    }

    public async Task<UserProy> GetById(int id)
    {
        return await _dbContext.Connection.GetAsync<UserProy>(id);
    }

    
    public async Task<UserProy> GetByEmailAndPasswordAsync(string email, string password)
    {
        // Escribimos la consulta de SQL directa a tu tabla
        var query = "SELECT * FROM UserProy WHERE Email = @Email AND Password = @Password AND IsDeleted = 0";
        
        // Dapper busca al usuario y lo devuelve
        return await _dbContext.Connection.QueryFirstOrDefaultAsync<UserProy>(query, new { Email = email, Password = password });
    }  
}