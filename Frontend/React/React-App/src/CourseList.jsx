import Course from './Course';
import { useEffect, useState } from 'react';

function CourseList() {
    
    const [courses,setCourses] = useState(null);

    const [dummy,setDummy] = useState(false);

    useEffect( () => {
        fetch('https://localhost:3000')
        .then( response => {
            //console.log(response);
            return response.json()
        }).then (data => setCourses(data))
    },[]);     //can make dependency array like '[dummy]' '[courses]' or '[]' for no dependency

    function handleDelete(id) {
        const newCourses = courses.filter((course) => course.id != id);
        setCourses(newCourses);
    }

    //courses.sort((a,b) => b.price - a.price); //descending order by price
    // courses.sort((a,b) => a.rating - b.rating); //ascending order by rating

    const filteredCourses = courses.filter((course) => course.price>10);

    const courseList = courses.map(
        (course) => 
        <Course
        key = {course.id}
        name = {course.name}
        price = {course.price}
        image = {course.image}
        // rating = {course.rating}
        del={handleDelete}
        id={course.id}
        />
    )

    return(
        <>
            {courseList}
            <button onClick = { () => {setDummy(true)}}>Dummy</button>
        </>
    );
}

export default CourseList;