import React from 'react';
import { Link } from 'react-router-dom';

const departments = [
  { id: 'cardiology', name: 'Cardiology' },
  { id: 'neurology', name: 'Neurology' },
  { id: 'orthopedics', name: 'Orthopedics' },
];

function Departments() {
  return (
    <div>
      <h2>Departments</h2>
      <ul>
        {departments.map((dept) => (
          <li key={dept.id}>
            <Link to={`/departments/${dept.id}/doctors`}>{dept.name}</Link>
          </li>
        ))}
      </ul>
    </div>
  );
}

export default Departments;
