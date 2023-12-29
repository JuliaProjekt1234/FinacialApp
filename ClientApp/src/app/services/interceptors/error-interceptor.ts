import { HttpErrorResponse, HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { Observable, catchError, throwError } from "rxjs";
import { SnackBarService } from "../snack-bar.service";

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {

    constructor(private router: Router, private snackBarService: SnackBarService) { }

    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        return next.handle(request).pipe(
            catchError((error: HttpErrorResponse) => {
                if (error.status === 401) {
                    this.router.navigateByUrl('/login');
                }
                this.snackBarService.openErrorSnackBar(error.message)
                return throwError(error);
            })
        );
    }
}