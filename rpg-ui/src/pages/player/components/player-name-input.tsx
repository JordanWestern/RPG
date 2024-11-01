import { TextField } from '@mui/material';
import { useFormContext } from 'react-hook-form';

const PlayerNameInput = () => {
  const {
    register,
    formState: { errors }
  } = useFormContext();

  return (
    <TextField
      {...register('name', { required: 'Required' })}
      id="PlayerName"
      label={
        <>
          Player Name{' '}
          <span style={{ color: 'red', marginLeft: '5px' }}>{errors.name ? '⛔' : ''}</span>
        </>
      }
      variant="standard"
      error={!!errors.name}
    />
  );
};

export default PlayerNameInput;
