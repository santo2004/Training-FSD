import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import Login from './Login'
import Home from './Home'
import { createBrowserRouter, RouterProvider } from 'react-router-dom'
import NotFound from './NotFound'

//obj for router
const router = createBrowserRouter([
  {
    path : '/',
    element : <Home />,
    errorElement : <NotFound />
  },
  {
    path : '/login',
    element : <Login />,
    errorElement : <NotFound />
  }
]);

createRoot(document.getElementById('root')).render(
  <StrictMode>
    {/* <Home />
    <Login/> */}
    <RouterProvider router={router} />
  </StrictMode>,
)
