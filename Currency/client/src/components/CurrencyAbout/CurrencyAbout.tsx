import { useStore } from "../../Store/useStore";
import { exchangeStore } from "../../Store/exchangeStore";
import { CurrencyInfo } from "../CurrencyInfo/CurrencyInfo";
import styles from "./CurrencyAbout.module.css";

export const CurrencyAbout = () => {
  const state = useStore(exchangeStore);

  const { fromCurrency, toCurrency } = state;

  return (
    <div className={styles.currencyAbout}>
      {fromCurrency && (
        <CurrencyInfo
          name={fromCurrency.name}
          code={fromCurrency.code}
          symbol={fromCurrency.symbol || ""}
          describtion={fromCurrency.description || ""}
        />
      )}
      {toCurrency && (
        <CurrencyInfo
          name={toCurrency.name}
          code={toCurrency.code}
          symbol={toCurrency.symbol || ""}
          describtion={toCurrency.description || ""}
        />
      )}
    </div>
  );
};
