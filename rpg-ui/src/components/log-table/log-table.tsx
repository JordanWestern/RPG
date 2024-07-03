import { HubConnectionBuilder } from "@microsoft/signalr";
import {
  Paper,
  Table,
  TableBody,
  TableCell,
  TableContainer,
  TableHead,
  TableRow,
} from "@mui/material";
import { useEffect, useState } from "react";

const LogTable = () => {
  const [logs, setLogs] = useState([]);

  useEffect(() => {
    const connection = new HubConnectionBuilder()
      .withUrl("http://localhost:5028/gameEventHub")
      .withAutomaticReconnect()
      .build();

    connection.on("ReceiveLog", (time, logMessage) => {
      setLogs((prevLogs) => [...prevLogs, { time, logMessage }]);
    });

    connection
      .start()
      .catch((err) => console.error("Connection failed: ", err));

    return () => {
      connection.stop();
    };
  }, []);

  return (
    <TableContainer component={Paper} sx={{ height: 500, minHeight: 200 }}>
      <Table
        stickyHeader
        sx={{ minWidth: 650 }}
        aria-label="simple table"
        size="small"
      >
        <TableHead>
          <TableRow>
            <TableCell>Time</TableCell>
            <TableCell>Log message</TableCell>
          </TableRow>
        </TableHead>
        <TableBody>
          {logs.map((row, index) => (
            <TableRow key={index}>
              <TableCell>{row.time}</TableCell>
              <TableCell>{row.logMessage}</TableCell>
            </TableRow>
          ))}
        </TableBody>
      </Table>
    </TableContainer>
  );
};

export default LogTable;
