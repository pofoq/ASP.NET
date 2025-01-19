import React from "react";
import GetImgButton from './GetButton';

const ErrorPage: React.FC = () => {
    return (
        <GetImgButton btnName='Получить ошибку' url='https://official-joke-api.appspot.com/1' />
    );
};

export default ErrorPage;
