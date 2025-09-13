import styles from "./CurrencyInfo.module.css"

type CurrencyInfoTypeProps = {
    name: string,
    code: string,
    symbol?: string,
    describtion: string
}

export const CurrencyInfo = ({name, code, symbol, describtion}: CurrencyInfoTypeProps) => {    
    return(
        <div className={styles.currency}>
            <p className={styles.infoHeader}>{name} - {code} - {symbol}</p>
            <p className={styles.currencyDescribtion}>
                {describtion}
            </p>
        </div>
    );
}