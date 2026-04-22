public interface ISupplierRepositoryProy
{
    // Método para CREAR o GUARDAR un proveedor nuevo
    Task<SupplierProy> SaveAsync(SupplierProy supplier);

    // Método para ACTUALIZAR un proveedor que ya existe
    Task<SupplierProy> UpdateAsync(SupplierProy supplier);

    // Método para ver TODOS los proveedores guardados
    Task<List<SupplierProy>> GetAllAsync();

    // Método para BORRAR un proveedor usando su número de Id
    Task<bool> DeleteAsync(int id);

    // Método para BUSCAR UN SOLO proveedor usando su número de Id
    Task<SupplierProy> GetById(int id);