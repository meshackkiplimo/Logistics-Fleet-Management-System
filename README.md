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

## Microservices

- **OrderService** - Order & delivery lifecycle management
- **UserService** - User authentication & management
- **PaymentService** - Payment processing
- **FleetService** - GPS tracking & route optimization
- **ApiGateway** - API Gateway

## Prerequisites

- .NET 9.0 SDK
- Docker & Docker Compose
- SQL Server / Docker

## Setup

1. **Start Infrastructure Services**
```bash
docker-compose up -d
```

2. **Restore Dependencies**
```bash
dotnet restore
```

3. **Run Services**
```bash
dotnet run --project src/Services/FleetService
dotnet run --project src/Services/OrderService
dotnet run --project src/Services/UserService
dotnet run --project src/Services/PaymentService
```

## Connection Strings

- SQL Server: `Server=localhost,1433;Database=LogisticsDB;User Id=sa;Password=YourStrong@Passw0rd;TrustServerCertificate=True`
- Redis: `localhost:6379`
- RabbitMQ: `localhost:5672` (Management UI: http://localhost:15672)

## API Ports

- FleetService: 5001
- OrderService: 5002
- UserService: 5003
- PaymentService: 5004
- ApiGateway: 5000
