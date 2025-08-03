using TickerQ.Utilities.Enums;
using TickerQ.Utilities.Interfaces;

namespace AwesomeScheduling;

public class TickerExceptionHandler(ILogger<TickerExceptionHandler> logger) : ITickerExceptionHandler
{
    public Task HandleExceptionAsync(Exception exception, Guid tickerId, TickerType tickerType)
    {
        logger.LogError(exception, "Unhandled exception");
        return Task.CompletedTask;
    }

    public Task HandleCanceledExceptionAsync(Exception exception, Guid tickerId, TickerType tickerType)
    {
        logger.LogWarning(exception, "Ticker canceled");
        return Task.CompletedTask;
    }
}