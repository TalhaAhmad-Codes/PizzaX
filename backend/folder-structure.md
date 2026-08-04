
---

# Pragmatic Clean Architecture

```
PizzaX
│
├── Features
│
├── Common
│
├── Infrastructure
│
├── Database
│
├── Configuration
│
├── Middleware
│
├── Extensions
│
├── Services
│
├── BackgroundJobs
│
├── Realtime
│
├── Program.cs
└── appsettings.json
```

---

# Inside Features

Everything business-related lives here.

```
Features
│
├── ERP
│   ├── Employees
│   ├── Inventory
│   ├── Suppliers
│   ├── Purchases
│   ├── Reports
│   └── Dashboard
│
├── POS
│   ├── Orders
│   ├── Menu
│   ├── Categories
│   ├── Kitchen
│   ├── Tables
│   ├── Reservations
│   └── Payments
│
├── CRM
│   ├── Customers
│   ├── Loyalty
│   ├── Coupons
│   ├── Feedback
│   └── Notifications
│
├── Identity
│   ├── Authentication
│   ├── Authorization
│   └── Users
│
└── Shared
```

Each feature is isolated.

Example:

```
Orders
│
├── Commands
│
├── Queries
│
├── Handlers
│
├── DTOs
│
├── Validators
│
├── Mapping
│
├── Endpoints
│
├── Services
│
├── Repositories
│
└── Entities
```

This is Vertical Slice Architecture **inside** Clean Architecture.

---

# Common

Contains reusable things.

```
Common
│
├── Abstractions
├── Behaviors
├── Constants
├── DTOs
├── Enums
├── Exceptions
├── Interfaces
├── Mapping
├── Models
├── Results
├── Utilities
└── ValueObjects
```

Nothing feature-specific belongs here.

---

# Infrastructure

Everything external.

```
Infrastructure
│
├── Authentication
│
├── Authorization
│
├── Email
│
├── FileStorage
│
├── Logging
│
├── Payments
│
├── Caching
│
├── Identity
│
└── AI
```

---

# Database

```
Database
│
├── Context
│
│   └── ApplicationDbContext.cs
│
├── Configurations
│
├── Migrations
│
├── Seeders
│
└── Interceptors
```

---

# Configuration

```
Configuration
│
├── JwtOptions.cs
├── DatabaseOptions.cs
├── EmailOptions.cs
├── StorageOptions.cs
├── AIOptions.cs
└── SwaggerOptions.cs
```

---

# Middleware

```
Middleware
│
├── ExceptionMiddleware
├── RequestLoggingMiddleware
├── RateLimitingMiddleware
├── PerformanceMiddleware
└── CorrelationIdMiddleware
```

---

# Extensions

```
Extensions
│
├── AuthenticationExtensions
├── DatabaseExtensions
├── ServiceCollectionExtensions
├── SwaggerExtensions
├── HealthCheckExtensions
└── ApplicationExtensions
```

Keeps Program.cs tiny.

---

# BackgroundJobs

```
BackgroundJobs
│
├── Cleanup
├── Email
├── Reports
├── Notifications
└── AI
```

Future Hangfire jobs.

---

# Realtime

```
Realtime
│
├── Hubs
├── Notifications
└── Groups
```

Future SignalR.

---

# Services

Only cross-feature services.

```
Services
│
├── CurrentUserService
├── DateTimeService
├── TokenService
├── PermissionService
└── FileService
```

---

# Clean Architecture Dependency Rule

```
Features
        ↓
Common
        ↓
Infrastructure
        ↓
Database
```

Never the opposite.

Example:

❌ Database calling Features

❌ Infrastructure calling Orders

✔ Orders using interfaces

✔ Infrastructure implementing interfaces

---

# Typical Feature

```
Features
└── Orders
    │
    ├── Entities
    │     ├── Order.cs
    │     └── OrderItem.cs
    │
    ├── DTOs
    │
    ├── Commands
    │     ├── CreateOrderCommand.cs
    │     ├── CancelOrderCommand.cs
    │     └── UpdateOrderStatusCommand.cs
    │
    ├── Queries
    │     ├── GetOrderQuery.cs
    │     └── GetOrdersQuery.cs
    │
    ├── Handlers
    │
    ├── Validators
    │
    ├── Mapping
    │
    ├── Repositories
    │
    ├── Services
    │
    └── Endpoints
```

Everything related to Orders stays together.

---

# Why this architecture?

Compared to traditional Clean Architecture:

| Traditional Clean                   | Pragmatic Clean (Recommended)             |
| ----------------------------------- | ----------------------------------------- |
| 8–12 projects                       | 1 project                                 |
| Hard navigation                     | Feature-first navigation                  |
| Lots of dependency injection wiring | Minimal wiring                            |
| Easy to over-engineer               | Simpler while remaining scalable          |
| Better for very large teams         | Ideal for solo developers and small teams |
| Slower feature development          | Faster iteration                          |

## Suggested evolution for Pizza X

Since Pizza X is intended to become a secure, scalable ERP with AI integration, I would implement it in phases:

1. **Phase 1:** Single-project Pragmatic Clean Architecture (the structure above).
2. **Phase 2:** Introduce MediatR/CQRS, FluentValidation, Mapster, Serilog, authentication, authorization, and other enterprise cross-cutting concerns.
3. **Phase 3:** Add SignalR, Hangfire, Redis, caching, and background processing.
4. **Phase 4:** If the application eventually grows into a very large codebase with multiple developers, split the solution into separate projects (Domain, Application, Infrastructure, etc.) while preserving the same feature organization.
