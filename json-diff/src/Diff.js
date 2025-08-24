"use strict";

const calculate = (oldObj, newObj) => {
  console.log(oldObj);
  console.log(newObj);
  const keys = [...new Set([...Object.keys(oldObj), ...Object.keys(newObj)])];
  let result;

  for (const key of keys) {
    const oldValue = oldObj[key];
    const newValue = newObj[key];

    if (oldValue === newValue) {
      result = { ...result, [key]: { type: `unchanged`, oldValue, newValue } };
    } else if (oldValue === undefined) {
      result = { ...result, [key]: { type: `added`, newValue } };
    } else if (newValue === undefined) {
      result = { ...result, [key]: { type: `deleted`, oldValue } };
    } else {
      result = { ...result, [key]: { type: `changed`, oldValue, newValue } };
    }
  }

  return JSON.stringify(result, null, 4);
};

export const Diff = { calculate };
