import React from 'react';

function WelcomeUser({ isLoggedIn, name }) {
  return (
    <div className="message">
      {isLoggedIn ? <h3>Welcome back, {name}!</h3> : <h3>Please log in</h3>}
    </div>
  );
}

export default WelcomeUser;
