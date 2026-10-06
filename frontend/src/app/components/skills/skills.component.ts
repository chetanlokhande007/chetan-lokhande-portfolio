import { Component, OnInit, inject, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TechnologyService } from '../../core/services/technology.service';
import { Technology } from '../../core/models/technology.model';

export interface SkillCategoryCard {
  title: string;
  technologies: string;
  colorClass: string;
  iconType: 'frontend' | 'backend' | 'database' | 'cloud' | 'tools' | 'other';
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

  readonly skillCards: SkillCategoryCard[] = [
    {
      title: 'Frontend',
      technologies: 'Angular, React, TypeScript, HTML, CSS, JavaScript, Vite',
      colorClass: 'color-blue',
      iconType: 'frontend'
    },
    {
      title: 'Backend',
      technologies: 'ASP.NET Core, C#, REST APIs, Entity Framework Core',
      colorClass: 'color-green',
      iconType: 'backend'
    },
    {
      title: 'Database',
      technologies: 'PostgreSQL, SQL Server, MySQL',
      colorClass: 'color-purple',
      iconType: 'database'
    },
    {
      title: 'Cloud & DevOps',
      technologies: 'Azure, Git, GitHub',
      colorClass: 'color-orange',
      iconType: 'cloud'
    },
    {
      title: 'Tools',
      technologies: 'Visual Studio, VS Code, Postman, Swagger',
      colorClass: 'color-pink',
      iconType: 'tools'
    },
    {
      title: 'Other',
      technologies: 'Twilio, Authentication, API Integration, N-Tier Architecture',
      colorClass: 'color-teal',
      iconType: 'other'
    }
  ];

  ngOnInit() {
    this.techService.getTechnologies().subscribe({
      next: (techs) => this.apiTechnologies.set(techs),
      error: () => {
        // Silently preserve verified profile stack if backend is offline
      }
    });
  }
}
