import axios from 'axios';

export type map = {
  id: string;
  name: string;
  description: string;
};

export const getMaps = async () => {
  const response = await axios.get<map[]>('http://localhost:5028/api/maps');
  return response.data;
};
