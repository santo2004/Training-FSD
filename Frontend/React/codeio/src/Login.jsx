import { useState } from "react";

function Login () {

    const [pass1,setPass1] = useState("");
    const [pass2,setPass2] = useState("");
    const [same,setSame] = useState(true);

    function handlePass1Change(event) {
        setPass1(event.target.value);
        //console.log(event.target.value);
    }

    function handlePass2Change(event) {
        setPass2(event.target.value);
        //console.log(event.target.value);
        if(pass1 == event.target.value) {
            console.log("same");
            setSame(true);
        }
        else {
            console.log("not same");
            setSame(false);
        }
    }

    return (
        <>
            <form className="my-5" style={{width:"50%", margin : "auto" }}>
                <div className="mb-3">
                    <label className="form-label">Email address</label>
                    <input type="email" className="form-control" />
                </div>
                <div className="mb-3">
                    <label className="form-label">Password</label>
                    <input value = {pass1} onChange = {handlePass1Change} type="password" className="form-control" />
                </div>
                <div className="mb-3">
                    <label className="form-label">Re-enter Password</label>
                    <input value = {pass2} onChange={handlePass2Change} type="password" className="form-control" />
                </div>
                <div className="mb-3 form-check">
                    <input type="checkbox" className="form-check-input" />
                    <label className="form-check-label">i agree</label>
                    {/* {console.log(pass1, pass2)} */}
                </div>
                {!same && <p>password do not match</p>}
                <button type="submit" className="btn btn-primary">create account</button>
            </form>
        </>
    );
}

export default Login;