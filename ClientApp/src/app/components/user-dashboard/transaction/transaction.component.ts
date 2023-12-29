import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Transaction } from '../../../models/transactions/transaction.model';

@Component({
  selector: 'transaction',
  templateUrl: './transaction.component.html',
  styleUrl: './transaction.component.scss'
})
export class TransactionComponent {
  @Input() transaction: Transaction = Transaction.CreateDefault();
  @Output() onDeleted: EventEmitter<number> = new EventEmitter<number>();

  delete() {
    this.onDeleted.emit(this.transaction.id);
  }
}
