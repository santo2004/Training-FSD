// import HTML from './assets/HTML.png';
// import PropTypes from 'prop-types'

// const course1="HTML Basics";

function Course(props)
{
    return (
        props.name && <div className="card">
            <img src={props.image} alt=""/>
            <h4>{props.name}</h4>
            <p>{props.price}</p>
        </div>
    );
    // const styles={
    //     backgroundColor:"lightblue",
    // }
    
    // if (props.show==true)
    // {
    //     return (
    //         <>
    //             <div className="card">
    //                 <img src={props.image} alt=""/>
    //                 <h4>{props.name}</h4>
    //                 <p>{props.price}</p>
    //             </div>
    //         </>
    //     );
    // }
    // else
    // {
    //     return (
    //         <div className="card">Course not available</div>
    //     );
    // }
}

// Course.defaultProps = {
//     name : "Course name",
//     price: "$100",
//     image: HTML
// }

// Course.propTypes = {
//     name:PropTypes.string,
//     show:PropTypes.bool 
// }

export default Course