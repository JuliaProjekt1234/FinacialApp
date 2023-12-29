import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { AuthRequest } from "../../models/auth/auth-request.model";
import { RegistrationRequest } from "../../models/auth/registration-request.model";
import { Observable } from "rxjs";
import { AuthResponse } from "../../models/auth/auth-response.model";

@Injectable({ providedIn: 'root' })
export class AuthHttpService {
    constructor(private httpClient: HttpClient) { }

    public login(authRequest: AuthRequest): Observable<AuthResponse> {
        return this.httpClient.post("http://localhost:5002/Auth/Login", authRequest) as Observable<AuthResponse>;
    }

    public registration(registrationRequest: RegistrationRequest) {
        return this.httpClient.post("http://localhost:5002/Auth/Registration", registrationRequest);
    }

}