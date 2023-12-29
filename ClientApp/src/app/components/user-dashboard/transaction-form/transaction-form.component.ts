import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { TransactionToAdd } from '../../../models/transactions/transaction-to-add.model';
import { GetValueFromForm } from '../../../shared/get-value-from-form.function';
import { TransactionsHttpService } from '../../../services/http-services/transactions-http.service';
import { Router } from '@angular/router';
import { GreaterThanValidator } from '../../../shared/greater-than-validator.function';

@Component({
  selector: 'app-transaction-form',
  templateUrl: './transaction-form.component.html',
  styleUrl: './transaction-form.component.scss'
})
export class TransactionFormComponent {

  transactionForm: FormGroup = new FormGroup({});

  constructor(
    private router: Router,
    private formBuilder: FormBuilder,
    private transactionsHttpService: TransactionsHttpService
  ) {
    this.createForm();
  }

  public createForm() {
    this.transactionForm = this.formBuilder.group({
      title: new FormControl("", [Validators.required, Validators.maxLength(40)]),
      address: new FormControl("", Validators.required),
      amount: new FormControl("", [Validators.required, GreaterThanValidator(0)])
    });
  }

  public submit() {
    if (this.transactionForm.invalid) return;

    var transaction = new TransactionToAdd(
      GetValueFromForm(this.transactionForm, "title"),
      GetValueFromForm(this.transactionForm, "address"),
      +GetValueFromForm(this.transactionForm, "amount"))

    this.transactionsHttpService.addTransaction(transaction).subscribe(() => this.router.navigateByUrl("/user-dasboard"));
  }
}
