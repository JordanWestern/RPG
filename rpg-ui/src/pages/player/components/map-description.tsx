import { TextField } from '@mui/material';
import { Map } from '../../../api/utils/map/map-api';

type MapDescriptionProps = {
  selectedMap: Map | null;
};

const MapDescription = ({ selectedMap }: MapDescriptionProps) => (
  <TextField
    id="map-description"
    label={`Description: ${selectedMap?.name ?? 'Default Map Name'}`}
    defaultValue={selectedMap?.description ?? ''}
    multiline
    InputProps={{ readOnly: true }}
    InputLabelProps={{ shrink: true }}
  />
);

export default MapDescription;
