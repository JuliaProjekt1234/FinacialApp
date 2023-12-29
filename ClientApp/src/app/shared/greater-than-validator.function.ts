import { AbstractControl, ValidationErrors } from "@angular/forms";

export function GreaterThanValidator(value: number) {
    return (control: AbstractControl): ValidationErrors | null => {
        if (!control) return null;

        if (+control.value <= value) {
            return { greatenThan: true };
        }

        return null;
    }
}