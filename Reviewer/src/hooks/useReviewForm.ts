import { useState, useRef } from "react";
import type { ReviewType } from "../Types/ReviewType";
import { saveToLocaleStorage } from "../Store/localeStorage";
import { v4 as uuidv4 } from "uuid";

export const useReviewForm = () => {
    const authorRef = useRef<HTMLInputElement>(null);
    const textAreaRef = useRef<HTMLTextAreaElement>(null);

    const [isFormValid, setFormValid] = useState(false);
    const [ratingSum, setRatingSum] = useState(0);
    const [resetKey, setResetKey] = useState(0);

    const validateForm = () => {
        const isAuthorFilled = authorRef.current?.value.trim() !== "";
        const isReviewFilled = textAreaRef.current?.value.trim() !== "";
        setFormValid(isAuthorFilled && isReviewFilled);
    };

    const handleRatingChange = (total: number) => {
        setRatingSum(total);
        validateForm();
    };

    const handleInputChange = () => {
        validateForm();
    };

    const handleSubmit = (e: React.FormEvent) => {
        e.preventDefault();
        if (!isFormValid) return;

        setTimeout(() => {
            const review: ReviewType = {
                id: uuidv4(),
                author: authorRef.current?.value || "",
                text: textAreaRef.current?.value || "",
                rating: parseFloat((ratingSum / 5).toFixed(1))
            };

            saveToLocaleStorage(review);

            setFormValid(false);
            setResetKey(prev => prev + 1);
            setRatingSum(0);
            if (authorRef.current) authorRef.current.value = "";
            if (textAreaRef.current) textAreaRef.current.value = "";
        }, 2000);
    };

    const handleTextareaInput = () => {
        const el = textAreaRef.current;
        if (el && el.scrollHeight > el.clientHeight) {
            el.style.height = el.scrollHeight + "px";
        }
    };

    return {
        authorRef,
        textAreaRef,
        isFormValid,
        ratingSum,
        resetKey,
        handleRatingChange,
        handleSubmit,
        handleInputChange,
        handleTextareaInput,
    };
};
