import { useWordStore } from "../../store/store";
import { useState, useEffect, useMemo } from "react";
import { useNavigate } from "react-router-dom";
import type { SelectChangeEvent } from "@mui/material";

export type CurrentWord = {
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

export const useTestPageState = () => {
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
            for (const e of eng) if (e) all.push(e);
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

    return {
        currentWord,
        englishWords,
        step,
        correct,
        incorrect,
        allEnglishOptions,
        handleChange,
        handleCheck,
        storeWordsLength: store.words.length,
    };
};
