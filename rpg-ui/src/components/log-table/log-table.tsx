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
  createData("19:39:11", "You dealt 35 damage to a troll."),
  createData("19:39:15", "You took 22 damage from a troll."),
  createData("19:39:30", "You dealt 35 damage to a troll."),
  createData(
    "19:39:31",
    "The troll died. You looted the troll of the minor healing potion."
  ),
  createData(
    "19:39:59",
    "You travelled to the Forbiddon forest. It's cold and quiet."
  ),
  createData("19:40:01", "You encountered a dire wolf."),
  createData("19:36:04", "You took 15 damage from a skeleton."),
  createData("19:36:56", "You drank a health potion."),
  createData(
    "19:38:33",
    "You travelled to Mordor. Its a vast landscape, filled with rows of Trolls and Orcs weilding crudely forged weapons. It looks like they might be preparing for war. Nothing has changed since the last time you came here."
  ),
  createData("19:39:01", "You encountered a troll."),
  createData("19:39:11", "You dealt 35 damage to a troll."),
  createData("19:39:15", "You took 22 damage from a troll."),
  createData("19:39:30", "You dealt 35 damage to a troll."),
  createData(
    "19:39:31",
    "The troll died. You looted the troll of the minor healing potion."
  ),
  createData(
    "19:39:59",
    "You travelled to the Forbiddon forest. It's cold and quiet."
  ),
  createData("19:40:01", "You encountered a dire wolf.")
];

export default function LogTable() {
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
