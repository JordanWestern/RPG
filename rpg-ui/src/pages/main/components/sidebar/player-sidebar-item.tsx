import SidebarItem from './sidebar-item';
import PersonIcon from '@mui/icons-material/Person';

type PlayerSideBarItemProps = {
  expanded: boolean;
};

const PlayerSideBarItem = ({ expanded }: PlayerSideBarItemProps) => {
  return (
    <>
      <SidebarItem
        text="Player Stats"
        icon={<PersonIcon />}
        expanded={expanded}
        onClick={() => {
          console.log('clicked');
        }}
      />
    </>
  );
};

export default PlayerSideBarItem;
