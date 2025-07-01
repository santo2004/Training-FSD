import './Project.css';

function Projects() {
    return (
        <div className="projects-wrapper">
            <div className="projects-card">
                <h2>My Projects</h2>
                <ul>
                    <li><strong>Crop Yield Prediction</strong> using Gradient Boosting Regressor (Final Year Project)</li>
                    <li><strong>Naukri Resume Automation</strong> using Selenium & Streamlit (Internship Project)</li>
                    <li><strong>Student Database Management System</strong> using C# and MySQL</li>
                    <li><strong>Energy Harvesting</strong> using Piezoelectric Materials (Minor Project)</li>
                </ul>
            </div>
        </div>
    );
}

export default Projects;