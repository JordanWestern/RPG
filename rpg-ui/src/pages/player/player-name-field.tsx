import { TextField } from '@mui/material';
import React, { useRef } from 'react';

type PlayerNameFieldProps = {
  onChange: (name: string) => void;
};

const PlayerNameField = ({ onChange }: PlayerNameFieldProps) => {
  const playerName = useRef('Grognak the barbarian');

  const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    playerName.current = e.target.value;
    onChange(playerName.current);
  };

  return (
    <TextField
      id="characterName"
      label="Character Name"
      variant="standard"
      placeholder={playerName.current}
      onChange={handleChange}
    />
  );
};

export default PlayerNameField;
