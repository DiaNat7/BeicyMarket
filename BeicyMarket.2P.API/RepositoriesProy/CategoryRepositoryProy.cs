using BeicyMarket._2P.API.DataAccessProy;
using BeicyMarket._2P.CORE.EntitiesProy;
using Dapper.Contrib.Extensions;

namespace BeicyMarket._2P.API.RepositoriesProy;

public class CategoryRepositoryProy
{
    private readonly DbContextProy _dbContext;

    public CategoryRepositoryProy(DbContextProy dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<CategoryProy> SaveAsync(CategoryProy category)
    {
        var id = await _dbContext.Connection.InsertAsync(category); 
        category.Id = (int)id; 
        
        return category;
    }

    public async Task<CategoryProy> UpdateAsync(CategoryProy category)
    {
        await _dbContext.Connection.UpdateAsync(category); 
        return category;
    }

    public async Task<List<CategoryProy>> GetAllAsync()
    {
        var categories = await _dbContext.Connection.GetAllAsync<CategoryProy>(); 
        return categories.ToList();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var category = await _dbContext.Connection.GetAsync<CategoryProy>(id);
        if (category == null) 
            return false; 
        
        return await _dbContext.Connection.DeleteAsync(category);
    }

    public async Task<CategoryProy> GetById(int id)
    {
        return await _dbContext.Connection.GetAsync<CategoryProy>(id); 
    }  
}