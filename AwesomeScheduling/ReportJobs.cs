using AwesomeScheduling.Models;
using TickerQ.Utilities.Base;
using TickerQ.Utilities.Models;

namespace AwesomeScheduling;

public class ReportJobs(ILogger<ReportJobs> logger)
{
    /// <summary>
    /// Clean up reports jobs.
    /// This job is scheduled to run every day at midnight.
    /// You can change the cron expression to run it at different intervals.
    /// For example, to run it every minute, you can use "*/1 * * * * *".
    /// </summary>
    // [TickerFunction("RunDailyCleanup", "30 2 * * *")]// Cron expression for every day
    [TickerFunction("CleanUpReports", "*/1 * * * *")] // Cron expression for every minute
    public void CleanUpReports()
    {
        logger.LogInformation("Cleaning up report...");
    }

    /// <summary>
    /// Generate a report based on the provided request.
    /// This method is triggered by a TickerFunction and can be scheduled to run at specific intervals.
    /// The request contains details such as report type, date range, format, and optional
    /// email or phone number for sending the report.
    /// </summary>
    /// <param name="functionContext"></param>
    /// <param name="cancellationToken"></param>
    [TickerFunction("GenerateReport")]
    public async Task GenerateReport(TickerFunctionContext<ReportRequest> functionContext, CancellationToken cancellationToken = default)
    {
        var request = functionContext.Request;
        logger.LogInformation("Generating report of type {ReportType} from {StartDate} to {EndDate} in {Format} format",
            request.ReportType, request.StartDate, request.EndDate, request.Format);
        
        // Add logic to generate the report based on the request,
        // For example, you could fetch data from a database and create a PDF or Excel file.
        // If the request contains an email or phone number, you can send the report via email or SMS.
        logger.LogInformation("Report generated successfully: {ReportName} ({ReportType}) from {StartDate} to {EndDate} in {Format} format",
            request.ReportName,
            request.ReportType, request.StartDate, request.EndDate, request.Format);
        if (!string.IsNullOrEmpty(request.Email))
        {  
            logger.LogInformation("Sending report to email: {Email}", request.Email);
            // Add logic to send the report via email
        }
        if (!string.IsNullOrEmpty(request.PhoneNumber))
        {
            logger.LogInformation("Sending report to phone number: {PhoneNumber}", request.PhoneNumber);
            // Add logic to send the report via SMS
        }
        // Simulate report generation delay
        await Task.Delay(2000, cancellationToken);
    }
}