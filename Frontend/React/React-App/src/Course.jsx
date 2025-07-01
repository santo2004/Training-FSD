// import HTML from './assets/HTML.png';

// const course1="HTML Basics";

function Course(props)
{

    // const styles={
    //     backgroundColor:"lightblue",
    // }
    
    return (
        <>
            <div className="card">
                <img src={props.image} alt=""/>
                <h4>{props.name}</h4>
                <p>{props.price}</p>
            </div>
        </>
    );
}

// Course.defaultProps = {
//     name : "Course name",
//     price: "$100",
//     image: HTML
// }

export default Course