import { createContext, useContext, useState } from 'react';

const UserContext = createContext();

export const UserProvider = ({ children }) => {
  const [user, setUser] = useState('');
  const [bookings, setBookings] = useState([]);

  return (
    <UserContext.Provider value={{ user, setUser, bookings, setBookings }}>
      {children}
    </UserContext.Provider>
  );
};

export const useUserContext = () => useContext(UserContext);
