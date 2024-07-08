import { Box, Chip, Container, Grid, Stack, Typography } from "@mui/material";
import Sidebar from "../../components/sidebar/sidebar";
import LogTable from "../../components/log-table/log-table";
import CommandHandler from "../../components/command-handler/command-handler";
import { useLocation } from "react-router-dom";
import { existingPlayer } from "../../api/utils/player/create-new-player";
import "./main-page.css";

const MainPage = () => {
  const location = useLocation();
  const player: existingPlayer = location.state?.player;

  return (
    <Grid container>
      <Grid item xs={6}>
        <Sidebar />
      </Grid>
      <Grid item xs={8} md={12}>
        <Container>
          <Stack>
            <Box paddingBottom={2}>
              <Typography variant="h2">
                Your adventure awaits, {player.name}.
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
        </Container>
      </Grid>
    </Grid>
  );
};

export default MainPage;
