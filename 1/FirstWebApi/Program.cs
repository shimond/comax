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

app.MapPaymentsApis();

app.Run();


