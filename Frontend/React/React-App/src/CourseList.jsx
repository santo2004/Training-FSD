import Course from './Course';
import useFetch from './useFetch';

function CourseList() {
    
    const [courses, dummy, error] = useFetch('http://localhost:4000/courses')

    function handleDelete(id) {
        const newCourses = courses.filter((course) => course.id != id);
        setCourses(newCourses );
    }

    // courses.sort((a,b) => b.price - a.price); //descending order by price
    // courses.sort((a,b) => a.rating - b.rating); //ascending order by rating

    if (!courses) //only shows when course da
    {
        return (
            <>
                {!error && <p>loading....</p>}
                {error && <p>{error}</p>}
            </>
        ) 
    }

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