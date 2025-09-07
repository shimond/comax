using FirstWebApi.Model.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;

namespace FirstWebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PaymentController : ControllerBase
{
    private readonly ILogger<PaymentController> logger;
    public PaymentController(ILogger<PaymentController> logger)
    {
        this.logger = logger;
    }
    
    [HttpPost]
    public IActionResult DoPayment(DoPaymentRequest doPaymentRequest)
    {

        if(doPaymentRequest.Amount < 0)
        {
            return BadRequest();
        }

        var response = new DoPaymentResponse
        {
            PaymentId = doPaymentRequest.Id,
            ActualAmount = doPaymentRequest.Amount
        };

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




    [HttpGet("status")]
    [OutputCache(Duration =60)]
    public async  Task<string> GetPaymentStatus()
    {
        logger.LogInformation("GetPaymentStatus invoked");
        await Task.Delay(5000);
        return "Payment processed successfully.";
    }

}
