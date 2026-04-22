using BeicyMarket._2P.API.RepositoriesProy.Interfaces;
using BeicyMarket._2P.CORE.EntitiesProy;
using BeicyMarket._2P.CORE.HttpProy;
using Microsoft.AspNetCore.Mvc;

namespace BeicyMarket._2P.API.ControllersProy;


[ApiController]
[Route("api/[controller]")]
public class CategoryControllerProy : ControllerBase
{
    private readonly ICategoryRepositoryProy _categoryRepository;
    
    public CategoryControllerProy(ICategoryRepositoryProy categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    [HttpGet]
    public async Task<ActionResult<ResponseProy<List<CategoryProy>>>> GetAll()
    {
        var categories = await _categoryRepository.GetAllAsync();
        var response = new ResponseProy<List<CategoryProy>> { Data = categories };
        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<ResponseProy<CategoryProy>>> Post([FromBody] CategoryProy category)
    {
        category = await _categoryRepository.SaveAsync(category);
        var response = new ResponseProy<CategoryProy> { Data = category };
        return Created($"api/[controller]/{category.Id}", response);
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<ResponseProy<CategoryProy>>> GetById(int id)
    {
        var category = await _categoryRepository.GetById(id);
        var response = new ResponseProy<CategoryProy> { Data = category };
        if (category == null)
        {
            response.Errors.Add("Category not found");
            return NotFound(response);
        }
        return Ok(response);
    }

    [HttpPut]
    public async Task<ActionResult<ResponseProy<CategoryProy>>> Update([FromBody] CategoryProy category)
    {
        category = await _categoryRepository.UpdateAsync(category);
        var response = new ResponseProy<CategoryProy> { Data = category };
        return Ok(response);
    }
    
    [HttpDelete]
    [Route("{id:int}")]
    public async Task<ActionResult<ResponseProy<bool>>> Delete(int id)
    {
        var response = new ResponseProy<bool>();
        var result = await _categoryRepository.DeleteAsync(id);
        response.Data = result;
        if (!result) // Corregido: 'result' es un bool, verificamos si es falso
        {
            response.Errors.Add("Category not found or could not be deleted");
            return NotFound(response);
        }
        return Ok(response);
    }
}