import './App.css'
import Course from './Course';
// import Footer from './Footer';
// import Navbar from './Navbar';
import HTML from './assets/HTML.png';
import CSS from './assets/CSS.png';
import JS from './assets/JS.png'; 

function App() 
{
  return (
    <>
        <Course name = "HTML" price="$199" image = {HTML}/>
        <Course name = "CSS" price="$199" image = {CSS}/>
        <Course name = "JS" price="$499" image = {JS}/>
    </>
  );
}

export default App
