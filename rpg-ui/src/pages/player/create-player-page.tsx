import {
  Button,
  Container,
  FormControl,
  FormGroup,
  InputLabel,
  MenuItem,
  Select,
  Stack,
  TextField,
} from "@mui/material";
import { useRef, useState } from "react";
import { useNavigate } from "react-router-dom";
import Spinner from "../../shared/spinner";
import checkApiStatus from "../../api/utils/info/check-api-status";
import {
  createNewPlayer,
  existingPlayer,
  newPlayer,
} from "../../api/utils/player/create-new-player";
import "./create-player-page.css";

const CreatePlayerPage = () => {
  const [existingPlayers, setExistingPlayers] = useState<existingPlayer[]>([]); // TODO: Fetch from api bruh.
  const [apiReady, setApiReady] = useState(false);
  const [selectedPlayer, setSelectedPlayer] = useState<existingPlayer | null>(
    null
  );
  const playerName = useRef("Grognak the barbarian");
  const navigate = useNavigate();

  checkApiStatus(setApiReady);

  const handleCreatePlayer = async () => {
    const newPlayer: newPlayer = { name: playerName.current };
    const createdPlayer = await createNewPlayer(newPlayer);
    setExistingPlayers((existingPlayers) => [
      ...existingPlayers,
      createdPlayer,
    ]);
    setSelectedPlayer(createdPlayer);
  };

  const onStartClick = () => {
    navigate("/main", { state: { player: selectedPlayer } });
  };

  return (
    <div className={apiReady ? "" : "blurred"}>
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
            <Button variant="outlined" onClick={handleCreatePlayer}>
              Create New Player
            </Button>
            {existingPlayers.length > 0 && (
              <>
                <FormControl variant="standard">
                  <InputLabel id="select-player-label">
                    Select Player
                  </InputLabel>
                  <Select
                    id="select-player"
                    labelId="select-player-label"
                    value={selectedPlayer?.name ?? ""}
                    onChange={(e) =>
                      setSelectedPlayer(
                        existingPlayers.find(
                          (player) => (player.name = e.target.value)
                        )
                      )
                    }
                  >
                    {existingPlayers.map((existingPlayer) => (
                      <MenuItem
                        key={existingPlayer.id}
                        value={existingPlayer.name}
                      >
                        {existingPlayer.name}
                      </MenuItem>
                    ))}
                  </Select>
                </FormControl>
                <Button variant="outlined" onClick={onStartClick}>
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
