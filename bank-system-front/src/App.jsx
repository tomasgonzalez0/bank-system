import React from 'react';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom'; // Reemplazado Switch por Routes
import Login from './Components/Login/Login';
import LoanRequest from './Components/LoanRequest/LoanRequest';
import AdminPanel from './Components/AdminPanel/AdminPanel';

const App = () => {
  return (
    <Router>
      <Routes>
        <Route path="/" element={<Login />} />
        <Route path="/loan-request" element={<LoanRequest />} />
        <Route path="/admin-panel" element={<AdminPanel />} />
      </Routes>
    </Router>
  );
};

export default App;
