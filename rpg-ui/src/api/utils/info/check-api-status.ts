import { useEffect } from 'react';
import appReady from './app-ready';

const useCheckApiStatus = (setApiReady: (ready: boolean) => void) => {
  useEffect(() => {
    const checkApiStatus = async () => {
      try {
        const response = await appReady();
        if (response.status === 200) {
          setApiReady(true);
          clearInterval(intervalId);
        }
      } catch (error) {
        console.error('API is not ready:', error);
      }
    };

    const intervalId = setInterval(checkApiStatus, 1000);

    return () => clearInterval(intervalId);
  }, [setApiReady]);
};

export default useCheckApiStatus;
