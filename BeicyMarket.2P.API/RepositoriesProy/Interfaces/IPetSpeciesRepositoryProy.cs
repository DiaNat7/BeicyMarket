using BeicyMarket._2P.CORE.EntitiesProy;

namespace BeicyMarket._2P.API.RepositoriesProy.Interfaces;

public interface IPetSpeciesRepositoryProy
{
    // Método para CREAR o GUARDAR una especie nueva
    Task<PetSpeciesProy> SaveAsync(PetSpeciesProy petSpecies);

    // Método para ACTUALIZAR una especie que ya existe
    Task<PetSpeciesProy> UpdateAsync(PetSpeciesProy petSpecies);

    // Método para ver TODAS las especies guardadas
    Task<List<PetSpeciesProy>> GetAllAsync();

    // Método para BORRAR una especie usando su número de Id
    Task<bool> DeleteAsync(int id);

    // Método para BUSCAR UNA SOLA especie usando su número de Id
    Task<PetSpeciesProy> GetById(int id);

}