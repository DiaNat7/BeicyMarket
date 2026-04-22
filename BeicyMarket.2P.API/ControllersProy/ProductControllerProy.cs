using BeicyMarket._2P.API.RepositoriesProy.Interfaces;
using BeicyMarket._2P.CORE.EntitiesProy;
using BeicyMarket._2P.CORE.HttpProy;
using Microsoft.AspNetCore.Mvc;

namespace BeicyMarket._2P.API.ControllersProy;

[ApiController]
[Route("api/[controller]")]
public class ProductControllerProy : ControllerBase
{
    private readonly IProductRepositoriesProy _productRepository;
    
    public ProductControllerProy(IProductRepositoriesProy productRepository)
    {
        _productRepository = productRepository;
    }

    [HttpGet]
    public async Task<ActionResult<ResponseProy<List<ProductProy>>>> GetAll()
    {
        var products = await _productRepository.GetAllAsync();
        var response = new ResponseProy<List<ProductProy>> { Data = products };
        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<ResponseProy<ProductProy>>> Post([FromBody] ProductProy product)
    {
        product = await _productRepository.SaveAsync(product);
        var response = new ResponseProy<ProductProy> { Data = product };
        return Created($"api/[controller]/{product.Id}", response);
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<ResponseProy<ProductProy>>> GetById(int id)
    {
        var product = await _productRepository.GetById(id);
        var response = new ResponseProy<ProductProy> { Data = product };
        if (product == null)
        {
            response.Errors.Add("Product not found");
            return NotFound(response);
        }
        return Ok(response);
    }

    [HttpPut]
    public async Task<ActionResult<ResponseProy<ProductProy>>> Update([FromBody] ProductProy product)
    {
        product = await _productRepository.UpdateAsync(product);
        var response = new ResponseProy<ProductProy> { Data = product };
        return Ok(response);
    }
    
    [HttpDelete]
    [Route("{id:int}")]
    public async Task<ActionResult<ResponseProy<bool>>> Delete(int id)
    {
        var response = new ResponseProy<bool>();
        var result = await _productRepository.DeleteAsync(id);
        response.Data = result;
        if (!result)
        {
            response.Errors.Add("Product not found");
            return NotFound(response);
        }
        return Ok(response);
    }
}