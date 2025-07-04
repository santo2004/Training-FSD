import { useState, useEffect } from "react";

const useFetch = (url) => {

    const [data,SetData] = useState(null);
    const [dummy,setDummy] = useState(false);
    const [error, setError] = useState(null);

    useEffect(() => {
        setTimeout(() => {
            fetch(url)
            .then( (response) => {
                if (!response.ok) {
                    throw new Error("couldn't fetch courses");
                }
                return response.json();
            })
            .then(data => SetData(data))
            .catch( (error) => {
                console.log(error.message);
                setError(error.message);
                //setData([]);
            });
        }, 1000)
    }, []); //can make dependency array like '[dummy]' '[courses]' or '[]' for no dependency

    return [data, dummy, error]

}

export default useFetch;