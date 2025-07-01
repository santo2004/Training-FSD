import html from './assets/HTML.png';
import css from './assets/CSS.png';
import js from './assets/JS.png';
import Course from './Course';

function CourseList() {
    
    const courses =[
        {
            // id:1,
            name: "HTML Basics",
            price: 10,
            image: html,
            rating : 4.5
        },
        {
            // id:2,
            name: "CSS Fundamentals",
            price: 15,
            image: css,
            rating : 4.0
        },
        {
            //id:3,
            name: "JavaScript Essentials",
            price: 20,
            image: js,
            rating : 4.8
        },
        {
        }
    ]

    courses.sort((a,b) => b.price - a.price); //descending order by price
    // courses.sort((a,b) => a.rating - b.rating); //ascending order by rating

    const filteredCourses = courses.filter((course) => course.price>10);

    const courseList = filteredCourses.map(
        (course,index) => 
        <Course
        key = {index}
        name = {course.name}
        price = {course.price}
        image = {course.image}
        rating = {course.rating}
        />
    )

    return(
        <>
            {courseList}
        </>
    );
}

export default CourseList;