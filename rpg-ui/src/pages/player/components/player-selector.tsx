import { FormControl, InputLabel, MenuItem, Select } from '@mui/material';
import { ExistingPlayer } from '../../../api/utils/player/player-api';
import React from 'react';

type PlayerSelectorProps = {
  players: ExistingPlayer[];
  selectedPlayer: ExistingPlayer | null;
  onPlayerSelected: (player: ExistingPlayer) => void;
};

const PlayerSelector = ({ players, selectedPlayer, onPlayerSelected }: PlayerSelectorProps) => (
  <FormControl variant="standard">
    <InputLabel id="select-player-label">Select Player</InputLabel>
    <Select
      labelId="select-player-label"
      value={selectedPlayer?.id ?? ''}
      onChange={(e) => {
        const player = players.find((p) => p.id === e.target.value);
        if (player) onPlayerSelected(player);
      }}>
      {players.map((player) => (
        <MenuItem key={player.id} value={player.id}>
          {player.name}
        </MenuItem>
      ))}
    </Select>
  </FormControl>
);

export default PlayerSelector;
