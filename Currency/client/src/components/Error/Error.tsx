import styles from "./Error.module.css"

export const Error = () => {

    return (
        <div className={styles.error}>
            <p className={styles.errorText}>COULD NOT GET DATA <br/> FROM THE SERVER</p>
        </div>
    );
}