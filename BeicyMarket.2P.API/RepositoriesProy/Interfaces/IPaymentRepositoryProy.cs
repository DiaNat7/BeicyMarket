namespace BeicyMarket._2P.API.RepositoriesProy.Interfaces;

public interface IPaymentRepositoryProy
{
   
        // Método para CREAR o GUARDAR un pago nuevo
        Task<PaymentProy> SaveAsync(PaymentProy payment);

        // Método para ACTUALIZAR un pago que ya existe
        Task<PaymentProy> UpdateAsync(PaymentProy payment);

        // Método para ver TODOS los pagos guardados
        Task<List<PaymentProy>> GetAllAsync();

        // Método para BORRAR un pago usando su número de Id
        Task<bool> DeleteAsync(int id);

        // Método para BUSCAR UN SOLO pago usando su número de Id
        Task<PaymentProy> GetById(int id);
    
}