namespace ConfigurationAndTasks.Model.Config;

public record SmtpConfig
{
    public required string SmtpServer { get; init; }
    public int Port { get; init; }
    public required string UserName { get; init; }
    public required string Password { get; init; }
    public string[] AllowSenders { get; init; } = [];

    public SmtpConfig()
    {
        
    }
}
