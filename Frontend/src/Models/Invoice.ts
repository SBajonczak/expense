import moment from 'momentjs';
import { mockComponent } from 'react-dom/test-utils';

export default class Invoice {
    public userId: string;
    public date: string;
    public id: string;
    public invoiceState: Number;
    public total: Number;
    public LocalDate() {
        get: {
           
            let m = new moment(this.date);
            if (m.isValid()) {
                return m.format("DD.MM.YYYY");
            }
            return "#INvalid#";
        }
    }
    constructor() {
        this.id = "";
        this.userId = "";
        this.date = "";
        this.invoiceState = 0;
        this.total = 0;
    }
}