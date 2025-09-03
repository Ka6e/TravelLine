import { Box, Button, Stack, Typography } from "@mui/material"
import { useNavigate } from "react-router-dom"

export const HomePage = () => {
    const navigate = useNavigate();

    return (
        <Stack
            direction={"row"}
        >
            <Box>
                <Typography variant="h3" color="#364963" mb={3}>
                    Выберите режим
                </Typography>
                <Button
                    variant="contained"
                    onClick={() => navigate("/dictionary")}
                    sx={{ mr: 2 }}
                >
                    Заполнить словарь
                </Button>
                <Button
                    variant="outlined"
                    onClick={() => navigate("/test")}
                >
                    Проверить знания
                </Button>
            </Box>
        </Stack>
    )
}