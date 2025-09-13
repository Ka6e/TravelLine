import { Store } from "./Store";
import { getAllCurrencies, getCurrencyPrices } from "../api/currencyApi";
import type { Currency } from "../types/currencyTypes";

export type ExchangeState = {
  currencies: Currency[];
  fromCurrency: Currency | null;
  toCurrency: Currency | null;
  fromValue: string;
  toValue: string;
  rate: number | null;
  dateTime: string;
  activeField: "from" | "to" | null;
  loading: boolean;
};

const initialState: ExchangeState = {
  currencies: [],
  fromCurrency: null,
  toCurrency: null,
  fromValue: "",
  toValue: "",
  rate: null,
  dateTime: "",
  activeField: null,
  loading: false,
};

export const exchangeStore = {
  ...Store.create<ExchangeState>(initialState),

  updateValues: (activeField: "from" | "to", value: string) => {
    const state = exchangeStore.getSnapshot();

    if (!state.rate) {
      if (activeField === "from") {
        exchangeStore.set({ ...state, fromValue: value, activeField });
      } else {
        exchangeStore.set({ ...state, toValue: value, activeField });
      }
      return;
    }

    if (activeField === "from") {
      const toValue = value ? (parseFloat(value) * state.rate).toFixed(3) : "";
      exchangeStore.set({ ...state, fromValue: value, toValue, activeField });
    } else {
      const fromValue = value ? (parseFloat(value) / state.rate).toFixed(3) : "";
      exchangeStore.set({ ...state, fromValue, toValue: value, activeField });
    }
  },
};

export const loadCurrencies = async () => {
  exchangeStore.set({ ...exchangeStore.getSnapshot(), loading: true });
  try {
    const data = await getAllCurrencies();
    exchangeStore.set({ ...exchangeStore.getSnapshot(), currencies: data, loading: false });
  } catch {
    exchangeStore.set({ ...exchangeStore.getSnapshot(), loading: false });
  }
};

export const loadRate = async () => {
  const state = exchangeStore.getSnapshot();
  const from = state.fromCurrency?.code;
  const to = state.toCurrency?.code;

  if (!from || !to || from === to) {
    exchangeStore.set({ ...state, rate: null, dateTime: "" });
    return;
  }

  exchangeStore.set({ ...state, loading: true });

  try {
    const prices = await getCurrencyPrices(from, to);
    const last = prices[prices.length - 1];

    exchangeStore.set({
      ...exchangeStore.getSnapshot(),
      rate: last?.price || null, 
      dateTime: last?.dateTime || "",
      loading: false,
    });

    const activeField = state.activeField || "from";
    const value = activeField === "from" ? state.fromValue : state.toValue;
    exchangeStore.updateValues(activeField, value);
  } catch {
    exchangeStore.set({ ...exchangeStore.getSnapshot(), rate: null, dateTime: "", loading: false });
  }
};
