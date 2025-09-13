export type Currency = {
  code: string;
  name: string;
  symbol?: string;
  description?: string;
  rate?: number;
};

export type CurrencyPrice = {
  paymentCurrency: string;
  purchasedCurrency: string;
  price: number;
  dateTime: string;
};
