import React from 'react';
import logo from './logo.svg';
import InvoiceList from './Components/InvoiceList';
import ButtonHeader  from './Components/ButtonHeader';

const App: React.FC = () => {
  return (
    <div className="m-auto antialiased font-sans font-serif font-mono">
      <header className="min-h-screen flex flex-col text-2xl">
        <ButtonHeader></ButtonHeader>
        <InvoiceList></InvoiceList>
      </header>
    </div>
  );
}

export default App;