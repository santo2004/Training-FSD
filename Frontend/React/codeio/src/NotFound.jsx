import { Link } from "react-router-dom";

function NotFound() {
    return (
        <>
            <h2>Error 404 Page not found</h2>
            {/* <a className="btn btn-primary" href="/">Go to Home</a> */}
            <Link to="/" className="btn btn-danger">Home</Link>
        </>
    );
}

export default NotFound;