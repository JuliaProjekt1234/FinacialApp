import { Component } from '@angular/core';
import { TransactionsHttpService } from '../../services/http-services/transactions-http.service';
import { Transaction } from '../../models/transactions/transaction.model';
import { TransactionService } from '../../services/transactions.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'user-dashboard',
  templateUrl: './user-dashboard.component.html',
  styleUrl: './user-dashboard.component.scss'
})
export class UserDashboardComponent {

  public transactions$: Observable<Transaction[]> = new Observable();
  public totalAmount: number = 0;

  constructor(private transactionService: TransactionService) {
    this.transactionService.getTotalAmount().subscribe(totalAmount => this.totalAmount = totalAmount);
    this.transactionService.fetchTransactions();
    this.transactions$ = transactionService.transactions$;
  }

  delete(transactionId: number) {
    this.transactionService.deleteTransaction(transactionId)
  }
}
