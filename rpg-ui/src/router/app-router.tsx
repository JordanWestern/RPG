import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import CreatePlayerPage from "../pages/player/create-player-page";
import MainPage from "../pages/main/main-page";

const AppRouter = () => (
  <Router>
    <Routes>
      <Route path="/main_window" element={<CreatePlayerPage />} />
      <Route path="/main" element={<MainPage />} />
    </Routes>
  </Router>
);

export default AppRouter;
