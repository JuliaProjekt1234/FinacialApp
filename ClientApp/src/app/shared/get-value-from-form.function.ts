import { FormGroup } from "@angular/forms";

export function GetValueFromForm(formGroup: FormGroup, controlName: string) {
    return formGroup.controls[controlName].value;
}