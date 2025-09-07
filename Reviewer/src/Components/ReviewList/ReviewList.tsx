import { loadFromLocaleStorage } from "../../Store/localeStorage"
import { ReviewItem } from "../ReviewItem/ReviewItem";
import styles from "./ReviewList.module.css"

export const ReviewList = () => {

    const rewiews = loadFromLocaleStorage();

    return (
        <div className={styles.reviewList}>
            {rewiews?.map((review) => (
                <ReviewItem
                    key={review.id}
                    name={review.author}
                    comment={review.text}
                    rating={review.rating}
                />
            ))}
        </div>
    )
}