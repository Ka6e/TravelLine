import styles from "./ReviewForm.module.css";
import { RatingSliderList } from "../RatingSliderList/RatingSliderList";
import { useReviewForm } from "../../hooks/useReviewForm";

export const ReviewForm = () => {
    const {
        authorRef,
        textAreaRef,
        isFormValid,
        resetKey,
        handleRatingChange,
        handleSubmit,
        handleInputChange,
        handleTextareaInput
    } = useReviewForm();

    return (
        <form className={styles.reviewForm}>
            <h3 className={styles.reviewFormHeader}>
                Помогите нам сделать процесс бронирования лучше
            </h3>

            <RatingSliderList
                key={resetKey}
                onTotalChange={handleRatingChange}
            />

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
                        onChange={handleInputChange}
                    />
                </div>

                <textarea
                    id="reviewArea"
                    name="reviewArea"
                    className={styles.review}
                    ref={textAreaRef}
                    placeholder="Напишите, что понравилось, а что было непонятно"
                    onChange={handleInputChange}
                    onInput={handleTextareaInput}
                />

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
};
