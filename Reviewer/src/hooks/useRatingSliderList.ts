import { useState, useEffect } from "react";

export const useRatingSliderList = (count: number, onTotalChange: (total: number) => void) => {
  const [values, setValues] = useState<number[]>(Array(count).fill(0));

  const handleChange = (index: number, value: number) => {
    const updated = [...values];
    updated[index] = value;
    setValues(updated);
  };

  useEffect(() => {
    const total = values.reduce((sum, v) => sum + v, 0);
    onTotalChange(total);
  }, [values, onTotalChange]);

  return { values, handleChange };
};
