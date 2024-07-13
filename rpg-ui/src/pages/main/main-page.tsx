import { Grid } from "@mui/material";
import { useRef, useState } from "react";

import Sidebar from "../../components/sidebar/sidebar";
import CreatePlayerPage from "../player/create-player-page";
import AdventurePage from "../adventure/adventure-page";
import { existingPlayer } from "../../api/utils/player/player-api";

const MainPage = () => {
  const player = useRef<existingPlayer | null>(null);

  const continueWithPlayer = (existingPlayer: existingPlayer) => {
    player.current = existingPlayer;
    setCurrentPage(<AdventurePage existingPlayer={player.current} />);
  };

  const [currentPage, setCurrentPage] = useState(
    <CreatePlayerPage continueWithPlayer={continueWithPlayer} />
  );

  return (
    <Grid container>
      {player.current && (
        <Grid item>
          <Sidebar />
        </Grid>
      )}
      <Grid flexGrow={1} padding={5}>
        {currentPage}
      </Grid>
    </Grid>
  );
};

export default MainPage;