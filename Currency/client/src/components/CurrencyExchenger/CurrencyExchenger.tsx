// CurrencyExchanger.tsx
import { CurrencyField } from "../CurrencyField/CurrencyField";
import { ButtonAbout } from "../ButtonAbout/ButtonAbout";
import { CurrencyAbout } from "../CurrencyAbout/CurrencyAbout";
import styles from "./CurrencyExchenger.module.css";
import { useCurrencyExchanger } from "../../hooks/useCurrencyExchenger";
import { exchangeStore } from "../../Store/exchangeStore";

export const CurrencyExchanger = () => {
    const { state, isAboutOpen, toggleAbout } = useCurrencyExchanger();

    return (
        <div className={styles.currencyExchanger}>
            <div className={styles.header}>
                {state.fromCurrency && state.toCurrency && state.rate ? (
                    <p>
                        <span className={styles.fromCurrency}>
                            {state.fromValue || ""} {state.fromCurrency.name} is
                        </span>
                        <br />
                        <span className={styles.toCurrency}>
                            {state.fromValue ? (parseFloat(state.fromValue) * state.rate).toFixed(3) : ""}{" "}
                            {state.toCurrency.name}
                        </span>
                    </p>
                ) : (
                    <p>Choose currencies</p>
                )}
                <p className={styles.date}>
                    {(() => {
                        const d = new Date(state.dateTime || Date.now());
                        return `${d.toUTCString().slice(0, 16)} ${d.getUTCHours()
                            .toString()
                            .padStart(2, "0")}:${d.getUTCMinutes().toString().padStart(2, "0")} UTC`;
                    })()}
                </p>
            </div>

            <div className={styles.currencyInputs}>
                <CurrencyField
                    field="from"
                    value={state.fromValue}
                    onValueChange={(v) => exchangeStore.updateValues("from", v)}
                />
                <CurrencyField
                    field="to"
                    value={state.toValue}
                    onValueChange={(v) => exchangeStore.updateValues("to", v)}
                />
                <div className={styles.button}>
                    <ButtonAbout isOpen={isAboutOpen} onToggle={toggleAbout} />
                </div>
            </div>

            <div className={`${styles.currencyAbout} ${isAboutOpen ? styles.currencyAboutOpen : ""}`}>
                <CurrencyAbout />
            </div>
        </div>
    );
};
