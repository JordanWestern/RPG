import { Chip, Container, Grid, Stack, Typography } from "@mui/material";
import Sidebar from "../components/sidebar/sidebar";
import LogTable from "../components/log-table/log-table";
import CommandHandler from "../components/command-handler/command-handler";

export function Home() {
  return (
    <Grid container>
      <Grid item xs={6}>
        <Sidebar />
      </Grid>
      <Grid item xs={8} md={12}>
        <Container>
          <Stack>
            <Typography variant="h1">
              A very sexual, text-based adventure game.
            </Typography>
            <Chip
              label="Alpha"
              color="info"
              variant="outlined"
              sx={{ width: 60 }}
            />
          </Stack>
          <Stack spacing={5} paddingTop={10}>
            <LogTable />
            <CommandHandler />
          </Stack>
        </Container>
      </Grid>
    </Grid>
  );
}

export default Home;
