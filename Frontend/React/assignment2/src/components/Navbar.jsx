import React from 'react';
import { NavLink } from 'react-router-dom';
import { useUserContext } from './UserContext';

function Navbar() {
  const { user } = useUserContext();

  return (
    <nav className="navbar">
      {user ? (
        <>
          <NavLink to="/dashboard" className={({ isActive }) => isActive ? 'active' : ''}>Dashboard</NavLink>
          <NavLink to="/book" className={({ isActive }) => isActive ? 'active' : ''}>Book</NavLink>
        </>
      ) : (
        <NavLink to="/login" className={({ isActive }) => isActive ? 'active' : ''}>Login</NavLink>
      )}
    </nav>
  );
}

export default Navbar;
