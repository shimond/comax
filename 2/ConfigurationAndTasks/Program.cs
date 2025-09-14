using ConfigurationAndTasks.Model.Config;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<SmtpConfig>(builder.Configuration.GetSection("SmtpConfig"));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.AddScoped<IPaymentManager, PaymentManager>();
builder.Services.AddScoped<ICancelOperation, PaymentCancelOperation>();

var app = builder.Build();

app.MapPaymentsApis();
app.MapConfigApis();
app.Run();


