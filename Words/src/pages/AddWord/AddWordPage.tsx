import { Box, Stack, Typography } from "@mui/material";
import { BackButton } from "../../Components/BackButton/BackButton";
import { Form } from "../../Components/Form/Form";
import { useAddWordPageState } from "./useAddWordState";

export const AddWordPage = () => {
    const { handleAdd } = useAddWordPageState();

    return (
        <Box>
            <Stack direction="row" spacing={2} mb={3}>
                <BackButton />
                <Typography variant="h3" sx={{ color: "#364963" }}>
                    Добавление слова
                </Typography>
            </Stack>

            <Form russianValue="" englishValue="" onSubmit={handleAdd} />
        </Box>
    );
};
