import { Component, OnInit, inject, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TechnologyService } from '../../core/services/technology.service';
import { Technology } from '../../core/models/technology.model';

interface SkillGroup {
  category: string;
  description: string;
  skills: string[];
}

@Component({
  selector: 'app-skills',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './skills.component.html',
  styleUrl: './skills.component.css'
})
export class SkillsComponent implements OnInit {
  private readonly techService = inject(TechnologyService);
  apiTechnologies = signal<Technology[]>([]);

  readonly skillGroups: SkillGroup[] = [
    {
      category: 'Backend & Frameworks',
      description: 'Layered architectures, high-integrity APIs, and business services',
      skills: ['C#', 'ASP.NET Core', 'ASP.NET Web API', 'Entity Framework Core', 'RESTful APIs', 'MVC Architecture', 'JWT Authentication', 'N-Tier Architecture']
    },
    {
      category: 'Frontend Engineering',
      description: 'Single-Page Applications with responsive and modular UI components',
      skills: ['Angular', 'TypeScript', 'JavaScript', 'HTML5', 'CSS3', 'RxJS']
    },
    {
      category: 'Programming Languages',
      description: 'Strong foundation in object-oriented and systems programming',
      skills: ['C#', 'SQL', 'C++', 'Python', 'PHP', 'C']
    },
    {
      category: 'Databases & Storage',
      description: 'Relational data modeling, query optimization, and schema management',
      skills: ['SQL Server', 'PostgreSQL', 'MySQL', 'MongoDB', 'EF Core Migrations']
    },
    {
      category: 'Tools & Platforms',
      description: 'Development environments, API testing, and database administration tools',
      skills: ['Visual Studio 2022', 'VS Code', 'Git', 'GitHub', 'Postman', 'Swagger', 'SSMS', 'pgAdmin', 'MongoDB Compass']
    }
  ];

  ngOnInit() {
    this.techService.getTechnologies().subscribe({
      next: (techs) => this.apiTechnologies.set(techs),
      error: () => {
        // Silently preserve static profile stack if backend is offline
      }
    });
  }
}
