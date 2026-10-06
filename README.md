# Chetan Portfolio

A professional, full-stack personal portfolio and software engineering showcase built with **Angular 21**, **ASP.NET Core Web API (.NET 8)**, **Entity Framework Core**, and **PostgreSQL**.

---

## Overview

This repository contains the complete source code for Chetan Shantaram Lokhande's developer portfolio application. Built as a real software product rather than a static template, the system demonstrates an end-to-end decoupled **N-Tier Architecture**:
- An **Angular 21 SPA** on the frontend consuming RESTful endpoints.
- A layered **ASP.NET Core Web API** backend separating API controllers, business logic, and database access.
- **Entity Framework Core** with Code-First migrations managing relational data models in **PostgreSQL**.
- Automated unit test suites covering business rules and frontend components.

---

## Features

- **Layered N-Tier Architecture**: Decoupled presentation, API gateway, business services, and data repositories.
- **RESTful API Service**: CRUD operations for projects, technology tags, and case-study metadata.
- **Interactive Engineering Showcase**: Project cards displaying problem statements, architecture flows, and technology tags.
- **Fluent API Data Modeling**: Composite primary keys for many-to-many relationships without leaking EF Core abstractions into domain entities.
- **Resilient Frontend State Management**: Dynamic data fetching via Angular Signals with graceful fallback to verified profile data.
- **Responsive & Accessible Design**: Mobile navigation drawer, WCAG-compliant color contrast, and zero layout shift.
- **Comprehensive Testing**: xUnit and Moq unit tests for backend business services; Vitest/Angular TestBed for frontend components.

---

## Technology Stack

### Frontend
- **Framework**: Angular 21 (Standalone Components)
- **Language**: TypeScript
- **Styling**: Vanilla CSS with customized design tokens
- **HTTP Client**: Angular `provideHttpClient` with `withFetch`
- **Testing**: Vitest & Angular TestBed

### Backend
- **Framework**: ASP.NET Core Web API (.NET 8)
- **Language**: C# 12
- **Architecture**: N-Tier (API &rarr; BAL &rarr; DAL &rarr; Model)
- **Testing**: xUnit, Moq
- **API Documentation**: Swagger / OpenAPI (Swashbuckle)

### Database & ORM
- **Database**: PostgreSQL
- **ORM**: Entity Framework Core 9 (`Npgsql.EntityFrameworkCore.PostgreSQL`)
- **Schema Management**: EF Core Migrations (Code-First)

---

## Architecture

```text
Browser / Client
       │
       ▼
[ Frontend: Angular 21 SPA ]
       │
       │ HTTP / REST (JSON)
       ▼
[ Portfolio.API (Controllers & DTOs) ]
       │
       │ Dependency Injection
       ▼
[ Portfolio.BAL (Business Access Layer) ]
       │
       │ Service Contracts & Validation
       ▼
[ Portfolio.DAL (Data Access Layer & Repositories) ]
       │
       │ EF Core / Npgsql
       ▼
[ PostgreSQL Database ]
```

---

## Project Structure

```text
Portflio/
├── backend/
│   ├── Portfolio.API/          # ASP.NET Core Web API controllers & startup configuration
│   ├── Portfolio.BAL/          # Business logic services and validation rules
│   ├── Portfolio.DAL/          # EF Core DbContext, repositories, and migrations
│   ├── Portfolio.Model/        # Domain entities and strongly-typed DTOs
│   ├── Portfolio.Tests/        # xUnit unit test suite with Moq
│   └── Portfolio.slnx          # Visual Studio solution file
├── frontend/
│   ├── src/
│   │   ├── app/
│   │   │   ├── components/     # Standalone Angular components (navbar, hero, about, skills, projects, etc.)
│   │   │   ├── core/           # HTTP services and TypeScript data models
│   │   │   ├── app.html        # Main application layout
│   │   │   ├── app.ts          # Root component
│   │   │   └── app.css         # Global tokens and design system
│   │   ├── environments/       # Environment configuration (API base URLs)
│   │   └── index.html          # Application entrypoint
│   ├── public/                 # Static assets (profile photo, resume PDF)
│   ├── package.json            # Node.js dependencies and scripts
│   └── tsconfig.json           # TypeScript configuration
├── .gitignore                  # Git ignore rules for .NET, Node, and environments
└── README.md                   # Project documentation
```

---

## Prerequisites

Ensure the following runtimes are installed on your system:
- **.NET SDK**: 8.0 or 9.0 (`dotnet --version`)
- **Node.js**: v18+ or v20+ (`node --version`)
- **npm**: v9+ (`npm --version`)
- **PostgreSQL**: v14+ running locally or in Docker

---

## Local Setup

### 1. Clone Repository
```bash
git clone https://github.com/chetanlokhande007/chetan-lokhande-portfolio.git
cd chetan-lokhande-portfolio
```

### 2. Backend Setup
```bash
cd backend

# Restore NuGet dependencies
dotnet restore Portfolio.slnx

# Build the solution
dotnet build Portfolio.slnx

# Run automated tests
dotnet test Portfolio.slnx
```

### 3. Database Configuration
1. Open `backend/Portfolio.API/appsettings.json` (or copy from `appsettings.Example.json`).
2. Configure your local PostgreSQL connection string:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=5432;Database=portfolio_db;Username=YOUR_POSTGRES_USER;Password=YOUR_POSTGRES_PASSWORD"
  }
}
```
3. Apply existing database migrations:
```bash
dotnet ef database update --project Portfolio.DAL --startup-project Portfolio.API
```

### 4. Frontend Setup
```bash
cd ../frontend

# Install dependencies
npm install

# Run frontend tests
npm test -- --watch=false

# Build production bundle
npm run build
```

---

## Running the Application

### Start the Backend API
```bash
cd backend/Portfolio.API
dotnet run --launch-profile http
```
The API will start at `http://localhost:5118`. Access Swagger API docs at `http://localhost:5118/swagger`.

### Start the Frontend Dev Server
```bash
cd frontend
npm start
```
The Angular application will be available at `http://localhost:4200`.

---

## API Documentation

When the backend is running in Development mode, Swagger UI is available at:
```text
http://localhost:5118/swagger
```
Key endpoints:
- `GET /api/projects`: Retrieve published projects and associated technologies.
- `GET /api/projects/{id}`: Retrieve single project details by numeric ID.
- `GET /api/projects/{slug}`: Retrieve single project details by URL slug.
- `GET /api/technologies`: Retrieve list of technologies grouped by category.

---

## Testing

- **Backend Tests**: Located in `backend/Portfolio.Tests/`. Uses **xUnit** and **Moq** to test business layer validations, error boundaries, and repository interactions.
  ```bash
  dotnet test backend/Portfolio.slnx
  ```
- **Frontend Tests**: Located in `frontend/src/app/`. Uses **Vitest** with Angular's `TestBed`.
  ```bash
  cd frontend && npm test -- --watch=false
  ```
