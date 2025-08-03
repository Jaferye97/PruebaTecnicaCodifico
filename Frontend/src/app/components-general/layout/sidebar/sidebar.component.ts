import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatListModule } from '@angular/material/list';
import { MatIconModule } from '@angular/material/icon';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-sidebar',
  standalone: true,
  imports: [MatListModule, MatIconModule, RouterModule, CommonModule],
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.css'],
})
export class SidebarComponent {
  activeSection: string | null = null;

  menu = [
    {
      title: 'Formulario',
      key: 'formulario',
      icon: 'storage',
      items: [
        { title: 'Login', key: 'login', route: 'formulario/', icon: 'storage' },
      ],
    },
  ];

  toggleSection(key: string) {
    this.activeSection = this.activeSection === key ? null : key;
  }
}
