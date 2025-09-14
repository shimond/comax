namespace FirstWebApi.Apis;

public static class Config
{
    public static IEndpointRouteBuilder MapConfigApis(this IEndpointRouteBuilder app)
    {
        var config = app.MapGroup("/api/config");

        config.MapGet("", GetConfig);

        config.MapGet("getPath", GetConfigPath);

        config.MapGet("complex", GetConfigComplex);
        
        config.MapGet("complexSnapshot", GetConfigComplexSnapshot);

        return app;
    }
    static async Task<Ok<string>> GetConfig(IConfiguration configuration)
    {
        var mySetting = configuration["ComaxValue"];
        return TypedResults.Ok(mySetting);
    }
    static async Task<Ok<SmtpConfig>> GetConfigComplex(IOptions<SmtpConfig> smtpConfig)
    {
        SmtpConfig smtp = smtpConfig.Value;
        return TypedResults.Ok(smtpConfig.Value);
    }

    static async Task<Ok<SmtpConfig>> GetConfigComplexSnapshot(IOptionsSnapshot<SmtpConfig> smtpConfig)
    {
        SmtpConfig smtp = smtpConfig.Value;
        return TypedResults.Ok(smtpConfig.Value);
    }

    static async Task<Ok<string>> GetConfigPath(IConfiguration configuration)
    {
        //Environment.GetEnvironmentVariable();

        var mySetting = configuration["ComaxValue"];
        return TypedResults.Ok(mySetting);
    }

    

}
