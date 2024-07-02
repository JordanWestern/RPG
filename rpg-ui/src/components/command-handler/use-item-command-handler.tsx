import { Autocomplete, TextField } from "@mui/material";

type UseItemCommandHandlerProps = {
  setCommandValid: (commandValid: boolean) => void;
};

const UseItemCommandHandler = ({
  setCommandValid,
}: UseItemCommandHandlerProps) => {
  const availableItems = [
    "Minor Potion",
    "Large Potion",
    "Minor Mana potion",
    "Attack Plus",
    "Defence Plus",
    "Wheel of cheese",
    "Fortified Wine",
  ];

  return (
    <Autocomplete
      disablePortal
      id="use-item"
      options={availableItems}
      sx={{ width: 300 }}
      renderInput={(params) => <TextField {...params} label="Item" />}
      onInputChange={(_, input) =>
        setCommandValid(availableItems.includes(input))
      }
    />
  );
};

export default UseItemCommandHandler;
