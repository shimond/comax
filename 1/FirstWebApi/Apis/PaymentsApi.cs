//namespace FirstWebApi.Apis;

using FirstWebApi.Contracts;
using FirstWebApi.Model.Requests;
using Microsoft.AspNetCore.Http.HttpResults;

public static class PaymentsApi
{
    public static IEndpointRouteBuilder MapPaymentsApis(this IEndpointRouteBuilder app)
    {
        var payments = app.MapGroup("/api/payments");

        payments.MapPost("",
            async Task<Results<BadRequest, Ok<DoPaymentResponse>>> (DoPaymentRequest doPaymentRequest, IPaymentManager paymentManager) =>
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
                return TypedResults.Ok(response);
            });

        payments.MapPost("cancel", CancelTheOperation);

        return app;


    }

    static async Task<Results<NotFound, Ok>> CancelTheOperation(string paymentCode, ICancelOperation cancelOperation)
    {
        await cancelOperation.DoCancel(paymentCode);
        return TypedResults.Ok();
    }







}
