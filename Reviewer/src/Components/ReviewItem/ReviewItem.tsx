import styles from "./ReviewItem.module.css"
import image from "../../assets/17536961333020.jpg"

type ReviewItem = {
    name: string,
    comment: string
    rating: number
}

export const ReviewItem = ({ name, comment, rating }: ReviewItem) => {

    return (
        <div className={styles.review}>
            <img className={styles.avatar} src={image}/>
            <div className={styles.reviewHeader}>
                <p className={styles.reviewAuthor}>{name}</p>
                <p className={styles.reviewText}>{comment}</p>
            </div>
            <span className={styles.grade}>{rating.toFixed(2)}/5</span>
        </div>
    )
}