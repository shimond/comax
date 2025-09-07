namespace FirstWebApi.Contracts;

public interface IPaymentManager
{
    Task<decimal> DoThePayment(int paymentId, decimal price);
}

