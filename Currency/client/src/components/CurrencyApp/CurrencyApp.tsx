import { useState, useEffect } from "react";
import { CurrencyExchanger } from "../CurrencyExchenger/CurrencyExchenger";
import { Loader } from "../Loader/Loader";
import { Error } from "../Error/Error";
import { loadCurrencies, exchangeStore } from "../../Store/exchangeStore";

export const CurrencyApp = () => {
    const [status, setStatus] = useState<"loading" | "success" | "error">("loading");

    useEffect(() => {
        const init = async () => {
            try {
                const delay = new Promise<void>(res => setTimeout(res, 2000));
                
                const currenciesPromise = loadCurrencies().then(() => {
                    const state = exchangeStore.getSnapshot();
                    if (!state.currencies || state.currencies.length === 0) {
                        throw new Error("No currencies from server");
                    }
                });

                await Promise.all([delay, currenciesPromise]);
                setStatus("success");
            } catch (err) {
                console.error(err);
                setStatus("error");
            }
        };

        init();
    }, []);

    if (status === "loading") return <Loader />;
    if (status === "error") return <Error />;

    return <CurrencyExchanger />;
};
