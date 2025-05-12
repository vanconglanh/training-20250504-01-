import React, { useState } from 'react';
import { Box, Button, IconButton, Dialog, DialogTitle, DialogContent, DialogContentText, DialogActions, Table, TableBody, TableCell, TableContainer, TableHead, TableRow, Checkbox, Paper, Tooltip } from '@mui/material';
import DeleteIcon from '@mui/icons-material/Delete';
import ViewColumnIcon from '@mui/icons-material/ViewColumn';
import { usePermissions } from '@/hooks/usePermissions';
import { Menu } from '@/config/constant/feature';
import { PermissionAction } from '@/config/enum/PermissionAction';

// Dummy data for roles
const roles = [
  { id: '1', name: 'Admin', description: 'Administrator role' },
  { id: '2', name: 'Manager', description: 'Manager role' },
  { id: '3', name: 'User', description: 'User role' },
];

const RolesList: React.FC = () => {
  const { hasPermission } = usePermissions();
  const canDelete = hasPermission(Menu.ROLES, PermissionAction.DELETE);

  const [selected, setSelected] = useState<string[]>([]);
  const [openDialog, setOpenDialog] = useState(false);

  const handleSelectAll = (event: React.ChangeEvent<HTMLInputElement>) => {
    if (event.target.checked) {
      setSelected(roles.map((r) => r.id));
    } else {
      setSelected([]);
    }
  };

  const handleSelect = (id: string) => {
    setSelected((prev) =>
      prev.includes(id) ? prev.filter((sid) => sid !== id) : [...prev, id]
    );
  };

  const handleDeleteClick = () => {
    setOpenDialog(true);
  };

  const handleDialogClose = () => {
    setOpenDialog(false);
  };

  const handleDialogConfirm = () => {
    // TODO: Call API to delete selected roles
    setOpenDialog(false);
    setSelected([]);
  };

  return (
    <Box p={3}>
      <Box display="flex" justifyContent="flex-end" mb={2} gap={1}>
        <Tooltip title="Columns">
          <IconButton color="primary">
            <ViewColumnIcon />
          </IconButton>
        </Tooltip>
        {canDelete && (
          <Tooltip title="Delete selected">
            <span>
              <IconButton
                color="error"
                disabled={selected.length === 0}
                onClick={handleDeleteClick}
              >
                <DeleteIcon />
              </IconButton>
            </span>
          </Tooltip>
        )}
      </Box>
      <TableContainer component={Paper}>
        <Table>
          <TableHead>
            <TableRow>
              <TableCell padding="checkbox">
                <Checkbox
                  indeterminate={selected.length > 0 && selected.length < roles.length}
                  checked={roles.length > 0 && selected.length === roles.length}
                  onChange={handleSelectAll}
                />
              </TableCell>
              <TableCell>Name</TableCell>
              <TableCell>Description</TableCell>
            </TableRow>
          </TableHead>
          <TableBody>
            {roles.map((role) => (
              <TableRow key={role.id} selected={selected.includes(role.id)}>
                <TableCell padding="checkbox">
                  <Checkbox
                    checked={selected.includes(role.id)}
                    onChange={() => handleSelect(role.id)}
                  />
                </TableCell>
                <TableCell>{role.name}</TableCell>
                <TableCell>{role.description}</TableCell>
              </TableRow>
            ))}
          </TableBody>
        </Table>
      </TableContainer>
      {/* Dialog xác nhận xóa */}
      <Dialog open={openDialog} onClose={handleDialogClose}>
        <DialogTitle>Confirm Delete</DialogTitle>
        <DialogContent>
          <DialogContentText>
            Are you sure you want to delete {selected.length} role(s)? This action cannot be undone.
          </DialogContentText>
        </DialogContent>
        <DialogActions>
          <Button onClick={handleDialogClose}>Cancel</Button>
          <Button onClick={handleDialogConfirm} color="error" variant="contained">Delete</Button>
        </DialogActions>
      </Dialog>
    </Box>
  );
};

export default RolesList;
