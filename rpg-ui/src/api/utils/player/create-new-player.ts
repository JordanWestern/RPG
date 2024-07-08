import axios from 'axios';

export type newPlayer = {
    name: string;
  };

export type existingPlayer = {
    id: string;
    name: string;
  };

export const createNewPlayer = async (newPlayer: newPlayer) => await axios.post('http://localhost:5028/api/player', newPlayer);