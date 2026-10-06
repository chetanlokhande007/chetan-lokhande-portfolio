# Chetan Shantaram Lokhande — Full Stack Developer Portfolio

A production-style personal developer portfolio application engineered with an **Angular 21** frontend and an **ASP.NET Core Web API** backend adhering to **N-Tier Architecture** and clean separation of concerns, backed by **Entity Framework Core** and **PostgreSQL**.

---

## Overview

This repository contains the full-stack source code for Chetan Shantaram Lokhande's personal engineering portfolio. The project demonstrates real-world software architecture practices:
- **Presentation Layer (Frontend)**: Angular 21 Single Page Application with standalone components, type-safe models, responsive CSS design tokens, and graceful API state management.
- **API Gateway Layer**: ASP.NET Core Web API exposing RESTful endpoints, DTO validation, and Swagger OpenAPI documentation.
- **Business Access Layer (BAL)**: Decoupled service contracts, business validations, and domain logic.
- **Data Access Layer (DAL)**: Entity Framework Core repositories with Fluent API mappings, composite primary keys, and PostgreSQL database migrations.
- **Testing Layer**: Automated xUnit and Moq unit test suites for business services and Vitest/Angular TestBed suites for frontend components.

---

## Features

- **Decoupled N-Tier Architecture**: Clean architectural boundaries between presentation (`frontend`), API (`Portfolio.API`), business rules (`Portfolio.BAL`), and data storage (`Portfolio.DAL`).
- **RESTful Endpoints**: Live data delivery for projects, technology categories, and architectural case studies.
- **Relational Integrity**: Entity Framework Core with Code-First migrations, junction tables with composite keys, and entity-to-DTO abstraction to avoid leaking internal database structures.
- **Interactive Engineering Case Studies**: Project cards with architecture flows, problem statements, and technology stacks (FinTrust, LeaveTrack, PropTrail).
- **Resilient Client Architecture**: Angular signals for reactive state, error boundaries, and fallback rendering ensuring zero broken UI states.
- **Clean Responsive Design**: Custom dark-mode UI with high color contrast, smooth drawer navigation for mobile devices, and WCAG accessibility compliance.
- **Downloadable Resume & Profile**: Embedded verified resume and authentic profile portrait.

---

## Technology Stack

### Frontend
- **Framework**: Angular 21 (Standalone Components)
- **Language**: TypeScript
- **Styling**: Vanilla CSS Design Tokens (Responsive, Zero Heavy Frameworks)
- **HTTP Client**: Angular `provideHttpClient` with `withFetch`
- **Testing**: Vitest & Angular TestBed

### Backend
- **Framework**: ASP.NET Core Web API (.NET 8)
- **Language**: C# 12
- **Architecture**: Multi-Tier / N-Tier (`Portfolio.API` &rarr; `Portfolio.BAL` &rarr; `Portfolio.DAL` &rarr; `Portfolio.Model`)
- **API Documentation**: Swagger / OpenAPI (Swashbuckle)
- **Testing**: xUnit, Moq

### Database & ORM
- **Database**: PostgreSQL
- **ORM**: Entity Framework Core 9 (`Npgsql.EntityFrameworkCore.PostgreSQL`)
- **Schema Management**: EF Core Migrations (Code-First)

---

## Architecture Flow

```text
Browser / Client (Desktop & Mobile)
       │
       ▼
[ Frontend: Angular 21 Single Page App ]
       │
       │ HTTP / REST (JSON)
       ▼
[ Backend: Portfolio.API (Controllers & DTOs) ]
       │
       │ Dependency Injection
       ▼
[ Business Access Layer: Portfolio.BAL (Services & Validation) ]
       │
       │ Interface Contracts
       ▼
[ Data Access Layer: Portfolio.DAL (Repositories & EF Core) ]
       │
       │ Npgsql ORM
       ▼
[ Relational Database: PostgreSQL ]
```

---

## Project Structure

```text
Portflio/
├── backend/
│   ├── Portfolio.API/              # ASP.NET Core Web API controllers & startup configuration
│   ├── Portfolio.BAL/              # Business logic services and validation rules
│   ├── Portfolio.DAL/              # EF Core DbContext, repositories, and migrations
│   │   └── Migrations/             # Code-First database migration history and snapshot
│   ├── Portfolio.Model/            # Domain entities and strongly-typed DTOs
│   ├── Portfolio.Tests/            # xUnit & Moq automated test suite
│   └── Portfolio.slnx              # Visual Studio solution file
├── frontend/
│   ├── src/
│   │   ├── app/
│   │   │   ├── components/         # Standalone Angular components (navbar, hero, about,
│   │   │   │                       # skills, projects, modal, experience, education, contact, footer)
│   │   │   ├── core/               # HTTP client services and TypeScript models
│   │   │   ├── app.html            # Main application layout
│   │   │   ├── app.ts              # Root standalone component
│   │   │   └── app.css             # Root component styling
│   │   ├── environments/           # Environment configuration (API base URL)
│   │   ├── index.html              # HTML entrypoint
│   │   └── styles.css              # Global design system tokens and resets
│   ├── public/                     # Static assets (profile photo, resume PDF, favicon)
│   ├── package.json                # Frontend dependencies and npm scripts
│   └── tsconfig.json               # TypeScript compiler configuration
├── .gitignore                      # Git exclusion rules for .NET, Node, and environments
└── README.md                       # Repository documentation
```

---

## Prerequisites

Before running the application locally, ensure you have installed:
- **.NET SDK**: Version 8.0 or 9.0 (`dotnet --version`)
- **Node.js**: Version 18.x or 20.x+ (`node --version`)
- **npm**: Version 9.x+ (`npm --version`)
- **PostgreSQL**: Version 14+ running locally or via Docker

---

## Local Setup

### 1. Clone the Repository
```bash
git clone https://github.com/chetanlokhande007/chetan-lokhande-portfolio.git
cd chetan-lokhande-portfolio
```

### 2. Backend Setup
Navigate to the backend directory:
```bash
cd backend

# Restore NuGet packages
dotnet restore Portfolio.slnx

# Build the solution
dotnet build Portfolio.slnx

# Run automated tests
dotnet test Portfolio.slnx
```

### 3. Database Configuration
1. Open `backend/Portfolio.API/appsettings.json` (or reference `appsettings.example.json`).
2. Configure your PostgreSQL connection string:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=5432;Database=portfolio_db;Username=YOUR_USERNAME;Password=YOUR_PASSWORD"
  }
}
```
3. Apply existing database migrations:
```bash
dotnet ef database update --project Portfolio.DAL --startup-project Portfolio.API
```

### 4. Frontend Setup
Navigate to the frontend directory:
```bash
cd ../frontend

# Install dependencies
npm install

# Build the application
npm run build

# Run unit tests
npm test -- --watch=false
```

---

## Running the Application

### Start the Backend API
```bash
cd backend/Portfolio.API
dotnet run --launch-profile http
```
The API starts at `http://localhost:5118`. Access Swagger OpenAPI documentation at `http://localhost:5118/swagger`.

### Start the Frontend Dev Server
```bash
cd frontend
npm start
```
The Angular application will launch at `http://localhost:4200`.

---

## API Endpoints

| Method | Endpoint | Description |
| :--- | :--- | :--- |
| `GET` | `/api/projects` | Retrieves list of all published projects with technologies |
| `GET` | `/api/projects/{id}` | Retrieves a project by numeric ID |
| `GET` | `/api/projects/{slug}` | Retrieves a project by unique URL slug |
| `POST` | `/api/projects` | Creates a new project with associated technologies |
| `PUT` | `/api/projects/{id}` | Updates an existing project |
| `DELETE` | `/api/projects/{id}` | Removes a project |
| `GET` | `/api/technologies` | Retrieves all technologies |
| `GET` | `/api/technologies/{id}` | Retrieves a technology by ID |

---

## Testing

### Backend Unit Tests
The test project `Portfolio.Tests` uses **xUnit** and **Moq** to test business access layer services without touching a live database:
```bash
cd backend
dotnet test Portfolio.slnx
```

### Frontend Unit Tests
Frontend unit testing uses **Vitest** with Angular's `TestBed`:
```bash
cd frontend
npm test -- --watch=false
```
