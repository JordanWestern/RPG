import axios from 'axios';

export type Map = {
  id: string;
  name: string;
  description: string;
};

export const getMaps = async () => {
  const response = await axios.get<Map[]>('http://localhost:5028/api/maps');
  return response.data;
};
