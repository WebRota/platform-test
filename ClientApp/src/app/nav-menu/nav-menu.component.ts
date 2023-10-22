import { Component } from '@angular/core';
import { AuthService } from '../auth.service';
@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  constructor(private authService: AuthService) { }
  isAuthenticatedUser() {
    this.authService.isAuthenticatedUser();
  }
  
  isExpanded = false;
  
  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
}
