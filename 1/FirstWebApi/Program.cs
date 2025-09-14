using FirstWebApi.Contracts;
using FirstWebApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.AddScoped<IPaymentManager, PaymentManager>();
builder.Services.AddScoped<ICancelOperation,  PaymentCancelOperation>();

var app = builder.Build();

app.MapPaymentsApis();

app.Run();


