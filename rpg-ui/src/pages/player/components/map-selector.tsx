import { FormControl, InputLabel, MenuItem, Select } from '@mui/material';
import { Map } from '../../../api/utils/map/map-api';
import React from 'react';

type MapSelectorProps = {
  maps: Map[];
  selectedMap: Map | null;
  onMapSelected: (map: Map) => void;
};

const MapSelector = ({ maps, selectedMap, onMapSelected }: MapSelectorProps) => (
  <FormControl variant="standard">
    <InputLabel id="select-map-label">Select Map</InputLabel>
    <Select
      labelId="select-map-label"
      value={selectedMap?.id ?? ''}
      onChange={(e) => {
        const map = maps.find((map) => map.id === e.target.value);
        if (map) onMapSelected(map);
      }}>
      {maps.map((map) => (
        <MenuItem key={map.id} value={map.id}>
          {map.name}
        </MenuItem>
      ))}
    </Select>
  </FormControl>
);

export default MapSelector;
