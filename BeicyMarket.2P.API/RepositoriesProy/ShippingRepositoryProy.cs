using BeicyMarket._2P.CORE.EntitiesProy;

namespace BeicyMarket._2P.API.RepositoriesProy.Interfaces;

public class ShippingRepositoryProy:IShippingRepositoryProy
{
    
        public Task<ShippingProy> SaveAsync(ShippingProy shipping)
        {
            throw new NotImplementedException();
        }

        public Task<ShippingProy> UpdateAsync(ShippingProy shipping)
        {
            throw new NotImplementedException();
        }

        public Task<List<ShippingProy>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ShippingProy> GetById(int id)
        {
            throw new NotImplementedException();
        }
    
}