import axios from 'axios';

export type newPlayer = {
    name: string;
  };

export type existingPlayer = {
    id: string;
    name: string;
  };

  export const createNewPlayer = async (newPlayer: newPlayer) => {
    const response = await axios.post<existingPlayer>('http://localhost:5028/api/player', newPlayer);
    return response.data;
  };