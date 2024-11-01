import { Button, Container, Stack } from '@mui/material';
import { useEffect, useState } from 'react';
import { useForm, FormProvider, Form } from 'react-hook-form';
import Spinner from '../../shared/spinner';
import useCheckApiStatus from '../../api/utils/info/check-api-status';
import {
  createNewPlayer,
  ExistingPlayer,
  getExistingPlayers,
  NewPlayer
} from '../../api/utils/player/player-api';
import { getMaps, Map } from '../../api/utils/map/map-api';
import PlayerNameInput from './components/player-name-input';
import MapSelector from './components/map-selector';
import MapDescription from './components/map-description';
import PlayerSelector from './components/player-selector';

type CreatePlayerPageProps = {
  continueWithPlayer: (selectedPlayer: ExistingPlayer) => void;
};

const CreatePlayerPage = ({ continueWithPlayer }: CreatePlayerPageProps) => {
  const [existingPlayers, setExistingPlayers] = useState<ExistingPlayer[]>([]);
  const [maps, setMaps] = useState<Map[]>([]);
  const [apiReady, setApiReady] = useState(false);
  const [selectedPlayer, setSelectedPlayer] = useState<ExistingPlayer | null>(null);
  const [selectedMap, setSelectedMap] = useState<Map | null>(null);

  const formMethods = useForm();

  useCheckApiStatus(setApiReady);

  useEffect(() => {
    const fetchExistingPlayers = async () => {
      const players = await getExistingPlayers();
      setExistingPlayers(players);
      if (players.length > 0) setSelectedPlayer(players[0]);
    };

    const fetchMaps = async () => {
      const maps = await getMaps();
      setMaps(maps);
      setSelectedMap(maps[0]);
    };

    if (apiReady) {
      fetchExistingPlayers();
      fetchMaps();
    }
  }, [apiReady]);

  const handleCreatePlayer = async (data: { name: string }) => {
    const newPlayer: NewPlayer = { name: data.name, mapId: selectedMap.id };
    const createdPlayer = await createNewPlayer(newPlayer);
    setExistingPlayers((players) => [...players, createdPlayer]);
    setSelectedPlayer(createdPlayer);
  };

  return (
    <div className={apiReady ? '' : 'blurred'}>
      {!apiReady && <Spinner />}
      <Container>
        <FormProvider {...formMethods}>
          <form onSubmit={formMethods.handleSubmit(handleCreatePlayer)}>
            <Stack spacing={5}>
              <PlayerNameInput />
              <MapSelector maps={maps} selectedMap={selectedMap} onMapSelected={setSelectedMap} />
              <MapDescription selectedMap={selectedMap} />
              <Button variant="outlined" type="submit">
                Create New Player
              </Button>
              {existingPlayers.length > 0 && (
                <>
                  <PlayerSelector
                    players={existingPlayers}
                    selectedPlayer={selectedPlayer}
                    onPlayerSelected={setSelectedPlayer}
                  />
                  <Button variant="outlined" onClick={() => continueWithPlayer(selectedPlayer)}>
                    Start
                  </Button>
                </>
              )}
            </Stack>
          </form>
        </FormProvider>
      </Container>
    </div>
  );
};

export default CreatePlayerPage;
