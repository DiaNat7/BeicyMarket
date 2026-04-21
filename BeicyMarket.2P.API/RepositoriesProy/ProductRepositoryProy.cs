using BeicyMarket._2P.API.RepositoriesProy.Interfaces;
using BeicyMarket._2P.CORE.EntitiesProy;

namespace BeicyMarket._2P.API.RepositoriesProy;

public class ProductRepositoryProy : IProductRepositoriesProy
{
    // Método para CREAR o GUARDAR un producto nuevo
    public Task<ProductProy> SaveAsync(ProductProy product)
    {
        throw new NotImplementedException();
    }

    // Método para ACTUALIZAR un producto que ya existe
    public Task<ProductProy> UpdateAsync(ProductProy product)
    {
        throw new NotImplementedException();
    }

    // Método para ver TODOS los productos que tienes guardados
    public Task<List<ProductProy>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    // Método para BORRAR un producto usando su número de Id
    public Task<bool> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    // Método para BUSCAR UN SOLO producto usando su número de Id
    public Task<ProductProy> GetById(int id)
    {
        throw new NotImplementedException();
    }
}