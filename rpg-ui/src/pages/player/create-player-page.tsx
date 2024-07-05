import { Button, Container, FormGroup, Stack, TextField } from "@mui/material";
import { useState } from "react";
import { useNavigate } from "react-router-dom";
import Spinner from "../../shared/spinner";
import checkApiStatus from "../../api/utils/check-api-status";
import "./create-player-page.css";

const CreatePlayerPage = () => {
  const [apiReady, setApiReady] = useState(false);
  const navigate = useNavigate();

  checkApiStatus(setApiReady);

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
            />
            <Button variant="outlined" onClick={() => navigate("/main")}>
              Create New Player
            </Button>
          </Stack>
        </FormGroup>
      </Container>
    </div>
  );
};

export default CreatePlayerPage;
