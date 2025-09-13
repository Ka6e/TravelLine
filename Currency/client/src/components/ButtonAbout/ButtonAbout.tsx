import { exchangeStore } from "../../Store/exchangeStore";
import { useStore } from "../../Store/useStore";
import styles from "./ButtonAbout.module.css"

type ButtonProps = {
  isOpen: boolean;
  onToggle: () => void;
}

export const ButtonAbout = (prop: ButtonProps) => {
    const state = useStore(exchangeStore);

    return (
        <button
            className={styles.button}
            onClick={prop.onToggle}
            disabled={!state.fromCurrency?.code || !state.toCurrency?.code}
        >
            <span>
                {state.fromCurrency?.code}/{state.toCurrency?.code}: about {prop.isOpen ? "↑" : "↓"}
            </span>
        </button>
    );
} 