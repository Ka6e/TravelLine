import { useNavigate } from "react-router-dom"
import React, { useState } from "react";
import {
    Box,
    Button,
    Stack,
    TextField,
    Typography,
    Paper,
} from "@mui/material"

type FormProps = {
    russianValue: string,
    englishValue: string,
    onSubmit: (russian: string, english: string) => void;
}

export const Form = ({ russianValue = "", englishValue = "", onSubmit }: FormProps) => {

    const [russian, setRussian] = useState(russianValue);
    const [english, setEnglish] = useState(englishValue);

    const navigate = useNavigate();

    const handleSaveClick = () => {
        if (russian && english) {
            onSubmit(russian, english);
        }
    }

    const handleSubmit = (e: React.FormEvent<HTMLFormElement>) => {
        e.preventDefault();
        onSubmit(russian, english);
    }

    return (
        <Box
            sx={{
                minHeight: "auto",
                backgroundColor: "#f5f5f5",
            }}
        >
            <Paper
                elevation={3}
                sx={{
                    width: "100%",
                    backgroundColor: "white",
                    borderRadius: 2,
                }}
            >
                <Box
                    sx={{
                        p: 3,
                        borderBottom: "1px solid #e0e0e0"
                    }}
                >
                    <Typography
                        variant="h5"
                        component="h1"
                        sx={{
                            color: "#364963",
                            textAlign: "left"
                        }}
                    >
                        Словарное слово
                    </Typography>
                </Box>
                <Box
                    component="form"
                    onSubmit={handleSubmit}
                    sx={{ p: 4 }}
                >
                    <Stack spacing={4}>
                        <Box sx={{ display: "flex", alignItems: "center", width: "100%" }}>
                            <Typography
                                variant="body1"
                                textAlign={"left"}
                                sx={{
                                    color: "#364963",
                                    minWidth: "250px",
                                    mr: 10
                                }}
                            >
                                Слово на русском языке
                            </Typography>
                            <TextField
                                fullWidth
                                variant="outlined"
                                value={russian}
                                onChange={(e) => setRussian(e.target.value)}
                                error={!russian}
                                required
                                sx={{
                                    maxWidth: "250px"
                                }}
                            />
                        </Box>
                        <Box sx={{ display: "flex", alignItems: "center", width: "100%" }}>
                            <Typography
                                variant="body1"
                                textAlign={"left"}
                                sx={{
                                    color: "#364963",
                                    minWidth: "250px",
                                    mr: 10
                                }}
                            >
                                Перевод на английский язык
                            </Typography>
                            <TextField
                                fullWidth
                                variant="outlined"
                                value={english}
                                onChange={(e) => setEnglish(e.target.value)}
                                error={!english}
                                required
                                sx={{
                                    maxWidth: "250px"
                                }}
                            />
                        </Box>
                    </Stack>
                </Box>
            </Paper>
            <Box
                sx={{
                    display: "flex",
                    justifyContent: "flex-start",
                    mt: 3,
                    gap: 2
                }}
            >
                <Button
                    type="submit"
                    variant="contained"
                    disabled={!russian || !english}
                    onClick={handleSaveClick}
                >
                    СОХРАНИТЬ
                </Button>
                <Button
                    type="button"
                    variant="outlined"
                    onClick={() => navigate(-1)}
                >
                    ОТМЕНИТЬ
                </Button>
            </Box>
        </Box>
    );
}