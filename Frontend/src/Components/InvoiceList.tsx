import { Component } from 'react';
import axios from 'axios';
import Invoice from '../Models/Invoice';
import React from 'react';
import Moment from 'react-moment';

interface State {
  invoices: Invoice[]
}
export default class InvoiceList extends Component<{}, State> {

  constructor() {
    super({});
    this.state = ({ invoices: [] })
  }
  componentWillMount() {
    axios.get('https://localhost:5001/invoice/?username=test123', {
      headers: {
        'Access-Control-Allow-Origin': '*',
      },
    }).then(data => {
      this.setState({ invoices: data.data })


    });
  }
  render() {
    console.log(this.state.invoices);
    const items: any[] = [];
    this.state.invoices
      .forEach((item: Invoice) => {
        items.push(
          <div className="flex mb-4" key={item.id}>
            <div className="w-1/3 bg-gray-400 h-12"><Moment format="DD.MM.YYYY">{item.date}</Moment></div>
            <div className="w-1/3 bg-gray-500 h-12">{item.userId}</div>
            <div className="w-1/3 bg-gray-400 h-12">{item.invoiceState}</div>
          </div>
        );
      }
      )

    return (
      <div>{items}</div>
    );


  }
}