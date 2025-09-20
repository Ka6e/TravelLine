"use strict";

import { elements } from "./Elements.js";

const ValidateLogin = (value) => {
    if (!value.trim()) {
        elements.loginError.textContent = 'Обязательное поле';
        elements.loginError.style.display = 'block';
        return false;
    }

    elements.loginError.style.display = 'none';
    return true;
}

const ShowLoginForm = () => {
    elements.loginLink.addEventListener('click', () => {
        elements.loginForm.style.display = 'flex';
        elements.loginLink.style.display = 'none';
        elements.startPage.style.display = 'none';
    });
}

const Login = () => {
    elements.loginForm.addEventListener('submit', (e) => {
        e.preventDefault();
        let value = elements.loginInput.value;

        if (ValidateLogin(value)) {
            elements.greet.textContent = `Hello, ${value}!`;
            elements.loginForm.style.display = 'none';
            elements.startPage.style.display = 'block';
            elements.user.style.display = 'grid';
            elements.startLink.style.display = 'block';
            sessionStorage.setItem('loggedIn', 'true');
        }
    })
}

const LogOut = () => {
    elements.logOut.addEventListener('click', () => {
        sessionStorage.setItem('loggedIn', 'false');
        elements.loginLink.style.display = 'block';
        elements.user.style.display = 'none';
        elements.startLink.style.display = 'none';
        elements.compare.style.display = 'none';
        elements.startPage.style.display = 'block';
    })
}

export const Auth = { ShowLoginForm, Login, LogOut };