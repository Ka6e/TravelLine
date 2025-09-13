import type { Currency, CurrencyPrice } from "../types/currencyTypes";

const API_BASE_URL = "https://localhost:7145/";

const fetchApi = async (endpoint: string) => {
    const res = await fetch(`${API_BASE_URL}${endpoint}`);
    if (!res.ok) throw new Error(`HTTP error! status: ${res.status}`);
    return res.json();
};

export const getAllCurrencies = (): Promise<Currency[]> => fetchApi("Currency");

export const getCurrencyPrices = (
    paymentCurrency: string,
    purchasedCurrency: string,
    fromDateTime: Date = new Date(Date.now() - 24 * 60 * 60 * 1000)
): Promise<CurrencyPrice[]> => {
    if (!paymentCurrency || !purchasedCurrency || paymentCurrency === purchasedCurrency) return Promise.resolve([]);

    const from = encodeURIComponent(fromDateTime.toISOString());
    const to = encodeURIComponent(new Date().toISOString());

    return fetchApi(
        `Currency/prices/?PaymentCurrency=${paymentCurrency}&PurchasedCurrency=${purchasedCurrency}&FromDateTime=${from}&ToDateTime=${to}`
    );
};
