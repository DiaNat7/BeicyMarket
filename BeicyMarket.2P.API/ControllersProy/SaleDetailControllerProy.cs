using BeicyMarket._2P.API.RepositoriesProy.Interfaces;
using BeicyMarket._2P.CORE.EntitiesProy;
using BeicyMarket._2P.CORE.HttpProy;
using Microsoft.AspNetCore.Mvc;

namespace BeicyMarket._2P.API.ControllersProy;


    [ApiController]
[Route("api/[controller]")]
public class SaleDetailControllerProy : ControllerBase
{
    private readonly ISaleDetailRepositoryProy _saleDetailRepository;
    
    public SaleDetailControllerProy(ISaleDetailRepositoryProy saleDetailRepository)
    {
        _saleDetailRepository = saleDetailRepository;
    }

    [HttpGet]
    public async Task<ActionResult<ResponseProy<List<SaleDetailProy>>>> GetAll()
    {
        var details = await _saleDetailRepository.GetAllAsync();
        var response = new ResponseProy<List<SaleDetailProy>> { Data = details };
        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<ResponseProy<SaleDetailProy>>> Post([FromBody] SaleDetailProy saleDetail)
    {
        saleDetail = await _saleDetailRepository.SaveAsync(saleDetail);
        var response = new ResponseProy<SaleDetailProy> { Data = saleDetail };
        return Created($"api/[controller]/{saleDetail.Id}", response);
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<ResponseProy<SaleDetailProy>>> GetById(int id)
    {
        var detail = await _saleDetailRepository.GetById(id);
        var response = new ResponseProy<SaleDetailProy> { Data = detail };
        if (detail == null)
        {
            response.Errors.Add("Sale detail not found");
            return NotFound(response);
        }
        return Ok(response);
    }

    [HttpPut]
    public async Task<ActionResult<ResponseProy<SaleDetailProy>>> Update([FromBody] SaleDetailProy saleDetail)
    {
        saleDetail = await _saleDetailRepository.UpdateAsync(saleDetail);
        var response = new ResponseProy<SaleDetailProy> { Data = saleDetail };
        return Ok(response);
    }
    
    [HttpDelete]
    [Route("{id:int}")]
    public async Task<ActionResult<ResponseProy<bool>>> Delete(int id)
    {
        var response = new ResponseProy<bool>();
        var result = await _saleDetailRepository.DeleteAsync(id);
        response.Data = result;
        if (!result)
        {
            response.Errors.Add("Sale detail not found");
            return NotFound(response);
        }
        return Ok(response);
    }
}
