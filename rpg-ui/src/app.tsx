import { createRoot } from "react-dom/client";
import Main from "./pages/Main";
import React from "react";
import { ThemeProvider } from "@emotion/react";
import { createTheme } from "@mui/material";

// https://zenoo.github.io/mui-theme-creator/
const theme = createTheme({
  palette: {
    mode: "dark",
    primary: {
      main: "#ffa000",
    },
    secondary: {
      main: "#9e9e9e",
    },
  },
});

const container = document.getElementById("app");

const root = createRoot(container!);

root.render(
  <React.StrictMode>
    <ThemeProvider theme={theme}>
      <Main />
    </ThemeProvider>
  </React.StrictMode>
);
