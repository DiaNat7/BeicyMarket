using BeicyMarket._2P.CORE.EntitiesProy;

namespace BeicyMarket._2P.API.RepositoriesProy.Interfaces;

public interface IUserRepositoriesProy
{
    //metodo para guardar el usuario
    Task<UserProy> SaveAsync(UserProy user);
    
    //metodo para actualizar el usuario
    Task<UserProy> UpdateAsync(UserProy user);
    
    //metodo para retornar una lista de usuarios
    Task<List<UserProy>> GetAllAsync();
    
    //metodo para retornar el id del usuario que se borrara
    Task<bool> DeleteAsync(int id);
    
    //metodo para obtener un usuario por id
    Task<UserProy> GetById(int id);

    //metodo para validar el login (Correo y Clave)
    Task<UserProy?> GetByEmailAndPasswordAsync(string email, string password);

}