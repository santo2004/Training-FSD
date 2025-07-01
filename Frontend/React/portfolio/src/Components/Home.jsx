import './Home.css';
import santoImage from './Santo.jpeg';

function Home() {
    return (
        <div className="home-wrapper">
            <div className="home-card">
                <div className="home-text">
                    <h2>Hi guys!!</h2>
                    <p>I'm <strong>Santo Allen</strong> and this is my portfolio. Explore my work, get to know more about me!</p>
                </div>
                <div className="home-image">
                    <img src={santoImage} alt="Santo Allen" />
                </div>
            </div>
        </div>
    );
}

export default Home;
