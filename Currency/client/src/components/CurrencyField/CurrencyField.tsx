import styles from "./CurrencyField.module.css";
import type { Currency } from "../../types/currencyTypes";
  import type { CurrencyFieldProps } from "../../types/currencyFieldProps";
import { useCurrencyField } from "../../hooks/useCurrencyField";

export const CurrencyField = ({ field, value, onValueChange }: CurrencyFieldProps) => {
  const { state, currency, handleCurrencyChange } = useCurrencyField(field, value, onValueChange);

  return (
    <div className={styles.currencyField}>
      <input
        type="text"
        value={value}
        onChange={(e) => onValueChange(e.target.value)}
        className={styles.inputField}
      />
      <select
        value={currency?.code || ""}
        onChange={(e) => handleCurrencyChange(e.target.value)}
        className={styles.currencySelect}
      >
        <option value="" disabled>
          {state.loading ? "Loading..." : "Choose currency"}
        </option>
        {state.currencies.map((c: Currency) => (
          <option key={c.code} value={c.code}>
            {c.code} - {c.name}
          </option>
        ))}
      </select>
    </div>
  );
};
