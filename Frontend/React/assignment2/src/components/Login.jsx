import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { useUserContext } from './UserContext';

function Login() {
  const [name, setName] = useState('');
  const navigate = useNavigate();
  const { setUser } = useUserContext();

  const handleLogin = (e) => {
    e.preventDefault();
    if (name.trim()) {
      setUser(name);
      navigate('/dashboard');
    }
  };

  return (
    <div className="container">
      <h2>Login</h2>
      <form onSubmit={handleLogin}>
        <input
          type="text"
          placeholder="Enter your name"
          value={name}
          onChange={(e) => setName(e.target.value)}
          required
        />
        <button type="submit">Login</button>
      </form>
    </div>
  );
}

export default Login;
