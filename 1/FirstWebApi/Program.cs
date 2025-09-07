using FirstWebApi.Contracts;
using FirstWebApi.Model.Requests;
using FirstWebApi.Services;
using Microsoft.AspNetCore.Http.HttpResults;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.AddScoped<IPaymentManager, PaymentManager>();
builder.Services.AddScoped<ICancelOperation,  PaymentCancelOperation>();

var app = builder.Build();

app.MapPost("api/payments", 
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

app.MapPost("api/payments/cancel", async Task<Results<NotFound, Ok>>(string paymentCode, ICancelOperation cancelOperation)=>{

    await cancelOperation.DoCancel(paymentCode);
    return TypedResults.Ok();
});

app.Run();


