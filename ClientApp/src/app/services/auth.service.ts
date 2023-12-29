import { Injectable } from "@angular/core";
import { AuthRequest } from "../models/auth/auth-request.model";
import { AuthHttpService } from "./http-services/auth-http.service";
import { AuthResponse } from "../models/auth/auth-response.model";
import { Router } from "@angular/router";
import { RegistrationRequest } from "../models/auth/registration-request.model";


@Injectable({ providedIn: 'root' })
export class AuthService {

    public get user() {
        return this.getUserFromLocalStorage();
    }

    constructor(
        private router: Router,
        private authHttpService: AuthHttpService) { }

    public login(authRequest: AuthRequest) {
        this.authHttpService.login(authRequest)
            .subscribe((authResponse: AuthResponse) => {
                this.saveUserToLocalStorage(authResponse);
                this.router.navigateByUrl('/user-dasboard');
            });
    }

    public registration(registrationRequest: RegistrationRequest) {
        this.authHttpService.registration(registrationRequest).subscribe(() => {
            this.router.navigateByUrl('/login');
        })
    }

    saveUserToLocalStorage(authResponse: AuthResponse): void {
        const userData = JSON.stringify(authResponse);
        localStorage.setItem('userData', userData);
    }

    getUserFromLocalStorage(): AuthResponse | null {
        const userData = localStorage.getItem('userData');
        return userData ? JSON.parse(userData) : null;
    }

    clearUserLocalStorage(): void {
        localStorage.removeItem('userData');
    }
}