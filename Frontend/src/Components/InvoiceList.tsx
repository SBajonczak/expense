import { Component } from 'react';
import axios from 'axios';
import '@grapecity/wijmo.styles/wijmo.css';

import Invoice from '../Models/Invoice';
import React from 'react';
import { FlexGrid, FlexGridColumn, FlexGridCellTemplate } from '@grapecity/wijmo.react.grid';

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
    return (
      <div className="">
        <FlexGrid itemsSource={this.state.invoices}>
          <FlexGridColumn header="Datum" binding="date" width={280} format="'DD.MM.YYYY'" />
          <FlexGridColumn header="Abrechnungssumme" binding="total" width="1*" format="n" />
          <FlexGridColumn header="" binding="" width="*">
            <FlexGridCellTemplate
              cellType="Cell"
              template={(context: any) => {
                return <React.Fragment>
                  <div>
                  <button  key={context.id} className="bg-yellow-500 hover:bg-blue-500 text-white font-bold py-2 px-4 rounded-full">Details</button>
                  </div>
                </React.Fragment>
              }}

            />
          </FlexGridColumn>
        </FlexGrid>
      </div>
    );


  }
}