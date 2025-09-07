import type { ReviewType } from "../Types/ReviewType"

const STORAGE_KEY = 'review';

export const saveToLocaleStorage = (review: ReviewType): void => {
    try {
 const existing = localStorage.getItem(STORAGE_KEY);
        const reviews: ReviewType[] = existing ? JSON.parse(existing) : [];

        reviews.push(review);

        localStorage.setItem(STORAGE_KEY, JSON.stringify(reviews));
    } catch (error) {
        console.error('Ошибка сохранения отзыва.', error);
    }
}

export const loadFromLocaleStorage = (): ReviewType [] | null => {
    try {
        const review = localStorage.getItem(STORAGE_KEY);

        if (!review) {
            return null;
        }

        return JSON.parse(review) as ReviewType [];
    } catch (error) {
        console.error('Ошибка загрузки отзыва.', error);
        return null;
    }
}