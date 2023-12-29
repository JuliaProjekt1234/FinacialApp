export class Transaction {
    constructor(
        public id: number,
        public title: string,
        public address: string,
        public amount: number,
        public transationDate: Date
    ) { }

    public static CreateDefault(): Transaction {
        return new Transaction(0, "", "", 0, new Date());
    }
}