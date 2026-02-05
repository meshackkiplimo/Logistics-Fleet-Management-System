# Logistics & Fleet Management System - Backend

ASP.NET Core microservices backend for logistics and fleet management.

## Tech Stack

- .NET 9.0
- ASP.NET Core Web API
- Entity Framework Core
- SignalR (Real-time tracking)
- Redis (Caching)
- RabbitMQ (Message Queue)
- SQL Server

## Prerequisites

- .NET 9.0 SDK
- Docker & Docker Compose

## Setup

```bash
# Start infrastructure
docker-compose up -d

# Restore dependencies
dotnet restore

# Run services
dotnet run --project src/Services/FleetService
```

## License

MIT License
