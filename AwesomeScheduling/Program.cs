using System.Drawing;
using AwesomeScheduling;
using AwesomeScheduling.Models;
using Microsoft.EntityFrameworkCore;
using TickerQ.Dashboard.DependencyInjection;
using TickerQ.DependencyInjection;
using TickerQ.EntityFrameworkCore.DependencyInjection;
using TickerQ.Utilities;
using TickerQ.Utilities.Enums;
using TickerQ.Utilities.Interfaces.Managers;
using TickerQ.Utilities.Models.Ticker;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.
builder.Services.AddTickerQ(options =>
{
    options.SetExceptionHandler<TickerExceptionHandler>(); // Set a custom exception handler
    options.SetMaxConcurrency(4); // Set the maximum concurrency for job execution
    options.AddOperationalStore<MyDbContext>(opt =>
    {
        opt.UseModelCustomizerForMigrations(); // Use custom model for migrations
        opt.CancelMissedTickersOnApplicationRestart(); // Cancel missed tickers on application restart
    });
    options.AddDashboard(basePath: "/tickerq"); // Set the base path for the dashboard
    options.AddDashboardBasicAuth(); // Enable basic authentication for the dashboard
});

var app = builder.Build();

app.UseTickerQ();

app.MapPost("/scheduleReport", async (ReportRequest request, ITimeTickerManager<TimeTicker> timeTickerManager) =>
    {
        await timeTickerManager.AddAsync(new TimeTicker
        {
            Request = TickerHelper.CreateTickerRequest(request),
            ExecutionTime = request.ExecutionTime,
            Function =  nameof(ReportJobs.GenerateReport),
            Description = request.ReportName ?? "Report Generation",
            Retries = 3,
            RetryIntervals = [1, 2, 3],
        });
        return Results.Ok();
    });

app.Run();