# 💼 WorkWhiz – Backend

WorkWhiz is a freelance marketplace platform that connects clients with freelancers through an auction-style bidding system.  
This repository contains the backend developed with .NET 8, following a layered, clean architecture designed for scalability and maintainability.

> This backend is part of a full-stack solution.  
> You can find the frontend here 👉 [WorkWhiz Frontend](https://github.com/pipetabor/WorkWhizFront)

---

## 🚀 Key Features

- User registration and login (client and freelancer roles)
- Job posting and editing by clients
- Freelancers can place bids on active jobs
- Project status management (open, in progress, completed)
- JWT-based authentication
- Dependency injection and interface-based service architecture
- In-memory database with automatic data seeding
- API documentation via Swagger

---

## 🧰 Tech Stack

- .NET 8.0
- Entity Framework Core (InMemory)
- JWT Authentication
- Swagger / Swashbuckle
- AutoMapper
- FluentValidation
- Layered architecture (API, Core, Infrastructure)

---

## 🗂️ Project Structure

```plaintext
WorkWhiz/
├── src/
│   ├── WorkWhiz.API/             # API endpoints, DI configuration
│   ├── WorkWhiz.Core/            # Domain entities, interfaces, business logic
│   └── WorkWhiz.Infrastructure/  # Interface implementations, persistence
├── test/
│   └── WorkWhiz.UnitTest/        # Unit tests

```

This structure promotes low coupling, testability, and ease of scaling by cleanly separating concerns.

---

## 🧩 Models & Services Design

The backend is built on Clean Architecture principles, using interface-based design and dependency injection to ensure separation of concerns and modularity.

### 🧱 Main Layers

- **WorkWhiz.Core**
  - Contains **domain entities** like `User`, `Job`, and `Bid`.
  - Defines **interfaces** for services (`IJobService`, `IBidService`) and repositories (`IUserRepository`, `IJobRepository`).
  - Hosts pure business logic, independent of infrastructure.

- **WorkWhiz.Infrastructure**
  - Implements the interfaces from `Core`.
  - Manages **data persistence** using `ApiContext` with EF Core.
  - Centralize data access configuration and initial data seeding logic.

- **WorkWhiz.API**
  - Hosts **controllers** that expose RESTful endpoints.
  - Configures DI, authentication, AutoMapper, and validation.
  - Orchestrate the services defined in `Core`.

### ⚙️ Sample Flow:

```plaintext
Controller (API) 
   → Servicio (Core - IJobService)
       → Repositorio (Core - IJobRepository)
           → Implementación (Infrastructure - JobRepository)
               → Entity Framework (APIContext)

---

## ⚙️ Local Setup

1. Clone this repository:

```bash
git clone https://github.com/pipetabor/WorkWhiz.git
cd WorkWhiz/src/WorkWhiz.API
```

2. Run the API:

```bash
dotnet run
```

The API runs with an in-memory database, pre-seeded with sample data at startup and cleared on shutdown.

Swagger UI will be available at:
https://localhost:{puerto}/swagger

---

🧪 In-Memory Database & Seeding
The API uses an in-memory database during development and testing. It is seeded automatically at startup:

Program.cs...

```csharp
builder.Services.AddDbContext<ApiContext>(options =>
{
    options.UseInMemoryDatabase("WorkWhizDb");
});

using (var scope = app.Services.CreateScope())
{
    var seedService = scope.ServiceProvider.GetRequiredService<SeedDataService>();
    await seedService.SeedAsync();
}
```

---

🧱 Design Best Practices

- Dependency inversion via interfaces

- Centralized DI configuration in the startup

- Clear separation of concerns between layers

- Clean, testable, and maintainable codebase

---

📌 Project Status

✔️ MVP functional with clean architecture

🚧 Coming soon: persistent auth, notifications, job ratings

---

## 🌐 Related Project

The frontend for this platform is available at:  
🔗 [WorkWhiz Frontend](https://github.com/pipetabor/WorkWhizFront)

---

🤝 How to Contribute

- Fork the repository

- Create a new branch (git checkout -b feature/my-feature)

- Commit your changes (git commit -am 'Add new feature')

- Push the branch (git push origin feature/my-feature)

- Open a Pull Request 🚀

---

📄 License

This project is licensed under the MIT License.

---
