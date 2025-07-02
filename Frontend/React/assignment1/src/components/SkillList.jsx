import React from 'react';

function SkillList(props) {
  return (
    <div className="skills">
      <h4>Skills:</h4>
      <ul>
        {props.skills.map((skill, i) => (
          <li key={i}>{skill}</li>
        ))}
      </ul>
    </div>
  );
}

export default SkillList;
