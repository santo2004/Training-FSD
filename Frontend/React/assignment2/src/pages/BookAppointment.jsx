import React, { useState } from 'react';

function BookAppointment() {
  const [form, setForm] = useState({ name: '', department: '', date: '' });

  const handleChange = (e) => setForm({ ...form, [e.target.name]: e.target.value });

  const handleSubmit = (e) => {
    e.preventDefault();
    alert(`Appointment booked for ${form.name} in ${form.department} on ${form.date}`);
  };

  return (
    <div>
      <h2>Book Appointment</h2>
      <form onSubmit={handleSubmit}>
        <input name="name" placeholder="Your Name" onChange={handleChange} required />
        <input name="department" placeholder="Department" onChange={handleChange} required />
        <input name="date" type="date" onChange={handleChange} required />
        <button type="submit">Book</button>
      </form>
    </div>
  );
}

export default BookAppointment;
