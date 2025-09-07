using FirstWebApi.Contracts;
using FirstWebApi.Services;
using Microsoft.AspNetCore.OutputCaching;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(x => x.AddDefaultPolicy(po => po.AllowAnyOrigin()));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.AddOutputCache(); // save in current server memory.
builder.Services.AddSingleton<IPaymentManager, PaymentManager>();
var app = builder.Build();

//app.use
app.UseCors(); // OPTIONS Request
app.UseOutputCache();
app.UseStaticFiles();
app.MapControllers();

app.Run();


