import { Component, EventEmitter, HostListener, Input, Output } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Project } from '../../core/models/project.model';

@Component({
  selector: 'app-project-modal',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './project-modal.component.html',
  styleUrl: './project-modal.component.css'
})
export class ProjectModalComponent {
  @Input() project: Project | null = null;
  @Output() close = new EventEmitter<void>();

  @HostListener('document:keydown.escape')
  handleEscape() {
    this.onClose();
  }

  onClose() {
    this.close.emit();
  }
}
