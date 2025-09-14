var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.AddScoped<IPaymentManager, PaymentManager>();
builder.Services.AddScoped<ICancelOperation, PaymentCancelOperation>();

var app = builder.Build();

app.MapPaymentsApis();

var payment = new DoPaymentRequest
{
    PaymentCode = "A123",
    Amount = 100,
    Id = 1,
    IsVip = true
};


var payment2 = payment with { Id = 222 };

Util.PrintPaymentRequest(payment);
Console.WriteLine(payment.PaymentCode);


app.Run();


