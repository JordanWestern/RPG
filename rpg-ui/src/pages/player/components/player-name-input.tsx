import { TextField } from '@mui/material';
import React from 'react';
import { useFormContext } from 'react-hook-form';

const PlayerNameInput = () => {
  const {
    register,
    formState: { errors }
  } = useFormContext();

  return (
    <TextField
      {...register('name', { required: 'Player name is required' })}
      id="characterName"
      label="Character Name"
      variant="standard"
      error={!!errors.name}
      //   helperText={errors.name?.message}
    />
  );
};

export default PlayerNameInput;
