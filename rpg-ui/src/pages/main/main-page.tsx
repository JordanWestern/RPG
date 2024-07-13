import { Grid } from "@mui/material";
import { useState } from "react";

import Sidebar from "../../components/sidebar/sidebar";
import CreatePlayerPage from "../player/create-player-page";
import AdventurePage from "../adventure/adventure-page";

const MainPage = () => {
  const [currentPage, setCurrentPage] = useState(
    <CreatePlayerPage
      setCurrentPage={() => setCurrentPage(<AdventurePage />)}
    />
  );

  return (
    <Grid container>
      {currentPage.type !== CreatePlayerPage ? (
        <Grid item>
          <Sidebar />
        </Grid>
      ) : null}
      <Grid flexGrow={1} padding={5}>
        {currentPage}
      </Grid>
    </Grid>
  );
};

export default MainPage;
