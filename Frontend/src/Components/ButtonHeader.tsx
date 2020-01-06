import { Component } from 'react';
import axios from 'axios';
import React from 'react';


export default class ButtonHeader extends Component<{}, {}>
{

    render() {
        return (
            <div>
                <button className="bg-blue-500 hover:bg-blue-500 text-white font-bold py-2 px-4 rounded-full" onClick={this.createNewEntryClicked}>+ Neuer Abrechnungstag</button>
            </div>);

    }

    createNewEntryClicked() {
        var postdata = {
            "UserId": "test123",
            "Date": "2020-01-02T00:00:00"
        };
        axios.post('https://localhost:5001/invoicecommand', postdata);
    }
}