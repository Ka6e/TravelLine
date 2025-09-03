import { Box, Button, Checkbox, ListItemText, MenuItem, Paper, Select, Stack, TextField, Typography } from "@mui/material";
import { BackButton } from "../../Components/BackButton/BackButton";
import { useTestPageState } from "./useTestPageStore";

export const TestPage = () => {
    const {
        currentWord,
        englishWords,
        step,
        handleChange,
        handleCheck,
        allEnglishOptions,
        storeWordsLength,
    } = useTestPageState();

    return (
        <Box>
            <Stack direction="row" spacing={2} mb={3}>
                <BackButton />
                <Typography variant="h3" sx={{ color: "#364963" }}>
                    Проверка знаний
                </Typography>
            </Stack>
            <Typography variant="body1" align="left" mb={3} sx={{ color: "#364963" }}>
                Слово: {Math.min(step + 1, storeWordsLength)} из {storeWordsLength}
            </Typography>
            <Paper elevation={1} sx={{ p: 3, mb: 3 }}>
                <Stack spacing={3}>
                    <Stack direction="row" alignItems="center">
                        <Typography variant="body1" mb={1} mr={10}>
                            Слово на русском языке
                        </Typography>
                        <TextField
                            id="russianField"
                            variant="outlined"
                            value={currentWord?.russian ?? ""}
                            disabled
                            sx={{
                                width: "250px",
                                '& .MuiInputBase-input': {
                                    textAlign: "center"
                                }
                            }}
                        />
                    </Stack>

                    <Stack direction="row" alignItems="center">
                        <Typography variant="body1" mr={6}>
                            Перевод на английский язык
                        </Typography>
                        <Select
                            id="englishSelect"
                            multiple
                            value={englishWords}
                            onChange={handleChange}
                            renderValue={(selected) => selected.join(", ")}
                            sx={{ width: "250px" }}
                        >
                            {allEnglishOptions.map((opt) => (
                                <MenuItem key={opt} value={opt}>
                                    <Checkbox checked={englishWords.includes(opt)} />
                                    <ListItemText primary={opt} />
                                </MenuItem>
                            ))}
                        </Select>
                    </Stack>
                </Stack>
            </Paper>
            <Box textAlign="left" mt={4}>
                <Button disabled={!englishWords.length} variant="contained" onClick={handleCheck}>
                    ПРОВЕРИТЬ
                </Button>
            </Box>
        </Box>
    );
};
