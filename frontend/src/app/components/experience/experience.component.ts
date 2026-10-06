import { Component } from '@angular/core';

interface ExperienceItem {
  role: string;
  context: string;
  type: 'DEVELOPED' | 'TESTED & DEBUGGED' | 'ENGINEERED';
  badgeClass: string;
  description: string;
  technologies: string[];
  responsibilities: string[];
}

@Component({
  selector: 'app-experience',
  standalone: true,
  templateUrl: './experience.component.html',
  styleUrl: './experience.component.css'
})
export class ExperienceComponent {
  readonly experiences: ExperienceItem[] = [
    {
      role: 'Full Stack Developer Intern',
      context: 'RBIS Technology Pvt. Ltd. | Pune, Maharashtra (Jul 2026 – Present)',
      type: 'DEVELOPED',
      badgeClass: 'badge-dev',
      description: 'Building database-driven enterprise web applications with Angular frontend, ASP.NET Web API backend services, and Entity Framework Core data layers.',
      technologies: ['Angular', 'TypeScript', 'ASP.NET Web API', 'Entity Framework Core', 'PostgreSQL', 'SQL Server', 'C#', 'Swagger'],
      responsibilities: [
        'Building responsive, modular Single Page Applications (SPA) with Angular and TypeScript on the frontend.',
        'Developing robust backend RESTful APIs using ASP.NET Web API and clean multi-tier architecture patterns.',
        'Implementing data access and business logic layers with Entity Framework Core, ensuring relational integrity and query optimization.',
        'Documenting, validating, and testing RESTful endpoints and payload contracts using Swagger OpenAPI and Postman.'
      ]
    },
    {
      role: 'Full-Stack Architecture & Engineering Showcase',
      context: 'Personal Portfolio Application (N-Tier Enterprise Architecture)',
      type: 'ENGINEERED',
      badgeClass: 'badge-test',
      description: 'Designed and engineered an enterprise-grade portfolio demonstrating decoupled 4-layer architecture with automated test coverage.',
      technologies: ['Angular 21', 'TypeScript', 'ASP.NET Core Web API', 'Entity Framework Core', 'PostgreSQL', 'xUnit', 'Moq'],
      responsibilities: [
        'Engineered decoupled layers: Presentation (Angular SPA) -> API (Controllers) -> BAL (Business Logic) -> DAL (EF Core Repositories) -> PostgreSQL.',
        'Configured Fluent API mappings for composite keys in many-to-many junction tables without leaking EF Core into domain models.',
        'Protected domain entities behind strongly-typed DTOs to enforce strict API boundary contracts.',
        'Implemented comprehensive xUnit unit tests with Moq for business service validations and negative condition testing.'
      ]
    }
  ];
}
