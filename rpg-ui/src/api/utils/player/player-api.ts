import axios from 'axios';

export type NewPlayer = {
  name: string;
};

export type ExistingPlayer = {
  id: string;
  name: string;
};

export const createNewPlayer = async (newPlayer: NewPlayer) => {
  const response = await axios.post<ExistingPlayer>('http://localhost:5028/api/players', newPlayer);
  return response.data;
};

export const getExistingPlayers = async () => {
  const response = await axios.get<ExistingPlayer[]>('http://localhost:5028/api/players');
  return response.data;
};
