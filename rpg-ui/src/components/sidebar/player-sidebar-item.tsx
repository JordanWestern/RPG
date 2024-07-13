import SidebarItem from "../sidebar/sidebar-item";
import PersonIcon from "@mui/icons-material/Person";

type PlayerSideBarItemProps = {
  expanded: boolean;
};

const PlayerSideBarItem = ({ expanded }: PlayerSideBarItemProps) => {
  return (
    <>
      <SidebarItem
        text="Player"
        icon={<PersonIcon />}
        expanded={expanded}
        onClick={() => {}}
      />
    </>
  );
};

export default PlayerSideBarItem;
