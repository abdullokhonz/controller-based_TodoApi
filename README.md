# ASP.NET Core Web API

A simple Web API built with ASP.NET Core 8.  
This project demonstrates how to create a RESTful API using controllers, routing, and dependency injection.  
It’s based on the official Microsoft tutorial for learning the fundamentals of building APIs in .NET.

Based on the official Microsoft tutorial:  
https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-8.0&tabs=visual-studio

---

## Endpoints

GET    /api/todoitems           - Get all items  
GET    /api/todoitems/{id}      - Get item by ID  
POST   /api/todoitems           - Create new item  
PUT    /api/todoitems/{id}      - Update item by ID  
DELETE /api/todoitems/{id}      - Delete item by ID  

---

## Getting Started

1. Clone the repository:
   - git clone https://github.com/abdullokhonz/controller-based_TodoApi.git
   - cd controller-based_TodoApi

2. Restore dependencies:
   - dotnet restore

3. (Optional) Add required packages:
   - dotnet add package Microsoft.EntityFrameworkCore.InMemory
   - dotnet add package Microsoft.AspNetCore.OpenApi
   - dotnet add package Swashbuckle.AspNetCore

4. Build and run:
   - dotnet build
   - dotnet run

5. Open Swagger UI in your browser:
   - https://localhost:5001/swagger

---

## Notes

- Uses an in-memory database, so data is not persisted after restarting the app.  
- Created for educational purposes — not intended for production use.  
- You can easily replace the in-memory DB with a real database (e.g., SQLite, PostgreSQL, SQL Server).  
- Great for beginners learning ASP.NET Core Web API and Entity Framework Core.

---

## Technologies Used

- ASP.NET Core 8  
- Entity Framework Core (InMemory)  
- Swagger / OpenAPI  
- Dependency Injection  

---

## Credits

Tutorial by Microsoft Docs  
👉 ASP.NET Core Web API Tutorial:
https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-8.0&tabs=visual-studio
