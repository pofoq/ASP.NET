import React from "react";
import GetImgButton from './GetButton';

const JokePage: React.FC = () => {
    return (
        <GetImgButton btnName='Get Joke' url='https://official-joke-api.appspot.com/jokes/random/' />
    );
};

export default JokePage;
