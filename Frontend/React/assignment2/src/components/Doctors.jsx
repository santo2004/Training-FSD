import React from 'react';
import { useParams } from 'react-router-dom';

const doctorData = {
  cardiology: ['Dr. Heartwell', 'Dr. Pulse'],
  neurology: ['Dr. Brainstorm', 'Dr. Neuro'],
  orthopedics: ['Dr. Bone', 'Dr. Joint'],
};

function Doctors() {
  const { id } = useParams();
  const doctors = doctorData[id] || [];

  return (
    <div>
      <h2>Doctors in {id.charAt(0).toUpperCase() + id.slice(1)}</h2>
      <ul>
        {doctors.length ? doctors.map((doc, idx) => <li key={idx}>{doc}</li>) : <li>No doctors found.</li>}
      </ul>
    </div>
  );
}

export default Doctors;
