import { AbstractControl, FormControl, FormGroup, ValidationErrors, ValidatorFn, Validators } from "@angular/forms";
import { RegistrationRequest } from "./registration-request.model";
import { GetValueFromForm } from "../../shared/get-value-from-form.function";
import { GetPatternValidatorFn } from "../../shared/pattern-validator.function";

const nonAlphanumericPattern: RegExp = /[^\w\s]/;
const digitPattern: RegExp = /\d/;
const upperCasePattern: RegExp = /[A-Z]/;
const lowerCasePattern: RegExp = /[a-z]/;


export class RegistrationFormGroup extends FormGroup {

    constructor() {
        super([]);
        this.createControls();
    }

    private createControls() {
        this.addControl("userName", new FormControl("", Validators.required))
        this.addControl("password", new FormControl("", [
            Validators.required,
            Validators.minLength(6),
            this.mismatchValidationFunction("confirmPassword"),
            GetPatternValidatorFn(nonAlphanumericPattern, "requireNonAlphanumeric"),
            GetPatternValidatorFn(digitPattern, "requireNumber"),
            GetPatternValidatorFn(upperCasePattern, "requireUperCase"),
            GetPatternValidatorFn(lowerCasePattern, "requireLowerCase")]))
        this.addControl("confirmPassword", new FormControl("", [Validators.required, this.mismatchValidationFunction("password")]))
    }

    public createRegistrationRequest() {
        return new RegistrationRequest(
            GetValueFromForm(this, "userName"),
            GetValueFromForm(this, "password"),
            GetValueFromForm(this, "confirmPassword")
        )
    }

    private mismatchValidationFunction(compareControlName: string): ValidatorFn {
        return (control: AbstractControl): ValidationErrors | null => {

            if (!control?.value || !this?.controls[compareControlName]) return null;

            if (control?.value !== GetValueFromForm(this, compareControlName)) {
                const errorObj: ValidationErrors = { mismatch: true };
                this.controls[compareControlName].setErrors(errorObj);
                return errorObj;
            }

            if (this.controls[compareControlName].hasError('mismatch')) {
                this.controls[compareControlName].setErrors(null);
            }

            return null;
        };
    }
}