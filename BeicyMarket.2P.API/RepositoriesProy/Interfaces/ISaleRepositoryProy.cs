


    public interface ISaleRepositoryProy
    {
        //metodo para guardar la venta
        Task<SaleProy> SaveAsync(SaleProy sale);
        
        //metodo para actualizar la venta
        Task<SaleProy> UpdateAsync(SaleProy sale);
        
        //metodo para retornar una lista de ventas
        Task<List<SaleProy>> GetAllAsync();
        
        //metodo para retornar el id de la venta que se borrara
        Task<bool> DeleteAsync(int id);
        
        //metodo para obtener una venta por id
        Task<SaleProy> GetById(int id);
    }