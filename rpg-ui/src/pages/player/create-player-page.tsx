import {
  Button,
  Container,
  FormControl,
  FormGroup,
  InputLabel,
  MenuItem,
  Select,
  Stack
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
import { Map } from '../../api/utils/map/map-api';
import './create-player-page.css';
import PlayerNameField from './player-name-field';
import SelectMapDropdown from './select-map-dropdown';

type CreatePlayerPageProps = {
  continueWithPlayer: (selectedPlayer: ExistingPlayer) => void;
};

const CreatePlayerPage = ({ continueWithPlayer }: CreatePlayerPageProps) => {
  const [existingPlayers, setExistingPlayers] = useState<ExistingPlayer[]>([]);
  const [apiReady, setApiReady] = useState(false);
  const [selectedPlayer, setSelectedPlayer] = useState<ExistingPlayer | null>(null);
  const selectedMap = useRef<Map | undefined>(undefined);
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

  const handleCreatePlayer = async () => {
    const newPlayer: NewPlayer = { name: playerName.current, mapId: selectedMap.current.id };
    const createdPlayer = await createNewPlayer(newPlayer);
    setExistingPlayers((existingPlayers) => [...existingPlayers, createdPlayer]);
    setSelectedPlayer(createdPlayer);
  };

  const onPlayerSelected = (playerId: string) => {
    const selection = existingPlayers.find((player) => player.id === playerId);
    setSelectedPlayer(selection);
  };

  return (
    <div className={apiReady ? '' : 'blurred'}>
      {!apiReady && <Spinner />}
      <Container>
        <FormGroup>
          <Stack spacing={5}>
            <PlayerNameField onChange={(name) => (playerName.current = name)} />
            <SelectMapDropdown
              onChange={(map) => (selectedMap.current = map)}
              apiReady={apiReady}
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
