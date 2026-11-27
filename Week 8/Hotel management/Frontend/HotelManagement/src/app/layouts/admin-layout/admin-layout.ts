import { Component } from '@angular/core';
import { RouterLink, RouterOutlet , RouterLinkActive } from '@angular/router';

@Component({
  imports: [RouterLink , RouterOutlet, RouterLinkActive],
  selector: 'app-admin-layout',
  styleUrl: './admin-layout.css',
  templateUrl: './admin-layout.html',
})
export class AdminLayout {}
