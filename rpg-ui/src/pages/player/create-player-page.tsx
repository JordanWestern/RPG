import { Button, Container, FormGroup, Stack, TextField } from "@mui/material";
import { useRef, useState } from "react";
import { useNavigate } from "react-router-dom";
import Spinner from "../../shared/spinner";
import checkApiStatus from "../../api/utils/info/check-api-status";
import {
  createNewPlayer,
  newPlayer,
} from "../../api/utils/player/create-new-player";
import "./create-player-page.css";

const CreatePlayerPage = () => {
  const [apiReady, setApiReady] = useState(false);
  const playerName = useRef("Grognak the barbarian");
  const navigate = useNavigate();

  checkApiStatus(setApiReady);

  const handleCreatePlayer = async () => {
    const newPlayer: newPlayer = { name: playerName.current };
    const response = await createNewPlayer(newPlayer);
    navigate("/main", { state: { player: response.data } });
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
          </Stack>
        </FormGroup>
      </Container>
    </div>
  );
};

export default CreatePlayerPage;
