export type CurrencyFieldProps = {
  field: "from" | "to";
  value: string;
  onValueChange: (v: string) => void;
};
