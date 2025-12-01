The Customer Management System API is a backend application built using ASP.NET Core Web API with Clean Architecture / Onion Architecture principles.
It provides a structured and scalable solution to manage customer records using Entity Framework Core and SQL Server.

Short Summary:
“Developed a Customer Management Web API using ASP.NET Core and Clean Architecture implementing CRUD operations, layered architecture, repository pattern, and EF Core Code-First approach. The API manages customer details and provides scalable, maintainable, and testable backend services with SQL Server integration and Swagger documentation.”

The system is divided into four layers:

API Layer – Handles HTTP requests and exposes REST endpoints

Application Layer – Contains business logic, services, and interfaces

Domain Layer – Defines core entities and business rules

Infrastructure Layer – Manages data access using EF Core and repositories

The project ensures high maintainability, testability, performance, and separation of concerns, which makes it suitable for real-world enterprise-grade applications.

🚀 Core Functionalities (What the System Does)

1️⃣ Add New Customer

Users can create a new customer record.

The API receives customer details (Name, Email, Phone, Address).

Data is validated, processed, and stored into the database.

Returns status + created customer details.

2️⃣ View All Customers

Fetch all customer records from the database.

Useful for displaying a customer list in any frontend (React, Angular, MVC, etc).

Supports clean DTO output for secure data transfer.

3️⃣ View Customer Details (By ID)

Get a single customer’s information using its unique ID.

Useful to show profile details or to pre-fill update forms.

4️⃣ Update Customer

Users can update any customer details.

API checks if customer exists → modifies → saves → returns updated data.

5️⃣ Delete Customer

Remove a customer record permanently from the database.

Validates existence → performs deletion → returns confirmation message.

🧠 How the System Works (Logical Flow)
👉 When a request hits the API:

API Controller accepts request

Sends data to Application Layer Services

Services call Repository Interfaces

Infrastructure Layer executes DB operations using EF Core

Response is returned back to the user

This makes the entire system:

✔ Clean

✔ Extensible

✔ Easy to test

✔ Easy to integrate with frontend


🔧 Additional Technical Features

✔ Clean Architecture (Separation of Concerns)

Each layer has a specific responsibility.
The Domain never depends on Infrastructure → promotes scalability.

✔ Repository Pattern

Database operations are abstracted using interfaces → easy to replace SQL with MongoDB, PostgreSQL, etc.

✔ EF Core Code First

Database tables are generated automatically from entity classes.

✔ Dependency Injection

All services and repositories are injected → improves testability and loose coupling.

✔ Swagger UI

API is fully testable using Swagger without writing separate UI.




📄 High-Level Purpose of the Project

The main purpose of this project is to:

Build a robust backend API for customer management

Implement real-world engineering patterns like Clean Architecture

Provide a base structure where additional modules (Orders, Billing, Authentication) can be added easily

Learn professional-level architecture used in industry



OUTPUT:
<img width="1599" height="743" alt="image" src="https://github.com/user-attachments/assets/39dfa496-41da-403e-b5d5-a2496472720d" />

<img width="1599" height="862" alt="image" src="https://github.com/user-attachments/assets/c0819e5f-3322-42c5-a581-a44ac40744ff" />

