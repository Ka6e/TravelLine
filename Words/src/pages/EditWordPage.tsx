import { Box, Paper, Stack, Typography } from "@mui/material";
import { BackButton } from "../Components/BackButton/BackButton";
import { useWordStore } from "../store/store";
import { useNavigate, useParams } from "react-router-dom";
import { Form } from "../Components/Form/Form";

export const EditWordPage = () => {

    const store = useWordStore((state) => state);
    const itemId = useParams<{ id: string }>();
    const navigate = useNavigate();


    const wordToEdit = store.words.find(word => word.id === itemId.id);

    const editWord = (rus: string, eng: string) => {
        if (itemId) {
            store.updateWord(itemId.id, rus, eng);
            navigate(-1);
        }
    }

    if (!wordToEdit) {
        return (
            <Box>
                <Stack
                    direction="row"
                    spacing={2}

                >
                    <BackButton />
                    <Typography
                        variant="h3"
                        sx={{
                            color: "#364963",
                        }}
                    >
                        Редактирование слова
                    </Typography>
                </Stack>
                <Paper>
                    <Typography
                        variant="h4"
                        sx={{
                            color: "#364963",
                        }}
                    >
                        Слово не найдено
                    </Typography>
                </Paper>
            </Box>
        );
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
                    Редактирование слова
                </Typography>
            </Stack>

            <Form russianValue={wordToEdit.russian} englishValue={wordToEdit.english} onSubmit={editWord}></Form>
        </Box>
    )
}