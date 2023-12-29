import { Injectable } from "@angular/core";
import { Transaction } from "../models/transactions/transaction.model";
import { BehaviorSubject } from "rxjs/internal/BehaviorSubject";
import { TransactionsHttpService } from "./http-services/transactions-http.service";
import { Observable } from "rxjs";

@Injectable({ providedIn: 'root' })
export class TransactionService {

    private transactionsSubject: BehaviorSubject<Transaction[]> = new BehaviorSubject<Transaction[]>([]);
    transactions$ = this.transactionsSubject.asObservable();
    get transactions() { return this.transactionsSubject.value }

    constructor(private transactionHttpService: TransactionsHttpService) {

    }

    public fetchTransactions() {
        this.transactionHttpService.getAllTransactions().subscribe(transactions => this.transactionsSubject.next(transactions))
    }

    public deleteTransaction(transactionId: number) {
        var transactions = this.transactions.filter(transaction => transaction.id !== transactionId);
        this.transactionsSubject.next(transactions);
        this.transactionHttpService.deleteTransaction(transactionId).subscribe();
    }

    public getTotalAmount(): Observable<number> {
        return this.transactionHttpService.getTotalAmount();
    }
}