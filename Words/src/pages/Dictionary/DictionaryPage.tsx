import {
    Stack,
    Box,
    Typography,
    Button,
    Table,
    TableContainer,
    Paper,
    TableHead,
    TableRow,
    TableCell,
    TableBody,
    IconButton,
    Menu,
    MenuItem
} from "@mui/material";
import MenuIcon from '@mui/icons-material/Menu';
import { BackButton } from "../../Components/BackButton/BackButton";
import { useDictionaryPageState } from "./useDictionaryPageState";

export const DictionaryPage = () => {
    const {
        store,
        anchorEl,
        open,
        handleClick,
        handleClose,
        handleEdit,
        handleDelete,
        handleAddNew,
    } = useDictionaryPageState();

    return (
        <Box sx={{ textAlign: "left", width: "100%" }}>
            <Stack direction={"row"} spacing={2} mb={3}>
                <BackButton />
                <Typography variant="h3" sx={{ color: "#364963" }}>
                    Словарь
                </Typography>
            </Stack>
            <Button variant="contained" onClick={handleAddNew} sx={{ mb: 3 }}>
                + ДОБАВИТЬ СЛОВО
            </Button>
            <TableContainer component={Paper}>
                <Table aria-label="simple table">
                    <TableHead sx={{ backgroundColor: "#dfe4ec" }}>
                        <TableRow>
                            <TableCell>Слово на русском</TableCell>
                            <TableCell align="center">Слово на английском</TableCell>
                            <TableCell align="right">Действие</TableCell>
                        </TableRow>
                    </TableHead>
                    <TableBody>
                        {store.words.map((word) => (
                            <TableRow
                                key={word.id}
                                sx={{ '&:last-child td, &:last-child th': { border: 0 } }}
                            >
                                <TableCell>{word.russian}</TableCell>
                                <TableCell align="center">{word.english}</TableCell>
                                <TableCell align="right">
                                    <IconButton
                                        aria-label="more"
                                        aria-controls={open ? `word-menu-${word.id}` : undefined}
                                        aria-haspopup="true"
                                        aria-expanded={open ? 'true' : undefined}
                                        onClick={(e) => handleClick(e, word.id)}
                                    >
                                        <MenuIcon />
                                    </IconButton>
                                </TableCell>
                            </TableRow>
                        ))}
                    </TableBody>
                </Table>
            </TableContainer>
            <Menu
                id="word-menu"
                anchorEl={anchorEl}
                open={open}
                onClose={handleClose}
                anchorOrigin={{ vertical: "top", horizontal: "left" }}
                transformOrigin={{ vertical: "top", horizontal: "left" }}
            >
                <MenuItem onClick={handleEdit}>Редактировать</MenuItem>
                <MenuItem onClick={handleDelete}>Удалить</MenuItem>
            </Menu>
        </Box>
    );
};
