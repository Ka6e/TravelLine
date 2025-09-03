import { useState } from "react";

export const useFormState = (initialRussian = "", initialEnglish = "", onSubmit: (russian: string, english: string) => void) => {
    const [russian, setRussian] = useState(initialRussian);
    const [english, setEnglish] = useState(initialEnglish);

    const handleSave = () => {
        if (russian && english) {
            onSubmit(russian, english);
        }
    };

    const handleChangeRussian = (value: string) => setRussian(value);
    const handleChangeEnglish = (value: string) => setEnglish(value);

    return {
        russian,
        english,
        handleChangeRussian,
        handleChangeEnglish,
        handleSave,
    };
};
