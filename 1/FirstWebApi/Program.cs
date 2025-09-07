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


public class ComaxCacheOutputStore : IOutputCacheStore
{
    //delete from cache by key
    public ValueTask EvictByTagAsync(string tag, CancellationToken cancellationToken)
    {
       return ValueTask.CompletedTask;
    }

    public ValueTask<byte[]?> GetAsync(string key, CancellationToken cancellationToken)
    {
         return ValueTask.FromResult<byte[]?>(null); 
    }

    public ValueTask SetAsync(string key, byte[] value, string[]? tags, TimeSpan validFor, CancellationToken cancellationToken)
    {
        return ValueTask.CompletedTask;
    }
}
