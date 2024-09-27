import { inject, Injectable } from '@angular/core';
import { ValidatorFn, AbstractControl, ValidationErrors } from '@angular/forms';

@Injectable({
  providedIn: 'root',
})
export class PasswordValidationService {

  passwordValidator: ValidatorFn = (
    control: AbstractControl
  ): ValidationErrors | null => {
    const password = control.value || '';

    // Regular expressions for validation
    const lowerCaseLetters = /[a-zа-я]/g;
    const upperCaseLetters = /[A-ZА-Я]/g;
    const numbers = /[0-9]/g;
    const specialChars = /[^a-zA-Z0-9]/g;

    const errors = {
      lowercase: !lowerCaseLetters.test(password),
      uppercase: !upperCaseLetters.test(password),
      number: !numbers.test(password),
      length: password.length <= 8,
      special: !specialChars.test(password),
    };
    
    const hasErrors = Object.values(errors).some(value => value === true);
    
    return hasErrors ? errors : null;

  };

  confirmPasswordValidator: ValidatorFn = (
    control: AbstractControl
  ): ValidationErrors | null => {    
    return control.value.password === control.value.confirmPassword
      ? null
      : { noMatch: true };
  };
}
