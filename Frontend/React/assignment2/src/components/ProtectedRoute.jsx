import React from 'react';
import { Navigate } from 'react-router-dom';
import { useUserContext } from './UserContext';

const ProtectedRoute = ({ children }) => {
  const { user } = useUserContext();

  if (!user) {
    return <Navigate to="/login" replace />;
  }

  return children;
};

export default ProtectedRoute;
