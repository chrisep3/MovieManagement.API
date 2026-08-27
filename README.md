# Movie Management API

A small ASP.NET Core Web API for managing a movie collection. The project demonstrates a layered Controller-Service-Repository structure, DTOs, Entity Framework Core migrations and PostgreSQL persistence.

## 🎥 Video Walkthrough

Want to see the API in action? Watch the [MovieManagement API Project Walkthrough](https://youtu.be/dgG0SLnue6w).

**Short on time?** Watch the first **4:24** for a quick introduction and hands-on application demonstration.

- [0:00 - Introduction & Project Overview](https://youtu.be/dgG0SLnue6w)
- [0:57 - Hands-on Application Demo](https://youtu.be/dgG0SLnue6w?t=57)
- [4:24 - Technical Walkthrough: Diagrams & Visual Studio](https://youtu.be/dgG0SLnue6w?t=264)

## Features

- List all movies
- Get a movie by ID
- Create a movie
- Update a movie
- Delete a movie
- Validate incoming movie data
- Seed five sample movies through EF Core migrations
- Explore and test the endpoints through Swagger

## Technologies

- .NET 8
- ASP.NET Core Web API
- Entity Framework Core
- PostgreSQL
- Swagger / OpenAPI

## Project structure

- `Controllers`: HTTP endpoints and responses
- `Application/Services`: application logic and entity-to-DTO mapping
- `Application/DTO`: request and response models
- `Infrastructure/Repositories`: database access
- `Domain`: domain entities
- `Migrations`: database schema and seed data

## Run locally

### Prerequisites

- .NET 8 SDK
- PostgreSQL
- Optional: the `dotnet-ef` CLI tool

### Setup

1. Clone the repository.
2. Copy `appsettings.Development.example.json` to `appsettings.Development.json`.
3. Replace `YOUR_USERNAME` and `YOUR_PASSWORD` with your local PostgreSQL credentials.
4. Restore dependencies and create the database:

```bash
dotnet restore
dotnet ef database update
```

5. Start the API:

```bash
dotnet run
```

6. Open `/swagger` at the local URL shown in the terminal.

## Endpoints

| Method | Endpoint | Description |
|---|---|---|
| `GET` | `/api/movies` | Return all movies |
| `GET` | `/api/movies/{id}` | Return one movie |
| `POST` | `/api/movies` | Create a movie |
| `PUT` | `/api/movies/{id}` | Update a movie |
| `DELETE` | `/api/movies/{id}` | Delete a movie |

## Notes

This is a portfolio project focused on ASP.NET Core Web API fundamentals. Authentication and a frontend client are outside its current scope.
