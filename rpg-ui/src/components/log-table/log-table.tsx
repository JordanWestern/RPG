import { HubConnectionBuilder } from '@microsoft/signalr';
import {
  Paper,
  Table,
  TableBody,
  TableCell,
  TableContainer,
  TableHead,
  TableRow
} from '@mui/material';
import { useEffect, useState, useRef } from 'react';
import { gameLog, getGameLogs } from '../../api/game-logs/game-logs-api';

type LogTableProps = {
  playerId: string;
};

const LogTable = ({ playerId }: LogTableProps) => {
  const [logs, setLogs] = useState<gameLog[]>([]);
  const lastLogRef = useRef(null);

  useEffect(() => {
    const fetchGameLogs = async () => {
      const logs = await getGameLogs(playerId);
      setLogs(logs);
    };

    fetchGameLogs();
  }, [playerId]);

  useEffect(() => {
    const connection = new HubConnectionBuilder()
      .withUrl('http://localhost:5028/gameEventHub')
      .withAutomaticReconnect()
      .build();

    connection.on('GameEvent', (gameLog: gameLog) => {
      setLogs((prevLogs) => [
        ...prevLogs,
        { id: gameLog.id, date: gameLog.date, logMessage: gameLog.logMessage }
      ]);
    });

    connection.start().catch((err) => console.error('Connection failed: ', err));

    return () => {
      connection.stop();
    };
  }, []);

  useEffect(() => {
    if (lastLogRef.current) {
      lastLogRef.current.scrollIntoView({ behavior: 'smooth' });
    }
  }, []);

  return (
    <TableContainer component={Paper} sx={{ height: 500, minHeight: 200 }}>
      <Table stickyHeader sx={{ minWidth: 650 }} aria-label="simple table" size="small">
        <TableHead>
          <TableRow>
            <TableCell>Time</TableCell>
            <TableCell>Log message</TableCell>
          </TableRow>
        </TableHead>
        <TableBody>
          {logs.map((row, index) => (
            <TableRow key={index} ref={index === logs.length - 1 ? lastLogRef : null}>
              <TableCell>{row.date}</TableCell>
              <TableCell>{row.logMessage}</TableCell>
            </TableRow>
          ))}
        </TableBody>
      </Table>
    </TableContainer>
  );
};

export default LogTable;
