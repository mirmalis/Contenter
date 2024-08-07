namespace Aper.Api.Services._0Brokers.Logging;

public class LoggingBroker : ILoggingBroker
{
    private readonly ILogger<LoggingBroker> logger;

    public LoggingBroker(ILogger<LoggingBroker> logger) =>
        this.logger = logger;

    public void LogInformation(string message) =>
        logger.LogInformation(message);

    public void LogTrace(string message) =>
        logger.LogTrace(message);

    public void LogDebug(string message) =>
        logger.LogDebug(message);

    public void LogWarning(string message) =>
        logger.LogWarning(message);

    public void LogError(Exception exception) =>
        logger.LogError(exception, exception.Message);

    public void LogCritical(Exception exception) =>
        logger.LogCritical(exception, exception.Message);
}
