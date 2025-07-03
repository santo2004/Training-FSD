// import HTML from './assets/HTML.png';
// import PropTypes from 'prop-types'
import { useState } from 'react';

// const course1="HTML Basics";

function Course(props)
{
    const [purchased, setPurchased] = useState('false');
    // const [discount, setDiscount] = useState(props.price);

    function BuyCourse(discount) {
        console.log(props.name, "purchased with", discount, "% discount");   
        setPurchased('true');
        // setDiscount(discount - amnt);
    }

    return (
        props.name && <div className="card">
            <img src={props.image} alt=""/>
            <h4>{props.name}</h4>
            <p>{props.price}</p>
            {/* <p>{discount}</p> */}
            <button onClick = { ()=> BuyCourse(20) }>Buy Now</button>
            <button onClick = { () => props.del(props.id) }>Delete</button>
            <p>{purchased}</p>
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