import React from 'react';
import './index.css';
import ProfileCard from './components/ProfileCard';
import WelcomeUser from './components/WelcomeUser';
import ProductPrice from './components/ProductPrice';
import SkillList from './components/SkillList';

function App() {
  return (
    <div className="app">
      <section>
        <ProfileCard
          name="Santo Allen"
          role="Trainee"
          url="https://png.pngtree.com/png-clipart/20230930/original/pngtree-man-avatar-isolated-png-image_13022170.png"
        />
      </section>
      <section>
        <WelcomeUser 
          isLoggedIn={true}   
          name="Santo" />
      </section>
      <section>
        <ProductPrice 
          name="Laptop"   
          rate={55000} 
          quantity={2} />
      </section>
      <section>
        <SkillList 
          skills={['React', 'CSS', 'JavaScript', 'HTML']} />
      </section>
    </div>
  );
}

export default App;
