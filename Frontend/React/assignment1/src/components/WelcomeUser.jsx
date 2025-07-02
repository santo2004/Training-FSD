import React from 'react';

function WelcomeUser(props) {
  return (
    <div className="message">
      {props.isLoggedIn ? <h3>Welcome back, {props.name}!</h3> : <h3>Please log in</h3>}
    </div>
  );
}

export default WelcomeUser;
