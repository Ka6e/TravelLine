import { useWordStore } from "../../store/store";
import { BackButton } from "../../Components/BackButton/BackButton";
import { useState, useEffect, useMemo } from "react";
import Checkbox from "@mui/material/Checkbox";
import { useNavigate } from "react-router-dom";
import {
    Box,
    Button,
    ListItemText,
    MenuItem,
    Paper,
    Select,
    Stack,
    TextField,
    Typography,
    type SelectChangeEvent,
} from "@mui/material";


type CurrentWord = {
    id: string;
    russian: string;
    english: string[];
};

function shuffle<T>(arr: T[]) {
    const a = [...arr];
    for (let i = a.length - 1; i > 0; i--) {
        const j = Math.floor(Math.random() * (i + 1));
        [a[i], a[j]] = [a[j], a[i]];
    }
    return a;
}

export const TestPage = () => {
    const store = useWordStore((state) => state);
    const navigate = useNavigate();

    const [currentWord, setCurrentWord] = useState<CurrentWord | null>(null);
    const [englishWords, setEnglishWords] = useState<string[]>([]);
    const [step, setStep] = useState(0); 
    const [correct, setCorrect] = useState(0);
    const [incorrect, setIncorrect] = useState(0);

    useEffect(() => {
        if (!store.words || store.words.length === 0) {
            navigate("/");
        }
    }, [store.words, navigate]);

    const order = useMemo(
        () => shuffle([...Array(store.words.length).keys()]),
        [store.words.length]
    );

    const allEnglishOptions = useMemo(() => {
        const all: string[] = [];
        for (const w of store.words) {
            const eng = Array.isArray(w.english) ? w.english : [w.english];
            for (const e of eng) {
                if (e) all.push(e);
            }
        }
        return Array.from(new Set(all)).sort();
    }, [store.words]);

    useEffect(() => {
        if (step >= order.length) {
            navigate("/result", { state: { correct, incorrect } });
            return;
        };

        const raw = store.words[order[step]];
        if (!raw) return;

        const normalized: CurrentWord = {
            id: String(raw.id),
            russian: raw.russian,
            english: Array.isArray(raw.english) ? raw.english : [raw.english],
        };

        setCurrentWord(normalized);
        setEnglishWords([]);
    }, [step, order, store.words, navigate, correct, incorrect]);

    const handleChange = (e: SelectChangeEvent<string[]>) => {
        const value = e.target.value;
        setEnglishWords(typeof value === "string" ? value.split(",") : value);
    };

    const handleCheck = () => {
        if (!currentWord) return;

        const selected = new Set(englishWords);
        const correctSet = new Set(currentWord.english);

        const isCorrect =
            selected.size === correctSet.size &&
            [...correctSet].every((x) => selected.has(x));

        if (isCorrect) setCorrect((v) => v + 1);
        else setIncorrect((v) => v + 1);

        setStep((s) => s + 1);
    };

    return (
        <Box>
            <Stack direction="row" spacing={2} mb={3}>
                <BackButton />
                <Typography variant="h3" sx={{ color: "#364963" }}>
                    Проверка знаний
                </Typography>
            </Stack>

            <Typography variant="body1" align="left" mb={3} sx={{ color: "#364963" }}>
                Слово: {Math.min(step + 1, store.words.length)} из {store.words.length}
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
