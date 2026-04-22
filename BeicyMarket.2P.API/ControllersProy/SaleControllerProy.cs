using BeicyMarket._2P.API.RepositoriesProy.Interfaces;
using BeicyMarket._2P.CORE.EntitiesProy;
using BeicyMarket._2P.CORE.HttpProy;
using Microsoft.AspNetCore.Mvc;

namespace BeicyMarket._2P.API.ControllersProy;

    [ApiController]
    [Route("api/[controller]")]
    public class SaleControllerProy : ControllerBase
    {
        private readonly ISaleRepositoryProy _saleRepository;
    
        public SaleControllerProy(ISaleRepositoryProy saleRepository)
        {
            _saleRepository = saleRepository;
        }

        [HttpGet]
        public async Task<ActionResult<ResponseProy<List<SaleProy>>>> GetAll()
        {
            var sales = await _saleRepository.GetAllAsync();
            var response = new ResponseProy<List<SaleProy>> { Data = sales };
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<ResponseProy<SaleProy>>> Post([FromBody] SaleProy sale)
        {
            sale = await _saleRepository.SaveAsync(sale);
            var response = new ResponseProy<SaleProy> { Data = sale };
            return Created($"api/[controller]/{sale.Id}", response);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<ResponseProy<SaleProy>>> GetById(int id)
        {
            var sale = await _saleRepository.GetById(id);
            var response = new ResponseProy<SaleProy> { Data = sale };
            if (sale == null)
            {
                response.Errors.Add("Sale not found");
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult<ResponseProy<SaleProy>>> Update([FromBody] SaleProy sale)
        {
            sale = await _saleRepository.UpdateAsync(sale);
            var response = new ResponseProy<SaleProy> { Data = sale };
            return Ok(response);
        }
    
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult<ResponseProy<bool>>> Delete(int id)
        {
            var response = new ResponseProy<bool>();
            var result = await _saleRepository.DeleteAsync(id);
            response.Data = result;
            if (!result)
            {
                response.Errors.Add("Sale not found");
                return NotFound(response);
            }
            return Ok(response);
        }
    }
