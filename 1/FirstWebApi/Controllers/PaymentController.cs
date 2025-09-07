using FirstWebApi.Contracts;
using FirstWebApi.Model.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;

namespace FirstWebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PaymentController : ControllerBase
{
    private readonly ILogger<PaymentController> _logger;
    private readonly IPaymentManager _paymentManager;
    private readonly ICancelOperation _cancelOperation;

    public PaymentController(
        ILogger<PaymentController> logger, 
        ICancelOperation cancelOperation,
        IPaymentManager paymentManager)
    {
        this._logger = logger;
        this._paymentManager = paymentManager;
        this._cancelOperation = cancelOperation;
    }
    
    [HttpPost]
    public async Task<IActionResult> DoPayment(DoPaymentRequest doPaymentRequest)
    {

        if(doPaymentRequest.Amount < 0)
        {
            return BadRequest();
        }

        var result = await this._paymentManager.DoThePayment(doPaymentRequest.Id, doPaymentRequest.Amount);   

        var response = new DoPaymentResponse
        {
            PaymentId = doPaymentRequest.Id,
            ActualAmount = result
        };
        //return Ok(true);
        //return Ok("Hello");
        return  Ok(response);

        // processing payment

        //Status codes:

        //200 OK
        //201 Created

        //Client Errors:
        //400 Bad Request
        //401 Unauthorized
        //403 Forbidden

        //Server Errors:
        //500 Internal Server Error
        //502 Bad Gateway
        //503 Service Unavailable



    }

    [HttpPost("cancel")]
    public async Task<IActionResult> CancelPayment(string paymentCode)
    {
        await this._cancelOperation.DoCancel(paymentCode);
        return Ok();
    }



    [HttpGet("status")]
    [OutputCache(Duration =60)]
    public async  Task<string> GetPaymentStatus()
    {
        _logger.LogInformation("GetPaymentStatus invoked");
        await Task.Delay(5000);
        return "Payment processed successfully.";
    }

}
