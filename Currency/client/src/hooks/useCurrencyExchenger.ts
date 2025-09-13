import { useState, useEffect } from "react";
import { exchangeStore, loadRate } from "../Store/exchangeStore";
import { useStore } from "../Store/useStore";

export const useCurrencyExchanger = () => {
    const state = useStore(exchangeStore);
    const [isAboutOpen, setIsAboutOpen] = useState(false);

    const toggleAbout = () => setIsAboutOpen(prev => !prev);

    useEffect(() => {
        if (state.fromCurrency && state.toCurrency) {
            loadRate().then(() => {
                if (state.activeField === "from" && state.fromValue) {
                    exchangeStore.updateValues("from", state.fromValue);
                } else if (state.activeField === "to" && state.toValue) {
                    exchangeStore.updateValues("to", state.toValue);
                }
            });
        }
    }, [state.fromCurrency, state.toCurrency]);

    return { state, isAboutOpen, toggleAbout };
};
