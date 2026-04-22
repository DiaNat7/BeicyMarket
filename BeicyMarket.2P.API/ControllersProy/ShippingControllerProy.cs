using BeicyMarket._2P.API.RepositoriesProy.Interfaces;
using BeicyMarket._2P.CORE.EntitiesProy;
using BeicyMarket._2P.CORE.HttpProy;
using Microsoft.AspNetCore.Mvc;


namespace BeicyMarket._2P.API.ControllersProy;

[ApiController]
[Route("api/[controller]")]
public class ShippingControllerProy : ControllerBase
{
    private readonly IShippingRepositoryProy _shippingRepository;
    
    public ShippingControllerProy(IShippingRepositoryProy shippingRepository)
    {
        _shippingRepository = shippingRepository;
    }

    [HttpGet]
    public async Task<ActionResult<ResponseProy<List<ShippingProy>>>> GetAll()
    {
        var shippings = await _shippingRepository.GetAllAsync();
        var response = new ResponseProy<List<ShippingProy>> { Data = shippings };
        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<ResponseProy<ShippingProy>>> Post([FromBody] ShippingProy shipping)
    {
        shipping = await _shippingRepository.SaveAsync(shipping);
        var response = new ResponseProy<ShippingProy> { Data = shipping };
        return Created($"api/[controller]/{shipping.Id}", response);
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<ResponseProy<ShippingProy>>> GetById(int id)
    {
        var shipping = await _shippingRepository.GetById(id);
        var response = new ResponseProy<ShippingProy> { Data = shipping };
        if (shipping == null)
        {
            response.Errors.Add("Shipping not found");
            return NotFound(response);
        }
        return Ok(response);
    }

    [HttpPut]
    public async Task<ActionResult<ResponseProy<ShippingProy>>> Update([FromBody] ShippingProy shipping)
    {
        shipping = await _shippingRepository.UpdateAsync(shipping);
        var response = new ResponseProy<ShippingProy> { Data = shipping };
        return Ok(response);
    }
    
    [HttpDelete]
    [Route("{id:int}")]
    public async Task<ActionResult<ResponseProy<bool>>> Delete(int id)
    {
        var response = new ResponseProy<bool>();
        var result = await _shippingRepository.DeleteAsync(id);
        response.Data = result;
        if (!result)
        {
            response.Errors.Add("Shipping not found");
            return NotFound(response);
        }
        return Ok(response);
    }
}