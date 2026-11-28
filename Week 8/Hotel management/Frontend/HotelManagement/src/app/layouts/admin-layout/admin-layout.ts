import { Component, inject } from '@angular/core';
import { RouterLink, RouterOutlet , RouterLinkActive, Router } from '@angular/router';
import { Token } from '../../services/token';

@Component({
  imports: [RouterLink , RouterOutlet, RouterLinkActive],
  selector: 'app-admin-layout',
  styleUrl: './admin-layout.css',
  templateUrl: './admin-layout.html',
})
export class AdminLayout {
  Tokenservice = inject(Token);
  private Route = inject(Router);
  logout() : void {
    this.Tokenservice.clearSession();
    this.Route.navigate(['User-login']);
  }
}
