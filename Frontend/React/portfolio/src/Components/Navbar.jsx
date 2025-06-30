import { NavLink } from 'react-router-dom';
import './Navbar.css';

function Navbar() {
  return (
    <nav className="navbar">
      <div className="navbar-content">
        <NavLink to="/home" className={({ isActive }) => isActive ? 'nav-btn active' : 'nav-btn'}>
          Home
        </NavLink>
        <NavLink to="/about" className={({ isActive }) => isActive ? 'nav-btn active' : 'nav-btn'}>
          About
        </NavLink>
      </div>
    </nav>
  );
}

export default Navbar;
