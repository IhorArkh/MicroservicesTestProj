# MicroservicesTestProj
Sample of a modern ecommerce app with microservices architecture.

## How to run
- git clone
- docker compose up
- for testing, you can use a postman collection located in the src folder

## Stack

### Architecture
- Microservice architecture
- RabbitMQ + MassTransit for async communication
- YARP as API Gateway for routing and rate limiting
- Logging, global exceptions handling and health checks for all services

#### Catalog service
- Vertical slice architecture with CQRS
- ASP.NET Core Minimal API
- MediatR for CQRS
- Carter for API Endpoints
- PostgreSQL + Marten to use it as a Transactional  DocumentDB
- Mapster
- FluentValidation

#### Basket service
- Vertical slice architecture with CQRS
- Repository pattern
- ASP.NET Core Minimal API
- gRPC(calls to basket service)
- Redis
- MassTransit
- MediatR for CQRS
- Carter for API Endpoints
- PostgreSQL + Marten to use it as a Transactional  DocumentDB
- Mapster
- FluentValidation
- Scrutor

#### Discount service
- N-Layer architecture
- gRPC
- Entity Framework Core
- SQLite
- Mapster
- FluentValidation

#### Ordering service
- Clean architecture with CQRS and DDD
- Repository pattern
- ASP.NET Core Minimal API
- Entity Framework Core
- MS SQL
- MediatR for CQRS
- Carter for API Endpoints
- Mapster
- FluentValidation