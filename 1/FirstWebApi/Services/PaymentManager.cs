using FirstWebApi.Contracts;

namespace FirstWebApi.Services;

// Models - Entities,DTOs,Requests,Responses
// Services - Business Logic, Class with one method or more
public class PaymentManager : IPaymentManager
{
    public async Task<decimal> DoThePayment(int paymentId, decimal price)
    {
        await Task.Delay(1000); // Simulate some processing time
        return price * 1.18m;
    }
}

public class PaymentManager2 : IPaymentManager
{
    public async Task<decimal> DoThePayment(int paymentId, decimal price)
    {
        await Task.Delay(1000); // Simulate some processing time
        return price * 1.17m;
    }
}