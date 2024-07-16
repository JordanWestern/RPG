import { Box, CircularProgress } from '@mui/material';

const Spinner = () => {
  return (
    <Box
      sx={{
        display: 'flex',
        justifyContent: 'center',
        alignItems: 'center',
        height: '100vh',
        backgroundColor: 'rgba(0, 0, 0, 0.8)',
        position: 'fixed',
        width: '100%',
        zIndex: 9999
      }}>
      <CircularProgress />
    </Box>
  );
};

export default Spinner;
