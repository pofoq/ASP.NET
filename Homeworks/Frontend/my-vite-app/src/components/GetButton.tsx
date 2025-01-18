import React, { useState } from 'react';
import axios from 'axios';
import ErrorComponent from './ErrorComponent';
import JokeComponent from './JokeComponent';

interface GetButtonProps {
  btnName: string;
  url: string;
}

const GetButton: React.FC<GetButtonProps> = ({ btnName, url }) => {
  const [loading, setLoading] = useState(false);
  const [setup, setSetup] = useState<string>('');
  const [punchline, setPunchline] = useState<string>('');
  const [error, setError] = useState('');

  const handleButtonClick = async () => {
    setLoading(true);
    try {
      const response = await axios.get(url);
      if (response.status >= 200 && response.status < 300) {
        setSetup(response.data.setup);
        setPunchline(response.data.punchline);
      } else {
        throw new Error('Status error: '.concat(response.status.toString(), ' ', response.statusText));
      }
    } catch (ex: any) {
      const err = ex as Error;
      setError(err.message);
    } finally {
      setLoading(false);
    }
  };

  return (
    <div>
      <button onClick={handleButtonClick} disabled={loading}>
        {loading? 'Загрузка...' : btnName}
      </button>
      <div>
        {setup && punchline && <JokeComponent setup={setup} punchline={punchline} />}
        {error && <ErrorComponent error={error} />}
      </div>
    </div>
  );
};

export default GetButton;