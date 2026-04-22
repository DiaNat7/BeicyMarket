using BeicyMarket._2P.API.RepositoriesProy.Interfaces;
using BeicyMarket._2P.CORE.EntitiesProy;

namespace BeicyMarket._2P.API.RepositoriesProy;

public class SaleRepositoryProy: ISaleRepositoryProy
{
    
        // Método para CREAR o GUARDAR una venta nueva
        public Task<SaleProy> SaveAsync(SaleProy sale)
        {
            throw new NotImplementedException();
        }

        // Método para ACTUALIZAR una venta que ya existe
        public Task<SaleProy> UpdateAsync(SaleProy sale)
        {
            throw new NotImplementedException();
        }

        // Método para ver TODAS las ventas que tienes guardadas
        public Task<List<SaleProy>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        // Método para BORRAR una venta usando su número de Id
        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        // Método para BUSCAR UNA SOLA venta usando su número de Id
        public Task<SaleProy> GetById(int id)
        {
            throw new NotImplementedException();
        }
    
}