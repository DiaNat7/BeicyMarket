using BeicyMarket._2P.API.RepositoriesProy.Interfaces;
using BeicyMarket._2P.CORE.EntitiesProy;

namespace BeicyMarket._2P.API.RepositoriesProy;

public class PaymentRepositoryProy: IPaymentRepositoryProy
{
   
        public Task<PaymentProy> SaveAsync(PaymentProy payment)
        {
            throw new NotImplementedException();
        }

        public Task<PaymentProy> UpdateAsync(PaymentProy payment)
        {
            throw new NotImplementedException();
        }

        public Task<List<PaymentProy>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<PaymentProy> GetById(int id)
        {
            throw new NotImplementedException();
        }
    
}