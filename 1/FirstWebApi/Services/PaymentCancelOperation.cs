using FirstWebApi.Contracts;

namespace FirstWebApi.Services;

// Models - Entities,DTOs,Requests,Responses
// Services - Business Logic, Class with one method or more
public class PaymentCancelOperation : ICancelOperation
{
    private ILogger<PaymentCancelOperation> _logger;

    public PaymentCancelOperation(ILogger<PaymentCancelOperation> logger)
    {
        _logger = logger;

    }
    public async Task DoCancel(string code)
    {
        await Task.Delay(1000); // Simulate some processing time
        _logger.LogInformation($"Payment with code {code} is cancelled.");  
    }
}