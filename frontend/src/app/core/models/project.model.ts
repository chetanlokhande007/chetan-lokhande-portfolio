import { Technology } from './technology.model';

export interface Project {
  id: number;
  title: string;
  slug: string;
  shortDescription: string;
  description: string;
  githubUrl?: string | null;
  liveUrl?: string | null;
  imageUrl?: string | null;
  isFeatured: boolean;
  isPublished: boolean;
  displayOrder: number;
  createdAt: string;
  updatedAt?: string | null;
  technologies: Technology[];
}
