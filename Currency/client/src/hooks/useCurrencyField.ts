import { useEffect } from "react";
import { useStore } from "../Store/useStore";
import { exchangeStore, loadCurrencies } from "../Store/exchangeStore";

export const useCurrencyField = (field: "from" | "to", value: string, onValueChange: (v: string) => void) => {
  const state = useStore(exchangeStore);

  useEffect(() => {
    loadCurrencies();
  }, []);

  const currency = field === "from" ? state.fromCurrency : state.toCurrency;

  const handleCurrencyChange = (code: string) => {
    const selected = state.currencies.find((c) => c.code === code) || null;

    if (field === "from") {
      if (selected?.code === state.toCurrency?.code) return;
      exchangeStore.set({ ...state, fromCurrency: selected });
    } else {
      if (selected?.code === state.fromCurrency?.code) return;
      exchangeStore.set({ ...state, toCurrency: selected });
    }

    const activeField = state.activeField || "from";
    const val = activeField === "from" ? state.fromValue : state.toValue;
    exchangeStore.updateValues(activeField, val);
  };

  return {
    state,
    currency,
    handleCurrencyChange,
    value,
    onValueChange
  };
};
