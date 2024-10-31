import {
  FormControl,
  InputLabel,
  MenuItem,
  Select,
  SelectChangeEvent,
  TextField
} from '@mui/material';
import { getMaps, Map } from '../../api/utils/map/map-api';
import { useEffect, useState } from 'react';

type SelectMapDropdownProps = {
  onChange: (map: Map | undefined) => void;
  apiReady: boolean;
};

const SelectMapDropdown = ({ onChange, apiReady }: SelectMapDropdownProps) => {
  const [maps, setMaps] = useState<Map[]>([]);
  const [selectedMap, setSelectedMap] = useState<Map | undefined>(undefined);

  useEffect(() => {
    const fetchMaps = async () => {
      const maps = await getMaps();
      setMaps(maps);
      setSelectedMap(maps[0]);
      onChange(maps[0]);
    };

    if (apiReady) {
      fetchMaps();
    }
  }, [apiReady, onChange]);

  const handleMapSelected = (e: SelectChangeEvent<string>) => {
    const selection = maps.find((map) => map.id === e.target.value);
    setSelectedMap(selection);
    onChange(selection);
  };

  return (
    <>
      <FormControl variant="standard">
        <InputLabel id="select-map-label">Select Map</InputLabel>
        <Select
          id="select-map"
          labelId="select-map-label"
          value={selectedMap?.id ?? ''}
          onChange={handleMapSelected}>
          {maps.map((map) => (
            <MenuItem key={map.id} value={map.id}>
              {map.name}
            </MenuItem>
          ))}
        </Select>
      </FormControl>
      <TextField
        // TODO: There is a bug in the MUI component https://github.com/mui/material-ui/issues/43718
        // if the page is resized in dev, you get ResizeObserver loop completed with undelivered notifications.
        // Should not surface in the release build.
        id="outlined-read-only-input"
        color="secondary"
        defaultValue={selectedMap?.description ?? null}
        multiline
        label={`Description: ${selectedMap?.name ?? 'Default Map Name'}`}
        InputProps={{
          readOnly: true
        }}
        InputLabelProps={{
          shrink: true
        }}
      />
    </>
  );
};

export default SelectMapDropdown;
