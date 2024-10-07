import { Component, inject } from '@angular/core';
import { FormBuilder, FormControl, Validators, FormGroup, ReactiveFormsModule, ValidatorFn, AbstractControl, ValidationErrors } from '@angular/forms';
import { PasswordValidationService } from '../../services/password-validation.service';
import { CommonModule } from '@angular/common';
import { DividerModule } from 'primeng/divider';
import { PasswordModule } from 'primeng/password';
import { InputTextModule } from 'primeng/inputtext';
import { Button, ButtonModule } from 'primeng/button';
import { AuthService } from '../../services/auth.service';
import { Router } from '@angular/router';

export interface RegisterDto {
  email: string;
  password: string;
}

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule,
    DividerModule,
    PasswordModule,
    InputTextModule,
    ButtonModule,
  ],
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent {
  fb = inject(FormBuilder);
  validation = inject(PasswordValidationService);
  auth = inject(AuthService);
  router = inject(Router);

  registerForm: FormGroup = this.fb.group({
    email: new FormControl<string>('', {
      validators: [Validators.required, Validators.email],
    }),
    password: new FormControl<string>('', {
      validators: [this.validation.passwordValidator],
    }),
    confirmPassword: new FormControl<string>('', {
      validators: [Validators.required, Validators.minLength(8)],
    }),
  },
  {
    validators: this.validation.confirmPasswordValidator,
  }
);

  focusedEmail = false;
  focusedPassword = false;
  focusedConfirmPassword = false;

  get email() {
    return this.registerForm.get('email');
  }

  get password() {
    return this.registerForm.get('password');
  }

  get confirmPassword() {
    return this.registerForm.get('confirmPassword');
  }

  // Tracking validity for password suggestions
  get passwordErrors() {
    return this.password?.errors || {};
  }

  onSubmit() {    
    const registerDto: RegisterDto = {
      email: this.email?.value,
      password: this.password?.value,
    };

    return this.auth.register(registerDto).subscribe( () => {
      this.router.navigate(['/login']);
    });
  }

  changeFocusFlag(field: string) {
    switch (field) {
      case 'email':
        this.focusedEmail = !this.focusedEmail;
        break;
      case 'password':
        this.focusedPassword = !this.focusedPassword;
        break;
      case 'confirmPassword':
        this.focusedConfirmPassword = !this.focusedConfirmPassword;
        break;
    }
  }
}
