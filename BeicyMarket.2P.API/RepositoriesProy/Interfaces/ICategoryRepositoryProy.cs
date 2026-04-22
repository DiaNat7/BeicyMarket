using BeicyMarket._2P.CORE.EntitiesProy;

namespace BeicyMarket._2P.API.RepositoriesProy.Interfaces;

public interface ICategoryRepositoryProy
{
    //metodo para guardar la categoria
    Task<CategoryProy> SaveAsync(CategoryProy category);
    
    //metodo para actualizar la categoria
    Task<CategoryProy> UpdateAsync(CategoryProy category);
    
    //metodo para retornar una lista de categorias
    Task<List<CategoryProy>> GetAllAsync();
    
    //metodo para retornar el id de la categoria que se borrara
    Task<bool> DeleteAsync(int id);
    
    //metodo para obtener una categoria por id
    Task<CategoryProy> GetById(int id); 

}