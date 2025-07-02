import React from 'react';

function ProfileCard({ name, title, imageUrl }) {
  return (
    <div className="card">
      <img src={imageUrl} alt={name} />
      <h3>{name}</h3>
      <p>{title}</p>
    </div>
  );
}

export default ProfileCard;
