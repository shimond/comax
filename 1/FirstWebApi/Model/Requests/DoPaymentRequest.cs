namespace FirstWebApi.Model.Requests;

public class DoPaymentRequest
{
    public int Id { get; set; }
    public string PaymentCode { get; set; }
    public decimal Amount { get; set; }
}
