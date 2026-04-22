using BeicyMarket._2P.API.RepositoriesProy.Interfaces;
using BeicyMarket._2P.CORE.EntitiesProy;

namespace BeicyMarket._2P.API.RepositoriesProy;

public class SupplierRepositoryProy: ISupplierRepositoryProy
{
    
        public Task<SupplierProy> SaveAsync(SupplierProy supplier)
        {
            throw new NotImplementedException();
        }

        public Task<SupplierProy> UpdateAsync(SupplierProy supplier)
        {
            throw new NotImplementedException();
        }

        public Task<List<SupplierProy>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<SupplierProy> GetById(int id)
        {
            throw new NotImplementedException();
        }
    
}