import { Box, Chip, Stack, Typography } from "@mui/material";
import LogTable from "../../components/log-table/log-table";
import CommandHandler from "../../components/command-handler/command-handler";
import "./adventure-page.css";
import { existingPlayer } from "../../api/utils/player/player-api";

type AdventurePageProps = {
  existingPlayer: existingPlayer;
};

const AdventurePage = ({ existingPlayer }: AdventurePageProps) => {
  return (
    <>
      <Stack>
        <Box paddingBottom={2}>
          <Typography variant="h2">
            Your adventure awaits you, {existingPlayer.name}.
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
