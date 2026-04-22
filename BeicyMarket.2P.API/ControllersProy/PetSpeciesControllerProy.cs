using BeicyMarket._2P.API.RepositoriesProy.Interfaces;
using BeicyMarket._2P.CORE.EntitiesProy;
using Microsoft.AspNetCore.Mvc;
using BeicyMarket._2P.CORE.HttpProy;
namespace BeicyMarket._2P.API.ControllersProy;


[ApiController]
[Route("api/[controller]")]
public class PetSpeciesControllerProy : ControllerBase
{
    private readonly IPetSpeciesRepositoryProy _petSpeciesRepository;
    
    public PetSpeciesControllerProy(IPetSpeciesRepositoryProy petSpeciesRepository)
    {
        _petSpeciesRepository = petSpeciesRepository;
    }

    [HttpGet]
    public async Task<ActionResult<ResponseProy<List<PetSpeciesProy>>>> GetAll()
    {
        var species = await _petSpeciesRepository.GetAllAsync();
        var response = new ResponseProy<List<PetSpeciesProy>> { Data = species };
        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<ResponseProy<PetSpeciesProy>>> Post([FromBody] PetSpeciesProy petSpecies)
    {
        petSpecies = await _petSpeciesRepository.SaveAsync(petSpecies);
        var response = new ResponseProy<PetSpeciesProy> { Data = petSpecies };
        return Created($"api/[controller]/{petSpecies.Id}", response);
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<ResponseProy<PetSpeciesProy>>> GetById(int id)
    {
        var species = await _petSpeciesRepository.GetById(id);
        var response = new ResponseProy<PetSpeciesProy> { Data = species };
        if (species == null)
        {
            response.Errors.Add("Pet species not found");
            return NotFound(response);
        }
        return Ok(response);
    }

    [HttpPut]
    public async Task<ActionResult<ResponseProy<PetSpeciesProy>>> Update([FromBody] PetSpeciesProy petSpecies)
    {
        petSpecies = await _petSpeciesRepository.UpdateAsync(petSpecies);
        var response = new ResponseProy<PetSpeciesProy> { Data = petSpecies };
        return Ok(response);
    }
    
    [HttpDelete]
    [Route("{id:int}")]
    public async Task<ActionResult<ResponseProy<bool>>> Delete(int id)
    {
        var response = new ResponseProy<bool>();
        var result = await _petSpeciesRepository.DeleteAsync(id);
        response.Data = result;
        if (!result)
        {
            response.Errors.Add("Pet species not found");
            return NotFound(response);
        }
        return Ok(response);
    }
}