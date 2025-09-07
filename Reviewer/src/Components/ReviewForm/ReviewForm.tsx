import React, { useRef, useState } from "react";
import styles from "./ReviewForm.module.css"
import { RatingSliderList } from "../RatingSliderList/RatingSliderList";
import type { ReviewType } from "../../Types/ReviewType";
import { saveToLocaleStorage } from "../../Store/localeStorage";
import {v4 as uuidv4} from 'uuid'

export const ReviewForm = () => {

    const authorRef = useRef<HTMLInputElement>(null);
    const textArea = useRef<HTMLTextAreaElement>(null);
    const [isFormValid, setFormValid] = useState(false);
    const [ratingSum, setRatingSum] = useState(0);
    const [resetKey, setResetKey] = useState(0);

    const handleInputChange = () => {
        const isAuthorFilled = authorRef.current?.value.trim() !== "";
        const isReviewFilled = textArea.current?.value.trim() !== "";

        setFormValid(isAuthorFilled && isReviewFilled);
    }

    const handleRatingchange = (total: number) => {
        setRatingSum(total);
        handleInputChange();
    }

    const handleSubmit = (e: React.FormEvent) => {
        e.preventDefault();
        console.log(ratingSum);
        if (!isFormValid) {
            return;
        }

        setTimeout(() => {
            console.log("✅ Данные отправлены!");
            console.log("Рейтинг:", ratingSum);
            console.log("Автор:", authorRef.current?.value);
            console.log("Отзыв:", textArea.current?.value);

            
            const review: ReviewType = {
                id: uuidv4(),
                author: authorRef.current?.value || "",
                text: textArea.current?.value || "",
                rating: parseFloat((ratingSum / 5).toFixed(1))
            }

            saveToLocaleStorage(review);
            console.log('OK');

            setFormValid(false);

            setResetKey(prev => prev + 1);
            setRatingSum(0);
        }, 2000);
    }

    const handleInput = () => {
        const el = textArea.current;
        if (el != null) {
            if (el.scrollHeight > el.clientHeight) {
                el.style.height = el.scrollHeight + "px";
            }
        }
    };


    return (
        <form className={styles.reviewForm}>
            <h3 className={styles.reviewFormHeader}>Помогите нам сделать процесс бронирования лучше
            </h3>
            <RatingSliderList
                key={resetKey}
                onTotalChange={handleRatingchange} />
            <div className={styles.ratingSliders}>
            </div>
            <div className={styles.inputForm}>
                <div className={styles.authorWrapper}>
                    <label htmlFor="author" className={styles.authorLabel}>*Имя</label>
                    <input
                        type="text"
                        id="author"
                        name="author"
                        ref={authorRef}
                        className={styles.author}
                        placeholder="Как тебя зовут?"
                        onChange={handleInputChange} />
                </div>
                <textarea
                    id="rewievArea"
                    name="reviewArea"
                    className={styles.review}
                    ref={textArea}
                    placeholder="Напишите, что понравилось, а что было непонятно"
                    onChange={handleInputChange}
                    onInput={handleInput}>
                </textarea>
                <button
                    type="submit"
                    className={`${styles.button} ${isFormValid ? styles.buttonEnabled : ""}`}
                    disabled={!isFormValid}
                    onClick={handleSubmit}
                >
                    Отправить
                </button>
            </div>
        </form>
    );
}