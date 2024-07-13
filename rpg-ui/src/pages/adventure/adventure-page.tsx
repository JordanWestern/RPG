import { Box, Chip, Container, Grid, Stack, Typography } from "@mui/material";
import Sidebar from "../../components/sidebar/sidebar";
import LogTable from "../../components/log-table/log-table";
import CommandHandler from "../../components/command-handler/command-handler";
import "./adventure-page.css";
import { useState } from "react";
import Spinner from "../../shared/spinner";
import checkApiStatus from "../../api/utils/info/check-api-status";
import { existingPlayer } from "../../api/utils/player/player-api";

const AdventurePage = () => {
  const [apiReady, setApiReady] = useState(false);
  checkApiStatus(setApiReady);

  const player: existingPlayer = { id: "some", name: "dog" };

  return (
    <>
      <Stack>
        <Box paddingBottom={2}>
          <Typography variant="h2">
            Your adventure awaits you, {player.name}.
          </Typography>
        </Box>
        <Chip
          label="Alpha"
          color="info"
          variant="outlined"
          sx={{ width: 60 }}
        />
      </Stack>
      <Stack spacing={5} paddingTop={5}>
        <LogTable />
        <CommandHandler />
      </Stack>
    </>
  );
};

export default AdventurePage;
