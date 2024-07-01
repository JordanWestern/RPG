import { SidebarItem } from "../sidebar/sidebar-item";
import PersonIcon from "@mui/icons-material/Person";
import Modal from "../modal/modal";
import { Typography } from "@mui/material";
import { useState } from "react";

type PlayerSideBarItemProps = {
  expanded: boolean;
};

export function PlayerSideBarItem({ expanded }: PlayerSideBarItemProps) {
  const [modalOpen, openModal] = useState(false);

  return (
    <>
      <SidebarItem
        text="Player"
        icon={<PersonIcon />}
        expanded={expanded}
        onClick={() => openModal(true)}
      />
      <Modal
        modalOpen={modalOpen}
        closeModal={() => openModal(false)}
        content={
          <>
            <Typography>Player</Typography>
          </>
        }
      />
    </>
  );
}
