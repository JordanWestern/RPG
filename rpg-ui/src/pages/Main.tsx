import { Box, Chip, CircularProgress, Container, Grid, Stack, Typography } from "@mui/material";
import Sidebar from "../components/sidebar/sidebar";
import LogTable from "../components/log-table/log-table";
import CommandHandler from "../components/command-handler/command-handler";
import { useEffect, useState } from "react";
import axios from 'axios';

const Spinner = () => (
  <Box
    sx={{
      display: 'flex',
      justifyContent: 'center',
      alignItems: 'center',
      height: '100vh',
      backgroundColor: 'rgba(255, 255, 255, 0.8)',
      position: 'fixed',
      width: '100%',
      zIndex: 9999,
    }}
  >
    <CircularProgress />
  </Box>
);

export function Main() {
  const [apiReady, setApiReady] = useState(false);

  useEffect(() => {
    const checkApiStatus = async () => {
      try {
        const response = await axios.get('http://localhost:5028/api/info/ready'); // Adjust the URL to match your API endpoint
        if (response.status === 200) {
          setApiReady(true);
          clearInterval(intervalId); // Clear the interval once API is ready
        }
      } catch (error) {
        console.error('API is not ready:', error);
      }
    };

    const intervalId = setInterval(checkApiStatus, 3000); // Check every 3 seconds

    return () => clearInterval(intervalId); // Clear interval on component unmount
  }, []);

  if (!apiReady) {
    return <Spinner />;
  }
  
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
