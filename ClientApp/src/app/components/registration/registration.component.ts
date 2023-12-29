import { Component } from '@angular/core';
import { RegistrationFormGroup } from '../../models/auth/registration-form.model';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'registration',
  templateUrl: './registration.component.html',
  styleUrl: './registration.component.scss'
})
export class RegistrationComponent {

  registrationForm: RegistrationFormGroup = new RegistrationFormGroup();

  constructor(
    private authService: AuthService,
  ) {
  }

  submit() {
    if (this.registrationForm.invalid) return;

    var registrationRequest = this.registrationForm.createRegistrationRequest();
    this.authService.registration(registrationRequest);
  }
}
