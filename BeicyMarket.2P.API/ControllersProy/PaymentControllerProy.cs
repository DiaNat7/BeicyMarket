using BeicyMarket._2P.API.RepositoriesProy.Interfaces;
using BeicyMarket._2P.CORE.EntitiesProy;
using Microsoft.AspNetCore.Mvc;
using BeicyMarket._2P.CORE.HttpProy;

namespace BeicyMarket._2P.API.ControllersProy;

[ApiController]
[Route("api/[controller]")]
public class PaymentControllerProy : ControllerBase
{
    private readonly IPaymentRepositoryProy _paymentRepository;
    
    public PaymentControllerProy(IPaymentRepositoryProy paymentRepository)
    {
        _paymentRepository = paymentRepository;
    }

    [HttpGet]
    public async Task<ActionResult<ResponseProy<List<PaymentProy>>>> GetAll()
    {
        var payments = await _paymentRepository.GetAllAsync();
        var response = new ResponseProy<List<PaymentProy>> { Data = payments };
        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<ResponseProy<PaymentProy>>> Post([FromBody] PaymentProy payment)
    {
        payment = await _paymentRepository.SaveAsync(payment);
        var response = new ResponseProy<PaymentProy> { Data = payment };
        return Created($"api/[controller]/{payment.Id}", response);
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<ResponseProy<PaymentProy>>> GetById(int id)
    {
        var payment = await _paymentRepository.GetById(id);
        var response = new ResponseProy<PaymentProy> { Data = payment };
        if (payment == null)
        {
            response.Errors.Add("Payment not found");
            return NotFound(response);
        }
        return Ok(response);
    }

    [HttpPut]
    public async Task<ActionResult<ResponseProy<PaymentProy>>> Update([FromBody] PaymentProy payment)
    {
        payment = await _paymentRepository.UpdateAsync(payment);
        var response = new ResponseProy<PaymentProy> { Data = payment };
        return Ok(response);
    }
    
    [HttpDelete]
    [Route("{id:int}")]
    public async Task<ActionResult<ResponseProy<bool>>> Delete(int id)
    {
        var response = new ResponseProy<bool>();
        var result = await _paymentRepository.DeleteAsync(id);
        response.Data = result;
        if (!result)
        {
            response.Errors.Add("Payment not found");
            return NotFound(response);
        }
        return Ok(response);
    }
}