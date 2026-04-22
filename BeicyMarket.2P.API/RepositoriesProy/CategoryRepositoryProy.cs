using Dapper;
using Dapper.Contrib.Extensions;
using BeicyMarket._2P.API.DataAccessProy;
using BeicyMarket._2P.API.RepositoriesProy.Interfaces;
using BeicyMarket._2P.CORE.EntitiesProy;

namespace BeicyMarket._2P.API.RepositoriesProy;

public class CategoryRepositoryProy : ICategoryRepositoryProy
{
    private readonly DbContextProy _context;

    public CategoryRepositoryProy(DbContextProy context)
    {
        _context = context;
    }

    // CREAR
    public async Task<CategoryProy> SaveAsync(CategoryProy category)
    {
        using var connection = _context.Connection;

        category.CreatedDate = DateTime.UtcNow;
        category.IsDeleted = false;

        var id = await connection.InsertAsync(category);
        category.Id = (int)id;

        return category;
    }

    // ACTUALIZAR
    public async Task<CategoryProy> UpdateAsync(CategoryProy category)
    {
        using var connection = _context.Connection;

        category.UpdatedDate = DateTime.UtcNow;

        await connection.UpdateAsync(category);

        return category;
    }

    // OBTENER TODOS
    public async Task<List<CategoryProy>> GetAllAsync()
    {
        using var connection = _context.Connection;

        var query = "SELECT * FROM CategoryProy WHERE IsDeleted = 0";
        var result = await connection.QueryAsync<CategoryProy>(query);

        return result.ToList();
    }

    // ELIMINAR (lógico)
    public async Task<bool> DeleteAsync(int id)
    {
        using var connection = _context.Connection;

        var query = @"UPDATE CategoryProy 
                      SET IsDeleted = 1, UpdatedDate = @UpdatedDate 
                      WHERE Id = @Id";

        var rows = await connection.ExecuteAsync(query, new
        {
            Id = id,
            UpdatedDate = DateTime.UtcNow
        });

        return rows > 0;
    }

    // OBTENER POR ID
    public async Task<CategoryProy> GetById(int id)
    {
        using var connection = _context.Connection;

        var query = "SELECT * FROM CategoryProy WHERE Id = @Id AND IsDeleted = 0";

        return await connection.QueryFirstOrDefaultAsync<CategoryProy>(query, new { Id = id });
    }
}