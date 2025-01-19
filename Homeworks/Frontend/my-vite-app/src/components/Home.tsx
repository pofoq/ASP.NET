import React from "react";
import { useNavigate } from "react-router-dom";

const Home: React.FC = () => {

    const navigate = useNavigate();
    const goToJoke = () => {
        navigate('/joke');
    };

    return (
        <div style={{ backgroundColor: 'grey', color: 'white', padding: '10px' }}>
            <h1>Home Page</h1>
            <button onClick={goToJoke}>Go to Joke</button>
        </div>
    );
};

export default Home;
