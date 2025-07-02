import React, { useState } from 'react';
import { useUserContext } from './UserContext';
import { useNavigate } from 'react-router-dom';

function BookAppointment() {
  const { bookings, setBookings } = useUserContext();
  const [form, setForm] = useState({ department: '', date: '' });
  const navigate = useNavigate();

  const handleChange = (e) => setForm({ ...form, [e.target.name]: e.target.value });

  const handleSubmit = (e) => {
    e.preventDefault();
    setBookings([...bookings, form]);
    alert("Appointment booked successfully!");
    navigate('/dashboard');
  };

  return (
    <div className="container">
      <h2>Book Appointment</h2>
      <form onSubmit={handleSubmit}>
        <input
          name="department"
          placeholder="Department"
          onChange={handleChange}
          value={form.department}
          required
        />
        <input
          name="date"
          type="date"
          onChange={handleChange}
          value={form.date}
          required
        />
        <button type="submit">Book</button>
      </form>
    </div>
  );
}

export default BookAppointment;
