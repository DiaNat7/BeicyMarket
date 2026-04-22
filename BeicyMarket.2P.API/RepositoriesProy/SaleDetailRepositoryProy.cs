using BeicyMarket._2P.API.RepositoriesProy.Interfaces;
using BeicyMarket._2P.CORE.EntitiesProy;

namespace BeicyMarket._2P.API.RepositoriesProy;

public class SaleDetailRepositoryProy: ISaleDetailRepositoryProy
{
    
        // Método para CREAR o GUARDAR un detalle de venta nuevo
        public Task<SaleDetailProy> SaveAsync(SaleDetailProy saleDetail)
        {
            throw new NotImplementedException();
        }

        // Método para ACTUALIZAR un detalle de venta que ya existe
        public Task<SaleDetailProy> UpdateAsync(SaleDetailProy saleDetail)
        {
            throw new NotImplementedException();
        }

        // Método para ver TODOS los detalles de venta que tienes guardados
        public Task<List<SaleDetailProy>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        // Método para BORRAR un detalle de venta usando su número de Id
        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        // Método para BUSCAR UN SOLO detalle de venta usando su número de Id
        public Task<SaleDetailProy> GetById(int id)
        {
            throw new NotImplementedException();
        }
    
}