import { Box, Stack, Typography, Paper } from "@mui/material";
import { BackButton } from "../../Components/BackButton/BackButton";
import { Form } from "../../Components/Form/Form";
import { useEditWordPageState } from "./useEditWordState";

export const EditWordPageView = () => {
    const { wordToEdit, editWord } = useEditWordPageState();

    if (!wordToEdit) {
        return (
            <Box>
                <Stack direction="row" spacing={2}>
                    <BackButton />
                    <Typography variant="h3" sx={{ color: "#364963" }}>
                        Редактирование слова
                    </Typography>
                </Stack>
                <Paper sx={{ p: 2, mt: 2 }}>
                    <Typography variant="h4" sx={{ color: "#364963" }}>
                        Слово не найдено
                    </Typography>
                </Paper>
            </Box>
        );
    }

    return (
        <Box>
            <Stack direction="row" spacing={2} mb={3}>
                <BackButton />
                <Typography variant="h3" sx={{ color: "#364963" }}>
                    Редактирование слова
                </Typography>
            </Stack>

            <Form
                russianValue={wordToEdit.russian}
                englishValue={wordToEdit.english}
                onSubmit={editWord}
            />
        </Box>
    );
};
