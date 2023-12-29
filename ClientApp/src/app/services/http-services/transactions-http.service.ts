import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { TransactionToAdd } from "../../models/transactions/transaction-to-add.model";
import { Observable } from "rxjs";
import { Transaction } from "../../models/transactions/transaction.model";

@Injectable({providedIn: 'root'})
export class TransactionsHttpService{
    constructor(private httpClient: HttpClient){

    }

    public getAllTransactions():Observable<Transaction[]>{
        return this.httpClient.get("http://localhost:5002/Transactions/GetAll") as Observable<Transaction[]>;
    }

    public deleteTransaction(transactionId:number){
        return this.httpClient.delete(`http://localhost:5002/Transactions/Delete/${transactionId}`);
    }

    public addTransaction(transaction: TransactionToAdd){
        return this.httpClient.post("http://localhost:5002/Transactions/Add", transaction);
    }

    public getTotalAmount(): Observable<number>{
        return this.httpClient.get("http://localhost:5002/Transactions/GetTotalAmount") as Observable<number>;
    }
}