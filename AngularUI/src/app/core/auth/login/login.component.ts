import { CommonModule } from '@angular/common';
import { Component, inject } from '@angular/core';
import { FormBuilder, FormControl, ReactiveFormsModule, Validators } from '@angular/forms';
import { ButtonModule } from 'primeng/button';
import { CardModule } from 'primeng/card';
import { CheckboxModule } from 'primeng/checkbox';
import { InputTextModule } from 'primeng/inputtext';
import { PasswordModule } from 'primeng/password';
import { RippleModule } from 'primeng/ripple';
import { StyleClassModule } from 'primeng/styleclass';
import { AuthService } from '../services/auth.service';
import { Router } from '@angular/router';

export interface LoginDto {
  email: string | null | undefined;
  password: string | null | undefined;
}

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [
    CommonModule,
    StyleClassModule,
    CheckboxModule,
    CardModule,
    ButtonModule,
    RippleModule,
    InputTextModule,
    ReactiveFormsModule,
    PasswordModule

  ],
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss'
})
export class LoginComponent {
  fb = inject(FormBuilder);
  auth = inject(AuthService);
  router = inject(Router);

  loginForm = this.fb.group({
    email: new FormControl<string>('', [Validators.required, Validators.email]),
    password: new FormControl<string>('', [Validators.required])
  });

  get email() {
    return this.loginForm.get('email');
  }

  get password() {
    return this.loginForm.get('password');
  }

  onSubmit() {
    const loginDto: LoginDto = {
      email: this.email?.value,
      password: this.password?.value
    }
    this.auth.login(loginDto).subscribe(() => {
        this.router.navigate(['/']);
      }
    );
  }

}
