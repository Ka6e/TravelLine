import CheckCircleOutlineIcon from '@mui/icons-material/CheckCircleOutline';
import MenuBookOutlinedIcon from '@mui/icons-material/MenuBookOutlined';
import CloseOutlinedIcon from '@mui/icons-material/CloseOutlined';
import { useLocation, useNavigate } from "react-router-dom";
import { useWordStore } from "../store/store";
import {
    Box,
    Button,
    CardContent,
    Card,
    Stack,
    Typography,

} from "@mui/material";

export const ResultPage = () => {

    const store = useWordStore((state) => state);
    const navigate = useNavigate();
    const location = useLocation();

    const { correct = 0, incorrect = 0 } = location.state || {};

    return (
        <Box>
            <Typography
                variant="h3"
                textAlign={"left"}
                sx={{
                    color: "#364963",
                    mb: 2
                }}
            >
                Результат проверки знаний
            </Typography>
            <Card
                sx={{
                    maxWidth: 400,
                    maxHeight: 500,
                    mb: 4
                }}
            >
                <CardContent>
                    <Typography
                        variant="h6"
                        textAlign={"left"}
                        sx={{
                            color: "#5985c4ff",
                            mb: 2
                        }}
                    >
                        Ответы
                    </Typography>
                    <Stack direction={"row"} borderBottom={"1px solid grey"} mb={2}>
                        <CheckCircleOutlineIcon color="success" />
                        <Typography variant="body1" gutterBottom ml={1}>
                            Правильные
                        </Typography>
                        <Typography variant="body1" sx={{ marginLeft: "auto" }}>
                            {correct}
                        </Typography>
                    </Stack>
                    <Stack direction={"row"} borderBottom={"1px solid grey"} mb={2}>
                        <CloseOutlinedIcon color="error" />
                        <Typography variant="body1" gutterBottom ml={1}>
                            Неправильные
                        </Typography>
                        <Typography variant="body1" sx={{ marginLeft: "auto" }} >
                            {incorrect}
                        </Typography>
                    </Stack>
                    <Stack direction={"row"} borderBottom={"1px solid grey"}>
                        <MenuBookOutlinedIcon color="secondary" />
                        <Typography variant="body1" gutterBottom ml={1}>
                            Всего слов
                        </Typography>
                        <Typography sx={{ marginLeft: "auto" }}>
                            {store.words.length}
                        </Typography>
                    </Stack>
                </CardContent>
            </Card>
            <Stack direction={"row"} spacing={2}>
                <Button
                    variant="contained"
                    onClick={() => navigate("/test")}
                    sx={{
                        px: 4,
                        py: 1.5,
                        fontWeight: "bold",
                        fontSize: "1rem",
                        textTransform: "none",
                        minWidth: 120,
                        backgroundColor: "#1976d2",
                        "&:hover": {
                            backgroundColor: "#1565c0"
                        }
                    }}
                >
                    ПРОВЕРИТЬ ЗНАНИЯ ЕЩЁ РАЗ
                </Button>
                <Button
                    variant="outlined"
                    onClick={() => navigate("/")}
                >
                    ВЕРНУТЬСЯ В НАЧАЛО
                </Button>
            </Stack>
        </Box>
    );
}