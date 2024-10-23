import axios from 'axios';

export type GameLog = {
  id: string;
  date: string;
  logMessage: string;
};

export const getGameLogs = async (playerId: string) => {
  const response = await axios.get<GameLog[]>(`http://localhost:5028/api/gameLogs/${playerId}`);
  return response.data;
};
