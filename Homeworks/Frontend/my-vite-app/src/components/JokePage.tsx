import React from "react";
import GetImgButton from './GetButton';

const JokePage: React.FC = () => {
    return (
        <div style={{ backgroundColor: 'green', color: 'white', padding: '10px' }}>
            <GetImgButton btnName='Get Joke' url='https://official-joke-api.appspot.com/jokes/random/' />
        </div>
    );
};

export default JokePage;
