using BeicyMarket._2P.API.RepositoriesProy.Interfaces;
using BeicyMarket._2P.CORE.EntitiesProy;
using BeicyMarket._2P.CORE.HttpProy;
using Microsoft.AspNetCore.Mvc;
namespace BeicyMarket._2P.API.ControllersProy;


[ApiController]
[Route("api/[controller]")]
public class UserControllerProy : ControllerBase
{
    private readonly IUserRepositoriesProy _userRepository;

    public UserControllerProy(IUserRepositoriesProy userRepository)
    {
        _userRepository = userRepository;
    }

    [HttpGet]
    public async Task<ActionResult<ResponseProy<List<UserProy>>>> GetAll()
    {
        var users = await _userRepository.GetAllAsync();
        var response = new ResponseProy<List<UserProy>> { Data = users };
        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<ResponseProy<UserProy>>> Post([FromBody] UserProy user)
    {
        user = await _userRepository.SaveAsync(user);
        var response = new ResponseProy<UserProy> { Data = user };
        return Created($"api/[controller]/{user.Id}", response);
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<ResponseProy<UserProy>>> GetById(int id)
    {
        var user = await _userRepository.GetById(id);
        var response = new ResponseProy<UserProy> { Data = user };
        if (user == null)
        {
            response.Errors.Add("User not found");
            return NotFound(response);
        }

        return Ok(response);
    }

    [HttpPut]
    public async Task<ActionResult<ResponseProy<UserProy>>> Update([FromBody] UserProy user)
    {
        user = await _userRepository.UpdateAsync(user);
        var response = new ResponseProy<UserProy> { Data = user };
        return Ok(response);
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<ActionResult<ResponseProy<bool>>> Delete(int id)
    {
        var response = new ResponseProy<bool>();
        var result = await _userRepository.DeleteAsync(id);
        response.Data = result;
        if (!result)
        {
            response.Errors.Add("User not found");
            return NotFound(response);
        }

        return Ok(response);
    }
}