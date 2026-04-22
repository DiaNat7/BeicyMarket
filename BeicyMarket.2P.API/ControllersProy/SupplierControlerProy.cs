using BeicyMarket._2P.API.RepositoriesProy.Interfaces;
using BeicyMarket._2P.CORE.EntitiesProy;
using BeicyMarket._2P.CORE.HttpProy;
using Microsoft.AspNetCore.Mvc;

namespace BeicyMarket._2P.API.ControllersProy;

[ApiController]
[Route("api/[controller]")]
public class SupplierControllerProy : ControllerBase
{
    private readonly ISupplierRepositoryProy _supplierRepository;
    
    public SupplierControllerProy(ISupplierRepositoryProy supplierRepository)
    {
        _supplierRepository = supplierRepository;
    }

    [HttpGet]
    public async Task<ActionResult<ResponseProy<List<SupplierProy>>>> GetAll()
    {
        var suppliers = await _supplierRepository.GetAllAsync();
        var response = new ResponseProy<List<SupplierProy>> { Data = suppliers };
        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<ResponseProy<SupplierProy>>> Post([FromBody] SupplierProy supplier)
    {
        supplier = await _supplierRepository.SaveAsync(supplier);
        var response = new ResponseProy<SupplierProy> { Data = supplier };
        return Created($"api/[controller]/{supplier.Id}", response);
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<ResponseProy<SupplierProy>>> GetById(int id)
    {
        var supplier = await _supplierRepository.GetById(id);
        var response = new ResponseProy<SupplierProy> { Data = supplier };
        if (supplier == null)
        {
            response.Errors.Add("Supplier not found");
            return NotFound(response);
        }
        return Ok(response);
    }

    [HttpPut]
    public async Task<ActionResult<ResponseProy<SupplierProy>>> Update([FromBody] SupplierProy supplier)
    {
        supplier = await _supplierRepository.UpdateAsync(supplier);
        var response = new ResponseProy<SupplierProy> { Data = supplier };
        return Ok(response);
    }
    
    [HttpDelete]
    [Route("{id:int}")]
    public async Task<ActionResult<ResponseProy<bool>>> Delete(int id)
    {
        var response = new ResponseProy<bool>();
        var result = await _supplierRepository.DeleteAsync(id);
        response.Data = result;
        if (!result)
        {
            response.Errors.Add("Supplier not found");
            return NotFound(response);
        }
        return Ok(response);
    }
}