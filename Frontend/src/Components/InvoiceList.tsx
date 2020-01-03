import { Component } from 'react';
import axios from 'axios';
import Invoice from '../Models/Invoice';
import React from 'react';


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
        items.push(<span key={item.id}>Beleg vom: {item.LocalDate}</span>);
        }
      )

    return (
      <div>{items}</div>
    );


  }
}