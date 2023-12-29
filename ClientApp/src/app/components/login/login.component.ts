import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { GetValueFromForm } from '../../shared/get-value-from-form.function';
import { AuthRequest } from '../../models/auth/auth-request.model';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {

  loginForm: FormGroup = new FormGroup({});

  constructor(
    private authService: AuthService,
    private formBuilder: FormBuilder) {
    this.createForm();
  }

  public createForm() {
    this.loginForm = this.formBuilder.group({
      userName: new FormControl("", Validators.required),
      password: new FormControl("", Validators.required)
    });
  }

  public submit() {
    if (this.loginForm.invalid) return;

    var request = new AuthRequest(GetValueFromForm(this.loginForm, "userName"), GetValueFromForm(this.loginForm, "password"))
    this.authService.login(request);
  }

}
