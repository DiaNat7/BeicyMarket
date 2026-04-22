using BeicyMarket._2P.API.RepositoriesProy.Interfaces;
using BeicyMarket._2P.CORE.EntitiesProy;

namespace BeicyMarket._2P.API.RepositoriesProy;

public class PetSpeciesRepositoryProy :  IPetSpeciesRepositoryProy
{
    public Task<PetSpeciesProy> SaveAsync(PetSpeciesProy petSpecies)
    {
        throw new NotImplementedException();
    }

    public Task<PetSpeciesProy> UpdateAsync(PetSpeciesProy petSpecies)
    {
        throw new NotImplementedException();
    }

    public Task<List<PetSpeciesProy>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<PetSpeciesProy> GetById(int id)
    {
        throw new NotImplementedException();
    }
}