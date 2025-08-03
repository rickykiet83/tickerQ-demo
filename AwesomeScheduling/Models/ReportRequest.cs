namespace AwesomeScheduling.Models;

public record ReportRequest
{
    public string? ReportType { get; init; } // e.g., SalesReport, InventoryReport
    public string? ReportName { get; init; } // Name of the report
    public DateTime? StartDate { get; init; } // Start date for the report
    public DateTime? EndDate { get; init; } // End date for the report
    public DateTime ExecutionTime { get; init; } // When the report should be generated
    public string? Format { get; init; } = "PDF"; // e.g., PDF, Excel
    public string? Email { get; init; } // Email to send the report to
    public string? PhoneNumber { get; init; } // Phone number for SMS notifications
    public string? AdditionalNotes { get; init; } // Any additional notes or instructions
}