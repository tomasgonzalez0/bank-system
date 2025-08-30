import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom'; 
import axios from 'axios';

const Login = () => {
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const [loading, setLoading] = useState(false);
  const navigate = useNavigate();

  const handleSubmit = async (e) => {
    e.preventDefault();
    setLoading(true);
    try {
      const response = await axios.post("https://localhost:7005/api/auth/login", { 
        email, 
        password 
      });

      localStorage.setItem("token", response.data.token);

      localStorage.setItem("role", response.data.role);

      if (response.data.role === "Admin") {
        navigate("/admin-panel");
      } else {
        navigate("/loan-request");
      }
    } catch (error) {
      alert("Credenciales inválidas");
    } finally {
      setLoading(false);
    }
  };

  return (
    <div className="login-form">
      <h2>Login</h2>
      <form onSubmit={handleSubmit}>
        <label htmlFor="email">Email</label>
        <input 
          id="email"
          type="email" 
          placeholder="Email" 
          value={email} 
          onChange={(e) => setEmail(e.target.value)} 
          required
        />
        <label htmlFor="password">Password</label>
        <input 
          id="password"
          type="password" 
          placeholder="Password" 
          value={password} 
          onChange={(e) => setPassword(e.target.value)} 
          required
        />
        <button type="submit" disabled={loading}>
          {loading ? "Cargando..." : "Login"}
        </button>
      </form>
    </div>
  );
};

export default Login;
