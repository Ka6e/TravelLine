import { create } from "zustand";
import { v4 as uuidv4 } from "uuid"
import { persist, createJSONStorage } from "zustand/middleware";
import type { WordType } from "../types/types";

type WordStore = {
    words: WordType[];
    addWord: (rus: string, eng: string) => void;
    deleteWord: (id: string) => void;
    updateWord: (id: string, rus: string, eng: string) => void;
}

export const useWordStore = create<WordStore>()(
    persist(
        (set, get) => ({
            words: [],

            addWord: (rus, eng) => {
                const newWord: WordType = {
                    id: uuidv4(),
                    russian: rus,
                    english: eng,
                };

                set({ words: [...get().words, newWord] });
            },

            deleteWord: (id) => {
                set({ words: get().words.filter((word) => word.id !== id) });
            },

            updateWord: (id, rus, eng) => {
                set({
                    words: get().words.map((word) =>
                        word.id === id ? { ...word, word: rus, translation: eng } : word
                    ),
                });
            },

        }),
        {
            name: "words",
            storage: createJSONStorage(() => localStorage)
        }
    )
);