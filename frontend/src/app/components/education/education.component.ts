import { Component } from '@angular/core';

interface EducationItem {
  degree: string;
  institution: string;
  location?: string;
  year: string;
  grade?: string;
  highlight?: string;
  isOngoing?: boolean;
}

@Component({
  selector: 'app-education',
  standalone: true,
  templateUrl: './education.component.html',
  styleUrl: './education.component.css'
})
export class EducationComponent {
  readonly educationList: EducationItem[] = [
    {
      degree: 'Master of Computer Application (MCA)',
      institution: 'School of Computer Science, Kavayitri Bahinabai Chaudhari North Maharashtra University',
      location: 'Jalgaon, Maharashtra',
      year: 'Pursuing',
      highlight: 'Advanced computing, distributed software architectures, and database engineering.',
      isOngoing: true
    },
    {
      degree: 'B.Sc. (Computer Science)',
      institution: 'School of Computer Sciences (SOCS), North Maharashtra University',
      year: '2023 - 2026',
      grade: 'CGPA: 9.21',
      highlight: 'Core computer science fundamentals: Data Structures, Algorithms, DBMS, OOP (C++, C#, Java), and Web Technologies.'
    },
    {
      degree: 'Higher Secondary Certificate (Class XII)',
      institution: 'J.E. School and Jr. College',
      location: 'Muktainagar, Maharashtra',
      year: '2023',
      grade: '77.33%',
      highlight: 'Science stream with Mathematics & Physics foundation.'
    },
    {
      degree: 'Secondary School Certificate (Class X)',
      institution: 'M.M. Narkhede Vidhyalay',
      location: 'Ruiakhede, Maharashtra',
      year: 'Passout',
      grade: '91.60%',
      highlight: 'Top academic performance distinction.'
    }
  ];
}
