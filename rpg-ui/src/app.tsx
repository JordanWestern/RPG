import { createRoot } from "react-dom/client";
import { Home } from "./pages/home";
import React from "react";
import { ThemeProvider } from "@emotion/react";
import { ThemeOptions, createTheme } from "@mui/material";

// https://zenoo.github.io/mui-theme-creator/
const theme = createTheme({
  palette: {
    mode: 'dark',
    primary: {
      main: '#ffa000',
    },
    secondary: {
      main: '#9e9e9e',
    },
  },
});

const root = createRoot(document.body);
root.render(
  <React.StrictMode>
    <ThemeProvider theme={theme}>
      <Home />
    </ThemeProvider>
  </React.StrictMode>
);
