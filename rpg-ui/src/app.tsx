import { createRoot } from 'react-dom/client';
import React from 'react';
import { ThemeProvider } from '@emotion/react';
import { CssBaseline, createTheme } from '@mui/material';
import MainPage from './pages/main/main-page';

// https://zenoo.github.io/mui-theme-creator/
const theme = createTheme({
  palette: {
    mode: 'dark',
    primary: {
      main: '#ffa000'
    },
    secondary: {
      main: '#9e9e9e'
    }
  }
});

const container = document.getElementById('app');

const root = createRoot(container);

root.render(
  <React.StrictMode>
    <ThemeProvider theme={theme}>
      <CssBaseline />
      <MainPage />
    </ThemeProvider>
  </React.StrictMode>
);
