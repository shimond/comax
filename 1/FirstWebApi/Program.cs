var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.Use(async (context, next) =>
{
    app.Logger.LogInformation("Processing {Method} request to {Path}", context.Request.Method, context.Request.Path);
    await next();
    app.Logger.LogInformation("END Processing {Method} request to {Path}", context.Request.Method, context.Request.Path);
});


app.UseStaticFiles();
app.MapControllers();

if(app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

// add middleware to serve static files
// Configure the HTTP request pipeline
app.Use(async (context, next) =>
{
    context.Response.StatusCode = 200;
    await context.Response.WriteAsync("  Hello from first middleware!  "); // 1
    if (context.Request.Method.ToUpper() == "POST")
    {
        await next();
    }
    await context.Response.WriteAsync("  END from first middleware!  "); //6

});

app.Use(async (context, next) =>
{

    await context.Response.WriteAsync("  Hello from Second middleware!  "); // 2 
    await next();
    await context.Response.WriteAsync("  END from Second  middleware!  "); //5

});

app.Use(async (context, next) =>
{

    await context.Response.WriteAsync("  Hello from 3hrd middleware!  "); // 3
    await next();
    await context.Response.WriteAsync("  END from 3hrd  middleware!  "); //4

});

app.Run();
