import { Autocomplete, IconButton, Stack, TextField } from '@mui/material';
import React, { ReactElement, useState } from 'react';
import TravelToCommandHandler from '../command-handler/travel-to-command-handler';
import UseItemCommandHandler from '../command-handler/use-item-command-handler';
import AttackCommandHandler from '../command-handler/attack-command-handler';
import PlayCircleOutlinedIcon from '@mui/icons-material/PlayCircleOutlined';

const CommandHandler = () => {
  const commands = ['Travel To', 'Use Item', 'Attack'];

  const [currentCommandHandler, setCommandHandler] = useState<ReactElement | null>(null);

  const [commandValid, setCommandValid] = useState(false);

  function getCommandHandler(commandHandler: string): ReactElement | null {
    setCommandValid(false);

    switch (commandHandler) {
      case 'Travel To':
        return <TravelToCommandHandler setCommandValid={setCommandValid} />;
      case 'Use Item':
        return <UseItemCommandHandler setCommandValid={setCommandValid} />;
      case 'Attack':
        return <AttackCommandHandler setCommandValid={setCommandValid} />;
      default:
        return null;
    }
  }

  return (
    <Stack direction="row" spacing={2}>
      <Autocomplete
        disablePortal
        id="command"
        options={commands}
        sx={{ width: 300 }}
        renderInput={(params) => <TextField {...params} label="Command" />}
        onInputChange={(_, input) => setCommandHandler(getCommandHandler(input))}
      />
      {currentCommandHandler}
      <IconButton disabled={!commandValid} color="primary" size="large">
        <PlayCircleOutlinedIcon fontSize="inherit" />
      </IconButton>
    </Stack>
  );
};

export default CommandHandler;
