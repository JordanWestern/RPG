import {
  Paper,
  Table,
  TableBody,
  TableCell,
  TableContainer,
  TableHead,
  TableRow,
} from "@mui/material";

function createData(time: string, logMessage: string) {
  return { time, logMessage };
}

const dummyDataRows = [
  createData("19:36:04", "You took 15 damage from a skeleton."),
  createData("19:36:56", "You drank a health potion."),
  createData(
    "19:38:33",
    "You travelled to Mordor. Its a vast landscape, filled with rows of Trolls and Orcs weilding crudely forged weapons. It looks like they might be preparing for war. Nothing has changed since the last time you came here."
  ),
  createData("19:39:01", "You encountered a troll."),
  createData("19:39:11", "You gave 35 damage to a troll."),
  createData("19:39:15", "You took 22 damage from a troll."),
];

export default function LogTable() {
  return (
    <TableContainer component={Paper} sx={{ maxHeight: 300 }}>
      <Table sx={{ minWidth: 650 }} aria-label="simple table">
        <TableHead>
          <TableRow>
            <TableCell>Time</TableCell>
            <TableCell>Log message</TableCell>
          </TableRow>
        </TableHead>
        <TableBody>
          {dummyDataRows.map((row, index) => (
            <TableRow key={index}>
              <TableCell>{row.time}</TableCell>
              <TableCell>{row.logMessage}</TableCell>
            </TableRow>
          ))}
        </TableBody>
      </Table>
    </TableContainer>
  );
}
