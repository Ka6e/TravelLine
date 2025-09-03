import { BackButton } from "../Components/BackButton/BackButton";
import { Form } from "../Components/Form/Form";
import { useNavigate } from "react-router-dom";
import { useWordStore } from "../store/store";
import {
    Box,
    Stack,
    Typography,
} from "@mui/material";

export const AddWordPage = () => {

    const store = useWordStore((store) => store);

    const navigate = useNavigate();

    const handlAdd = (russian: string, english: string) => {
        store.addWord(russian, english);
        navigate(-1);
    }

    return (
        <Box>
            <Stack
                direction="row"
                spacing={2}
                mb={3}
            >
                <BackButton />
                <Typography
                    variant="h3"
                    sx={{
                        color: "#364963",
                    }}
                >
                    Добавление слова
                </Typography>
            </Stack>
            <Form russianValue="" englishValue="" onSubmit={handlAdd}></Form>
        </Box>
    )
}
