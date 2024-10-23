import {
  Button,
  Container,
  FormControl,
  FormGroup,
  InputLabel,
  MenuItem,
  Select,
  Stack,
  TextField
} from '@mui/material';
import { useEffect, useRef, useState } from 'react';
import Spinner from '../../shared/spinner';
import useCheckApiStatus from '../../api/utils/info/check-api-status';
import {
  createNewPlayer,
  ExistingPlayer,
  getExistingPlayers,
  NewPlayer
} from '../../api/utils/player/player-api';
import { getMaps, Map } from '../../api/utils/map/map-api';
import './create-player-page.css';

type CreatePlayerPageProps = {
  continueWithPlayer: (selectedPlayer: ExistingPlayer) => void;
};

const CreatePlayerPage = ({ continueWithPlayer }: CreatePlayerPageProps) => {
  const [existingPlayers, setExistingPlayers] = useState<ExistingPlayer[]>([]);
  const [maps, setMaps] = useState<Map[]>([]);
  const [apiReady, setApiReady] = useState(false);
  const [selectedPlayer, setSelectedPlayer] = useState<ExistingPlayer | null>(null);
  const [selectedMap, setSelectedMap] = useState<Map | null>(null);
  const playerName = useRef('Grognak the barbarian');

  useCheckApiStatus(setApiReady);

  useEffect(() => {
    const fetchExistingPlayers = async () => {
      const players = await getExistingPlayers();
      setExistingPlayers(players);
      if (players.length > 0) {
        setSelectedPlayer(players[0]);
      }
    };

    if (apiReady) {
      fetchExistingPlayers();
    }
  }, [apiReady]);

  useEffect(() => {
    const fetchMaps = async () => {
      const maps = await getMaps();
      setMaps(maps);
      setSelectedMap(maps[0]);
    };

    if (apiReady) {
      fetchMaps();
    }
  }, [apiReady]);

  const handleCreatePlayer = async () => {
    const newPlayer: NewPlayer = { name: playerName.current };
    const createdPlayer = await createNewPlayer(newPlayer);
    setExistingPlayers((existingPlayers) => [...existingPlayers, createdPlayer]);
    setSelectedPlayer(createdPlayer);
  };

  const onPlayerSelected = (playerId: string) => {
    const selection = existingPlayers.find((player) => player.id === playerId);
    setSelectedPlayer(selection);
  };

  const onMapSelected = (mapId: string) => {
    const selection = maps.find((map) => map.id === mapId);
    setSelectedMap(selection);
  };

  return (
    <div className={apiReady ? '' : 'blurred'}>
      {!apiReady && <Spinner />}
      <Container>
        <FormGroup>
          <Stack spacing={5}>
            <TextField
              id="characterName"
              label="Character Name"
              variant="standard"
              placeholder={playerName.current}
              onChange={(e) => (playerName.current = e.target.value)}
            />
            <FormControl variant="standard">
              <InputLabel id="select-map-label">Select Map</InputLabel>
              <Select
                id="select-map"
                labelId="select-map-label"
                value={selectedMap?.id ?? ''}
                onChange={(e) => onMapSelected(e.target.value)}>
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
            <Button variant="outlined" onClick={handleCreatePlayer}>
              Create New Player
            </Button>
            {existingPlayers.length > 0 && (
              <>
                <FormControl variant="standard">
                  <InputLabel id="select-player-label">Select Player</InputLabel>
                  <Select
                    id="select-player"
                    labelId="select-player-label"
                    value={selectedPlayer?.id ?? ''}
                    onChange={(e) => onPlayerSelected(e.target.value)}>
                    {existingPlayers.map((existingPlayer) => (
                      <MenuItem key={existingPlayer.id} value={existingPlayer.id}>
                        {existingPlayer.name}
                      </MenuItem>
                    ))}
                  </Select>
                </FormControl>
                <Button variant="outlined" onClick={() => continueWithPlayer(selectedPlayer)}>
                  Start
                </Button>
              </>
            )}
          </Stack>
        </FormGroup>
      </Container>
    </div>
  );
};

export default CreatePlayerPage;
