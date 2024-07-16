import axios from 'axios';

export type newPlayer = {
  name: string;
};

export type existingPlayer = {
  id: string;
  name: string;
};

export const createNewPlayer = async (newPlayer: newPlayer) => {
  const response = await axios.post<existingPlayer>('http://localhost:5028/api/players', newPlayer);
  return response.data;
};

export const getExistingPlayers = async () => {
  const response = await axios.get<existingPlayer[]>('http://localhost:5028/api/players');
  return response.data;
};
