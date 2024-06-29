import { Container, Grid, Stack, Typography } from "@mui/material";
import Sidebar from "../components/sidebar/sidebar";
import LogTable from "../components/log-table/log-table";

export function Main() {
  return (
    <Grid container>
      <Grid item>
        <Sidebar />
      </Grid>
      <Grid item>
        <Container>
          <Stack spacing={5} justifyContent={"center"}>
            <Typography variant="h1">A very sexual text-based adventure game.</Typography>
            <LogTable/>
          </Stack>
        </Container>
      </Grid>
    </Grid>
  );
}

export default Main;
