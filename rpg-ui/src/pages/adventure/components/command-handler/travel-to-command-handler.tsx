import { Autocomplete, TextField } from '@mui/material';
import React from 'react';

type TravelToCommandHandlerProps = {
  setCommandValid: (commandValid: boolean) => void;
};

const TravelToCommandHandler = ({ setCommandValid }: TravelToCommandHandlerProps) => {
  const availableDestinations = ['Mountain Pass', 'Dark Forest', 'Elven Temple'];

  return (
    <Autocomplete
      disablePortal
      id="travel-to"
      options={availableDestinations}
      sx={{ width: 300 }}
      renderInput={(params) => <TextField {...params} label="Destination" />}
      onInputChange={(_, input) => setCommandValid(availableDestinations.includes(input))}
    />
  );
};

export default TravelToCommandHandler;
