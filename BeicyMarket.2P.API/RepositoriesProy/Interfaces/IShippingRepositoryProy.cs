namespace BeicyMarket._2P.API.RepositoriesProy.Interfaces;

public interface IShippingRepositoryProy
{
    // Método para CREAR o GUARDAR un envío nuevo
    Task<ShippingProy> SaveAsync(ShippingProy shipping);

    // Método para ACTUALIZAR un envío que ya existe
    Task<ShippingProy> UpdateAsync(ShippingProy shipping);

    // Método para ver TODOS los envíos guardados
    Task<List<ShippingProy>> GetAllAsync();

    // Método para BORRAR un envío usando su número de Id
    Task<bool> DeleteAsync(int id);

    // Método para BUSCAR UN SOLO envío usando su número de Id
    Task<ShippingProy> GetById(int id);
}