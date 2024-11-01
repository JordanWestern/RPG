import { Autocomplete, Chip, Stack, TextField } from '@mui/material';
import React, { MutableRefObject, useRef } from 'react';

type AttackCommandHandlerProps = {
  setCommandValid: (commandValid: boolean) => void;
};

const AttackCommandHandler = ({ setCommandValid }: AttackCommandHandlerProps) => {
  const target = useRef<string>(null);
  const weapon = useRef<string>(null);

  function updateSelection(
    selection: string,
    items: string[],
    ref: MutableRefObject<string | null>
  ) {
    items.includes(selection) ? (ref.current = selection) : (ref.current = null);

    setCommandValid(Boolean(target.current && weapon.current));
  }

  const availableTargets = ['Cave Troll', 'Bloodied Orc', 'Hooded Civilian Wanderer'];

  const availableWeapons = ['Stone Mace', 'Fists', 'Recurve Bow', 'Titanium Long-Sword'];

  return (
    <Stack direction="row" spacing={2}>
      <Autocomplete
        disablePortal
        id="targets"
        options={availableTargets}
        sx={{ width: 300 }}
        renderInput={(params) => <TextField {...params} label="Target" />}
        onInputChange={(_, input) => updateSelection(input, availableTargets, target)}
      />
      <Chip label="With" color="primary" variant="outlined" sx={{ alignSelf: 'center' }} />
      <Autocomplete
        disablePortal
        id="weapons"
        options={availableWeapons}
        sx={{ width: 300 }}
        renderInput={(params) => <TextField {...params} label="Weapon" />}
        onInputChange={(_, input) => updateSelection(input, availableWeapons, weapon)}
      />
    </Stack>
  );
};

export default AttackCommandHandler;
