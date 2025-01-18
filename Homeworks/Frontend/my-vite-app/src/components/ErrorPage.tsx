import React from "react";
import GetImgButton from './GetButton';

const ErrorPage: React.FC = () => {
    return (
        <div style={{ backgroundColor: 'red', color: 'white', padding: '10px' }}>
            <GetImgButton btnName='Получить ошибку' url='https://official-joke-api.appspot.com/1' />
        </div>
    );
};

export default ErrorPage;
