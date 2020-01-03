
export default class Invoice {
    public userId: string;
    public date: string;
    public id: string;
    public invoiceState: Number;
    public total: Number;
  
    constructor() {
        this.id = "";
        this.userId = "";
        this.date = "";
        this.invoiceState = 0;
        this.total = 0;
    }
}