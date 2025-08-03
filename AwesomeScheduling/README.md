## TickerQ demo
This is a demo of TickerQ, a scheduling system that allows you to schedule tasks based on time intervals and specific times of the day.
Read the full introduction and step-by-step implementation at:
- [Medium](https://medium.com/@kietpham.dev/introducing-ticketq-your-modern-backgroung-task-scheduler-for-net-653f79c44208?sk=50dea07c940ceff5f94f01bee82e1920)
- [Linkedin](https://www.linkedin.com/pulse/introducing-ticketq-your-modern-backgroung-task-scheduler-kiet-pham-2fvhc)

## Demo features:
- **Time-based scheduling**: Schedule tasks to run at specific times of the day or at
- **Interval-based scheduling**: Schedule tasks to run at regular intervals (e.g., every 5 minutes).
- **Dashboard**: A user-friendly dashboard to manage and monitor scheduled tasks.
- **Entity Framework Core**: Use Entity Framework Core for database operations, with PostgreSQL as the database provider.
- **Docker support**: Run the application in a Docker container with PostgreSQL.
- **Migrations**: Use Entity Framework Core migrations to manage database schema changes.
- **Comparison with other libraries**: TickerQ is compared with Hangfire and Quartz.NET to highlight its unique features and advantages.

## Docker commands:
- Run postgres container:
```bash
docker run --name postgres -e POSTGRES_USER=postgres -e POSTGRES_PASSWORD=postgres -p 5432:5432 -d postgres
```

## Install packages:
- TickerQ 
- TickerQ.Dashboard
- TickerQ.EntityFrameworkCore

## Dotnet migrations commands:
```bash
dotnet ef migrations add InitialCreate -c MyDbContext -p AwesomeScheduling/AwesomeScheduling.csproj
dotnet ef database update -p AwesomeScheduling/AwesomeScheduling.csproj
```

## Run the application:
```bash
dotnet run -p AwesomeScheduling/AwesomeScheduling.csproj
```
- Access the dashboard at: [https://localhost:7185/tickerq/](https://localhost:7185/tickerq/)

## [TickerQ vs Hangfire vs Quartz.NET](https://tickerq.arcenox.com/comparison/comparison-other-libraries.html):
- **TickerQ**: Focuses on scheduling tasks based on time intervals and specific times of the day, with a user-friendly dashboard for managing tasks.
- **Hangfire**: A background job processing system that allows you to run tasks in the background, with support for recurring jobs and delayed tasks.
- **Quartz.NET**: A full-featured job scheduling system that provides advanced scheduling capabilities, including cron-like expressions and complex job chains.
- **Comparison**: TickerQ is more focused on time-based scheduling with a simple interface, while Hangfire and Quartz.NET offer more advanced features for background job processing and complex scheduling scenarios. TickerQ is ideal for applications that require straightforward scheduling without the complexity of full-fledged job processing systems.
