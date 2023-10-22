import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../auth.service';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
})
export class LoginComponent {
  email!: string;
  password!: string;
  message: string = ''; // Variável para armazenar uma mensagem a ser exibida no HTML
  private isAuthenticated: boolean = false;

  constructor(private authService: AuthService, private router: Router) { }
  // Método para navegar para a página de cadastro
  goToCadastroPage() {
    this.router.navigate(['/user-registration']); // Substitua 'cadastro' pela rota real da página de cadastro
  }
  login() {
    this.authService.login(this.email, this.password).subscribe(
      response => {
        this.message = 'Login falhou';
        if (response.token) {
          this.isAuthenticated = true;
          this.message = 'Login bem-sucedido';
          this.router.navigate(['/Map']);
        } else {
          this.isAuthenticated = false;
          this.message = 'Login falhou';
        }
      },
      error => {
        //console.error('Erro na solicitação de login:', error);
        this.message = error.error.message;
      }
    );
  }

  isAuthenticatedUser() {
    return this.isAuthenticated;
  }


}
