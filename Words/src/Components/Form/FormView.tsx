import { useNavigate } from "react-router-dom";
import {
    Box,
    Button,
    Stack,
    TextField,
    Typography,
    Paper,
} from "@mui/material";

type FormViewProps = {
    russian: string;
    english: string;
    handleChangeRussian: (value: string) => void;
    handleChangeEnglish: (value: string) => void;
    handleSave: () => void;
};

export const FormView = ({
    russian,
    english,
    handleChangeRussian,
    handleChangeEnglish,
    handleSave,
}: FormViewProps) => {
    const navigate = useNavigate();

    return (
        <Box sx={{ minHeight: "auto", backgroundColor: "#f5f5f5" }}>
            <Paper elevation={3} sx={{ width: "100%", backgroundColor: "white", borderRadius: 2 }}>
                <Box sx={{ p: 3, borderBottom: "1px solid #e0e0e0" }}>
                    <Typography variant="h5" component="h1" sx={{ color: "#364963", textAlign: "left" }}>
                        Словарное слово
                    </Typography>
                </Box>
                <Box component="form" sx={{ p: 4 }}>
                    <Stack spacing={4}>
                        <Box sx={{ display: "flex", alignItems: "center", width: "100%" }}>
                            <Typography variant="body1" textAlign="left" sx={{ color: "#364963", minWidth: "250px", mr: 10 }}>
                                Слово на русском языке
                            </Typography>
                            <TextField
                                fullWidth
                                variant="outlined"
                                value={russian}
                                onChange={(e) => handleChangeRussian(e.target.value)}
                                error={!russian}
                                required
                                sx={{ maxWidth: "250px" }}
                            />
                        </Box>
                        <Box sx={{ display: "flex", alignItems: "center", width: "100%" }}>
                            <Typography variant="body1" textAlign="left" sx={{ color: "#364963", minWidth: "250px", mr: 10 }}>
                                Перевод на английский язык
                            </Typography>
                            <TextField
                                fullWidth
                                variant="outlined"
                                value={english}
                                onChange={(e) => handleChangeEnglish(e.target.value)}
                                error={!english}
                                required
                                sx={{ maxWidth: "250px" }}
                            />
                        </Box>
                    </Stack>
                </Box>
            </Paper>
            <Box sx={{ display: "flex", justifyContent: "flex-start", mt: 3, gap: 2 }}>
                <Button type="submit" variant="contained" disabled={!russian || !english} onClick={handleSave}>
                    СОХРАНИТЬ
                </Button>
                <Button type="button" variant="outlined" onClick={() => navigate(-1)}>
                    ОТМЕНИТЬ
                </Button>
            </Box>
        </Box>
    );
};
