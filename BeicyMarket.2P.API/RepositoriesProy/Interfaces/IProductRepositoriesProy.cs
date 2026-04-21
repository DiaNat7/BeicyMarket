using BeicyMarket._2P.CORE.EntitiesProy;

namespace BeicyMarket._2P.API.RepositoriesProy.Interfaces;

public interface IProductRepositoriesProy
{
    //metodo para guardar el producto
    Task<ProductProy> SaveAsync(ProductProy product);
    
    //metodo para actualizar el producto
    Task<ProductProy> UpdateAsync(ProductProy product);
    
    //metodo para retornar una lista de productos
    Task<List<ProductProy>> GetAllAsync();
    
    //metodo para retornar el id del producto que se borrara
    Task<bool> DeleteAsync(int id);
    
    //metodo para obtener un producto por id
    Task<ProductProy> GetById(int id);
  
}