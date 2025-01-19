import React, { useState } from 'react';
import axios from 'axios';
import ErrorComponent from './ErrorComponent';
import JokeComponent from './JokeComponent';
import 'bootstrap/dist/css/bootstrap.css'
import { useSelector, useDispatch } from 'react-redux'; // Импортируем хуки useSelector и useDispatch из библиотеки react-redux. Хук - это функция, которая позволяет вам использовать состояние и другие возможности React без написания классов
import { RootState } from '../store/store'; // Импортируем тип RootState из хранилища
import { setSetupState, setPunchlineState } from '../store/jokeSlice'; // Импортируем действия increment, decrement и incrementByAmount из слайса

interface GetButtonProps {
  btnName: string;
  url: string;
}

const GetButton: React.FC<GetButtonProps> = ({ btnName, url }) => {
  const [loading, setLoading] = useState(false);
  // const [setup, setSetup] = useState<string>('');
  // const [punchline, setPunchline] = useState<string>('');
  const [error, setError] = useState('');

  // Получаем значение из хранилища, хук useSelector позволяет получить доступ к состоянию хранилища и выбрать из него нужные данные
  const setupState = useSelector((state: RootState) => state.joke.setup); 
  const punchlineState = useSelector((state: RootState) => state.joke.punchline); 

  const dispatch = useDispatch(); // Хук useDispatch позволяет получить доступ к функции dispatch, которая отправляет действия в хранилище

  const handleButtonClick = async () => {
    setLoading(true);
    try {
      const response = await axios.get(url);
      if (response.status >= 200 && response.status < 300) {
        // setSetup(response.data.setup);
        // setPunchline(response.data.punchline);
        dispatch(setSetupState(response.data.setup));
        dispatch(setPunchlineState(response.data.punchline));
      } else {
        throw new Error('Status error: '.concat(response.status.toString(), ' ', response.statusText));
      }
    } catch (ex: any) {
      dispatch(setSetupState(''));
      dispatch(setPunchlineState(''));
      const err = ex as Error;
      setError(err.message);
    } finally {
      setLoading(false);
    }
  };

  return (
    <div>
      <button className='btn btn-sm btn-outline-secondary' onClick={handleButtonClick} disabled={loading}>
        {loading? 'Загрузка...' : btnName}
      </button>
      <div>
        {setupState && punchlineState && <JokeComponent setup={setupState} punchline={punchlineState} />}
        {error && <ErrorComponent error={error} />}
      </div>
    </div>
  );
};

export default GetButton;