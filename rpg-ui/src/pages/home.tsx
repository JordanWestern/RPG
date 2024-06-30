import { Container, Grid, Stack, Typography } from "@mui/material";
import Sidebar from "../components/sidebar/sidebar";
import LogTable from "../components/log-table/log-table";

export function Home() {
  return (
    <Grid container>
      <Grid item xs={4}>
        <Sidebar />
      </Grid>
      <Grid item xs={8} md={12}>
        <Container>
          <Stack spacing={5}>
            <Typography variant="h1">A very sexual, text-based adventure game.</Typography>
            <LogTable/>
          </Stack>
        </Container>
      </Grid>
    </Grid>
  );
}

export default Home;
