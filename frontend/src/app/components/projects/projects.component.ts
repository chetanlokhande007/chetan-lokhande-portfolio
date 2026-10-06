import { Component, OnInit, inject, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProjectService } from '../../core/services/project.service';
import { Project } from '../../core/models/project.model';
import { ProjectModalComponent } from '../project-modal/project-modal.component';

@Component({
  selector: 'app-projects',
  standalone: true,
  imports: [CommonModule, ProjectModalComponent],
  templateUrl: './projects.component.html',
  styleUrl: './projects.component.css'
})
export class ProjectsComponent implements OnInit {
  private readonly projectService = inject(ProjectService);

  projects = signal<Project[]>([]);
  isLoading = signal(true);
  errorMessage = signal<string | null>(null);
  selectedProject = signal<Project | null>(null);

  /**
   * Verified projects from resume used as resilient initial state
   * or when database is empty prior to PostgreSQL seeding.
   */
  readonly verifiedResumeProjects: Project[] = [
    {
      id: 1,
      title: 'FinTrust - Fixed Deposit Management System',
      slug: 'fintrust-fd-system',
      shortDescription: 'Comprehensive Fixed Deposit management platform with N-Tier architecture, financial calculation engine, and multi-level authorization workflows.',
      description: 'Designed and developed a comprehensive Fixed Deposit management system with decoupled N-Tier architecture (Presentation, Business Access Layer, Data Access Layer) for robust financial data processing and security.\n\nKey Highlights & Engineering Decisions:\n• Built custom Financial Calculator & FD Schedule engine in C# automating complex interest calculations, maturity projections, and cash flow scheduling.\n• Developed responsive Single Page Application (SPA) using Angular and TypeScript featuring secure authentication workflows.\n• Implemented role-based approver module enabling multi-level authorization for processing Fixed Deposit requests with approval workflows.\n• Integrated Entity Framework Core for high-integrity database operations ensuring data consistency across investment records and interest transactions.',
      isFeatured: true,
      isPublished: true,
      displayOrder: 1,
      createdAt: '2026-01-15T00:00:00Z',
      technologies: [
        { id: 1, name: 'Angular', category: 'Frontend' },
        { id: 2, name: 'TypeScript', category: 'Frontend' },
        { id: 3, name: 'ASP.NET Core Web API', category: 'Backend' },
        { id: 4, name: 'C#', category: 'Language' },
        { id: 5, name: 'Entity Framework Core', category: 'Backend' },
        { id: 6, name: 'SQL Server', category: 'Database' },
        { id: 7, name: 'N-Tier Architecture', category: 'Architecture' }
      ]
    },
    {
      id: 2,
      title: 'LeaveTrack - Employee Leave & Attendance Management',
      slug: 'leavetrack-management',
      shortDescription: 'Enterprise leave application and attendance tracking platform featuring role-based access control (RBAC) and executive analytics dashboards.',
      description: 'Developed a comprehensive leave and attendance management system to streamline employee leave applications, holiday tracking, and administrative approvals for enterprise operations.\n\nKey Highlights & Engineering Decisions:\n• Designed and built responsive Single Page Application (SPA) using Angular framework with TypeScript for type-safe component development.\n• Developed robust ASP.NET Core Web API backend with clean architecture, implementing CRUD operations and leave/attendance business logic.\n• Built role-based access control (RBAC) system enabling granular permissions for employees, managers, and administrators.\n• Created interactive admin dashboards for tracking leave balances, attendance reports, and employee performance analytics.',
      isFeatured: false,
      isPublished: true,
      displayOrder: 2,
      createdAt: '2026-02-10T00:00:00Z',
      technologies: [
        { id: 1, name: 'Angular', category: 'Frontend' },
        { id: 2, name: 'TypeScript', category: 'Frontend' },
        { id: 3, name: 'ASP.NET Core Web API', category: 'Backend' },
        { id: 4, name: 'C#', category: 'Language' },
        { id: 6, name: 'SQL Server', category: 'Database' },
        { id: 8, name: 'JWT Authentication', category: 'Security' }
      ]
    },
    {
      id: 3,
      title: 'PropTrail - Property Management System',
      slug: 'proptrail-property-system',
      shortDescription: 'Full-stack property listing platform with multi-criteria filtering, Google Geolocation API integration, and administrative reporting.',
      description: 'Engineered a full-stack real estate listing platform with advanced property search and multi-criteria filtering capabilities.\n\nKey Highlights & Engineering Decisions:\n• Designed Angular frontend with responsive UI components using modern design patterns for seamless property exploration.\n• Built comprehensive REST API backend with ASP.NET Core Web API handling property CRUD operations, filtering, sorting, and pagination.\n• Implemented interactive property search with advanced filters (price range, location, amenities, property type) and Google Geolocation API integration.\n• Optimized database queries and API performance using SQL Server indexing and Entity Framework Core query optimization techniques.',
      isFeatured: false,
      isPublished: true,
      displayOrder: 3,
      createdAt: '2026-03-01T00:00:00Z',
      technologies: [
        { id: 1, name: 'Angular', category: 'Frontend' },
        { id: 2, name: 'TypeScript', category: 'Frontend' },
        { id: 3, name: 'ASP.NET Core Web API', category: 'Backend' },
        { id: 4, name: 'C#', category: 'Language' },
        { id: 6, name: 'SQL Server', category: 'Database' },
        { id: 8, name: 'JWT Authentication', category: 'Security' },
        { id: 9, name: 'Google Geolocation APIs', category: 'Integration' }
      ]
    }
  ];

  ngOnInit() {
    this.loadProjects();
  }

  loadProjects() {
    this.isLoading.set(true);
    this.errorMessage.set(null);

    this.projectService.getProjects().subscribe({
      next: (data) => {
        if (data && data.length > 0) {
          this.projects.set(data);
        } else {
          this.projects.set(this.verifiedResumeProjects);
        }
        this.isLoading.set(false);
      },
      error: () => {
        // Resilient fallback to verified projects from resume
        this.projects.set(this.verifiedResumeProjects);
        this.isLoading.set(false);
      }
    });
  }

  openDetails(project: Project) {
    this.selectedProject.set(project);
  }

  closeDetails() {
    this.selectedProject.set(null);
  }
}
