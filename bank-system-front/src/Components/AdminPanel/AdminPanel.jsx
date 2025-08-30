import React, { useState, useEffect } from 'react';
import axios from 'axios';

const AdminPanel = () => {
  const [loans, setLoans] = useState([]);
  const token = localStorage.getItem('token');

  useEffect(() => {
    const fetchLoans = async () => {
      try {
        const response = await axios.get('https://localhost:7005/api/loan', {
          headers: { Authorization: `Bearer ${token}` },
        });
        setLoans(response.data);
      } catch (error) {
        console.error(error);
        alert('Error al cargar los préstamos');
      }
    };

    fetchLoans();
  }, [token]);

  const handleApprove = async (id) => {
    try {
      await axios.put(
        `https://localhost:7005/api/loan/approve/${id}`,
        {},
        {
          headers: { Authorization: `Bearer ${token}` },
        }
      );
      alert('Préstamo aprobado');
      setLoans(loans.map(l => l.id === id ? { ...l, status: 'Aprobado' } : l));
    } catch (error) {
      console.error(error);
      alert('Error al aprobar préstamo');
    }
  };

  const handleReject = async (id) => {
    try {
      await axios.put(
        `https://localhost:7005/api/loan/reject/${id}`,
        {},
        {
          headers: { Authorization: `Bearer ${token}` },
        }
      );
      alert('Préstamo rechazado');
      setLoans(loans.map(l => l.id === id ? { ...l, status: 'Rechazado' } : l));
    } catch (error) {
      console.error(error);
      alert('Error al rechazar préstamo');
    }
  };

  return (
    <div className="admin-panel">
      <h2>Panel de Administrador</h2>
      {loans.length === 0 ? (
        <p>No hay solicitudes pendientes</p>
      ) : (
        <ul>
          {loans.map((loan) => (
            <li key={loan.id}>
              <p>
                <strong>Monto:</strong> {loan.amount} | 
                <strong> Plazo:</strong> {loan.term} meses | 
                <strong> Estado:</strong> {loan.status}
              </p>
             
                <>
                  <button onClick={() => handleApprove(loan.id)}>✅ Aprobar</button>
                  <button onClick={() => handleReject(loan.id)}>❌ Rechazar</button>
                </>
    
            </li>
          ))}
        </ul>
      )}
    </div>
  );
};

export default AdminPanel;
