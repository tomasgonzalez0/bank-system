import React, { useState } from 'react';
import axios from 'axios';

const LoanRequest = () => {
  const [amount, setAmount] = useState('');
  const [term, setTerm] = useState('');
  const token = localStorage.getItem('token');

  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
      const response = await axios.post(
        'https://localhost:7005/api/loan/request', // 👈 tu endpoint real
        { 
          amount: parseFloat(amount), 
          term: parseInt(term, 10) 
        },
        {
          headers: { 
            Authorization: `Bearer ${token}`, 
            'Content-Type': 'application/json'
          },
        }
      );
      alert(`Préstamo solicitado exitosamente. ID: ${response.data.id}`);
    } catch (error) {
      console.error(error.response || error);
      alert('Error al solicitar préstamo');
    }
  };

  return (
    <div className="loan-request-form">
      <h2>Solicitar Préstamo</h2>
      <form onSubmit={handleSubmit}>
        <input
          type="number"
          placeholder="Monto"
          value={amount}
          onChange={(e) => setAmount(e.target.value)}
          required
        />
        <input
          type="number"
          placeholder="Plazo en meses"
          value={term}
          onChange={(e) => setTerm(e.target.value)}
          required
        />
        <button type="submit">Solicitar</button>
      </form>
    </div>
  );
};

export default LoanRequest;
