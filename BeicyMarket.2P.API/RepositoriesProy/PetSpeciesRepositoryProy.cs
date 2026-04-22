using BeicyMarket._2P.API.RepositoriesProy.Interfaces;
using BeicyMarket._2P.CORE.EntitiesProy;
using BeicyMarket._2P.API.DataAccessProy;
using Dapper;
using Dapper.Contrib.Extensions;

namespace BeicyMarket._2P.API.RepositoriesProy;

public class PetSpeciesRepositoryProy : IPetSpeciesRepositoryProy
{
    private readonly DbContextProy _context;
    
    public PetSpeciesRepositoryProy(DbContextProy context)
    {
        _context = context;
    }
    
    // CREAR o GUARDAR
    public async Task<PetSpeciesProy> SaveAsync(PetSpeciesProy petSpecies)
    {
        using var connection = _context.Connection;
        
        // Establecer valores por defecto
        petSpecies.CreatedDate = DateTime.UtcNow;
        petSpecies.IsDeleted = false;
        
        // Insertar y obtener el ID generado
        var id = await connection.InsertAsync(petSpecies);
        petSpecies.Id = (int)id;
        
        return petSpecies;
    }
    
    // ACTUALIZAR
    public async Task<PetSpeciesProy> UpdateAsync(PetSpeciesProy petSpecies)
    {
        using var connection = _context.Connection;
        
        // Actualizar fecha de modificación
        petSpecies.UpdatedDate = DateTime.UtcNow;
        
        // Actualizar en la base de datos
        await connection.UpdateAsync(petSpecies);
        
        return petSpecies;
    }
    
    // OBTENER TODOS
    public async Task<List<PetSpeciesProy>> GetAllAsync()
    {
        using var connection = _context.Connection;
        
        // Traer solo los que NO están eliminados
        var query = "SELECT * FROM PetSpeciesProy WHERE IsDeleted = 0";
        var result = await connection.QueryAsync<PetSpeciesProy>(query);
        
        return result.ToList();
    }
    
    // ELIMINAR (borrado lógico)
    public async Task<bool> DeleteAsync(int id)
    {
        using var connection = _context.Connection;
        
        // Borrado lógico con SQL directo
        var query = "UPDATE PetSpeciesProy SET IsDeleted = 1, UpdatedDate = @UpdatedDate WHERE Id = @Id";
        var rowsAffected = await connection.ExecuteAsync(query, new 
        { 
            Id = id, 
            UpdatedDate = DateTime.UtcNow 
        });
        
        return rowsAffected > 0;
    }
    
    // OBTENER POR ID
    public async Task<PetSpeciesProy> GetById(int id)
    {
        using var connection = _context.Connection;
        
        var query = "SELECT * FROM PetSpeciesProy WHERE Id = @Id AND IsDeleted = 0";
        var result = await connection.QueryFirstOrDefaultAsync<PetSpeciesProy>(query, new { Id = id });
        
        return result;
    }
}
