namespace FirstWebApi.Model.Requests;

public record DoPaymentRequest
{
    public int Id { get; init; }
    public required string PaymentCode { get; init; }
    public decimal Amount { get; init; } = 0;
    public bool? IsVip { get; init; }
    //public Nullable<bool> IsVip { get; init; }
}

public static class Util
{
    public static void PrintPaymentRequest(DoPaymentRequest request)
    {
        Console.WriteLine($"Payment Code: {request.PaymentCode}");
        Console.WriteLine($"Amount: {request.Amount}");
        Console.WriteLine($"Is VIP: {request.IsVip}");
        //if(request.PaymentCode.StartsWith("A"))
        //{
        //    request.PaymentCode = "WOW";
        //}
    }

}