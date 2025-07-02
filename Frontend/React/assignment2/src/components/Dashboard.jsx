import React from 'react';
import { useUserContext } from './UserContext';
import { Link } from 'react-router-dom';

function Dashboard() {
  const { user, bookings } = useUserContext();

  return (
    <div className="container">
      <h2>Welcome, {user}!</h2>
      {bookings.length === 0 ? (
        <p className="center">No bookings yet.</p>
      ) : (
        <>
          <h3>Your Bookings</h3>
          <ul>
            {bookings.map((b, i) => (
              <li key={i}>
                <strong>Department:</strong> {b.department} <br />
                <strong>Date:</strong> {b.date}
              </li>
            ))}
          </ul>
        </>
      )}
      <Link to="/book" className="link">Book Appointment</Link>
    </div>
  );
}

export default Dashboard;
