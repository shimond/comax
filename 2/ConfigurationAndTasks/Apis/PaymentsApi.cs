namespace FirstWebApi.Apis;

public static class PaymentsApi
{
    public static IEndpointRouteBuilder MapPaymentsApis(this IEndpointRouteBuilder app)
    {
        var payments = app.MapGroup("/api/payments");

        payments.MapPost("", DoThePayments);
        payments.MapPost("cancel", CancelTheOperation);//.RequireAuthorization("admin");

        return app;
    }
    static async Task<Results<BadRequest, Ok<DoPaymentResponse>>> DoThePayments(DoPaymentRequest doPaymentRequest, IPaymentManager paymentManager)
    {
        if (doPaymentRequest.Amount < 0)
        {
            return TypedResults.BadRequest();
        }

        var result = await paymentManager.DoThePayment(doPaymentRequest.Id, doPaymentRequest.Amount);
        var response = new DoPaymentResponse
        {
            PaymentId = doPaymentRequest.Id,
            ActualAmount = result
        };
        Console.WriteLine(  doPaymentRequest.PaymentCode);
        return TypedResults.Ok(response);
    }

    static async Task<Results<NotFound, Ok>> CancelTheOperation(string paymentCode, ICancelOperation cancelOperation)
    {
        await cancelOperation.DoCancel(paymentCode);
        return TypedResults.Ok();
    }







}
