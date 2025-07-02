import React from 'react';

function SkillList({ skills }) {
  return (
    <div className="skills">
      <h4>Skills:</h4>
      <ul>
        {skills.map((skill, i) => (
          <li key={i}>{skill}</li>
        ))}
      </ul>
    </div>
  );
}

export default SkillList;
