"use strict";

import { elements } from "./Elements.js";
import { Diff } from "./Diff.js";  

const ShowCompare = () => {
    elements.startLink.addEventListener('click', () => {
        elements.startLink.style.display = 'none';
        elements.startPage.style.display = 'none';
        elements.compare.style.display = 'flex';
    })
}

const ValidateJSON = (json) => {
    if (!json.trim()) {
        return 'Обязательное поле';
    }
    try {
        JSON.parse(json)
        return null;
    } catch (error) {
        return 'Неправильный JSON';
    }
}

const IsErrors = (oldError, newError) => {
    let isError = false;

    elements.oldJsonError.style.display = 'none';
    elements.newJsonError.style.display = 'none';

    if (oldError) {
        elements.oldJsonError.textContent = `${oldError}`;
        elements.oldJsonError.style.display = 'block';
        isError = true;
    }
    if (newError) {
        elements.newJsonError.textContent = `${newError}`;
        elements.newJsonError.style.display = 'block';
        isError = true;
    }
    return isError;
}

const CompareJSON = () => {
    elements.compareForm.addEventListener('submit', (e) => {
        e.preventDefault();

        if (IsErrors(ValidateJSON(elements.oldJson.value), ValidateJSON(elements.newJson.value))) {
            return;
        }

        const oldJson = JSON.parse(elements.oldJson.value);
        const newJson = JSON.parse(elements.newJson.value);

        const result = Diff.calculate(oldJson, newJson);
        elements.result.textContent = result;
        elements.result.style.display = 'block';
    })
}

const AttachJsonValidation = () => {
    [elements.oldJson, elements.newJson].forEach((field, index) => {
        field.addEventListener('input', () => {
            const errorElement = index === 0 ? elements.oldJsonError : elements.newJsonError;
            errorElement.style.display = 'none';
        });
    });
};

export const Compare = { ShowCompare, CompareJSON, AttachJsonValidation };