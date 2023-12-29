import { AbstractControl, ValidationErrors } from "@angular/forms";

export function GetPatternValidatorFn(pattern: RegExp, errorName: string) {
    return (control: AbstractControl): ValidationErrors | null => {
        if (!control) return null;

        if (!pattern.test(control.value)) {
            const errorObj: ValidationErrors = {};
            errorObj[errorName] = true;
            return errorObj;
        }

        return null;
    }
}