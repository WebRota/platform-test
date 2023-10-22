import { Component } from '@angular/core';
import { AuthService } from './auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {
  constructor(private authService: AuthService) { }
  isAuthenticatedUser() {
   var token = this.authService.getToken();
   if(token == null || token.length < 1)
        return false;
    return true;
  }
  title = 'app';
}
