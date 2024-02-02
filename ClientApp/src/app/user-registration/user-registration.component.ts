import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { environment } from '../../environments/environment';

@Component({
  selector: 'app-user-registration',
  templateUrl: './user-registration.component.html',
  styleUrls: ['./user-registration.component.css']
})
export class UserRegistrationComponent {
  public newUser: User = new User(); // Adicionamos um novo usuário para o registro
  message: string = '';
  apiUrl: string = environment.apiUrl;
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, private router: Router) { }

  // Adicionamos um método para enviar o novo usuário ao servidor
  onSubmit() {
    var uri = this.apiUrl+'api/Users';
    this.http.post(uri, this.newUser).subscribe(
      response => {
        console.log('Usuário cadastrado com sucesso', response);
        this.router.navigate(['/login']);
      },
      error => {
        this.message = 'Erro ao salvar usuario.';
        console.error('Erro ao cadastrar usuário', error);
      }
    );
  }
}

class User {
  name: string = '';
  email: string = '';
  password: string = '';
  role: string = '';
  phone: string = '';
  cpf: string = '';
}
