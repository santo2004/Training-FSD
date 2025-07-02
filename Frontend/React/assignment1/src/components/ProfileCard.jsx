import React from 'react';

function ProfileCard(props) {
  return (
    <div className="card">
      <img src={props.url} alt={props.name} />
      <h3>{props.name}</h3>
      <p>{props.role}</p>
    </div>
  );
}

export default ProfileCard;
