import { useNavigate, useLocation } from 'react-router-dom';
import './Navbar.css';

function Navbar() {
  const navigate = useNavigate();
  const location = useLocation();

  const handleNavigation = (path) => {
    navigate(path);
  };

  return (
    <nav className="navbar">
      <div className="navbar-content">
        <button
          className={`nav-btn ${location.pathname === '/home' ? 'active' : ''}`}
          onClick={() => handleNavigation('/home')}
        >
          Home
        </button>
        <button
          className={`nav-btn ${location.pathname === '/about' ? 'active' : ''}`}
          onClick={() => handleNavigation('/about')}
        >
          About
        </button>
        <button
          className={`nav-btn ${location.pathname === '/projects' ? 'active' : ''}`}
          onClick={() => handleNavigation('/projects')}
        >
          Projects
        </button>
        <button
          className={`nav-btn ${location.pathname === '/contact' ? 'active' : ''}`}
          onClick={() => handleNavigation('/contact')}
        >
          Contact
        </button>
      </div>
    </nav>
  );
}

export default Navbar;