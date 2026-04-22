
using BeicyMarket._2P.CORE.EntitiesProy;

namespace BeicyMarket._2P.API.RepositoriesProy.Interfaces;
    public interface ISaleDetailRepositoryProy
    {
        //metodo para guardar el detalle de venta
        Task<SaleDetailProy> SaveAsync(SaleDetailProy saleDetail);
    
        //metodo para actualizar el detalle de venta
        Task<SaleDetailProy> UpdateAsync(SaleDetailProy saleDetail);
    
        //metodo para retornar una lista de detalles de venta
        Task<List<SaleDetailProy>> GetAllAsync();
    
        //metodo para retornar el id del detalle de venta que se borrara
        Task<bool> DeleteAsync(int id);
    
        //metodo para obtener un detalle de venta por id
        Task<SaleDetailProy> GetById(int id);
    }
