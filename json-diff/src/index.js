"use strict";

import { Diff } from "./Diff.js";

const elements = {
    user: document.querySelector('.logined-user'),
    loginButton: document.querySelector('.login__button'),
    loginLink: document.querySelector('.header__login'),
    loginInput: document.getElementById('login-input'),
    loginError: document.querySelector('.login__error'),
    loginForm: document.querySelector('.login'),
    logOut: document.querySelector('.header__logout'),
    startPage: document.querySelector('.start-page'),
    startLink: document.querySelector('.start-page__start'),
    compare: document.querySelector('.compare'),
    compareForm: document.querySelector('.compare__form'),
    oldJsonError: document.querySelector('.oldJson-error'),
    newJsonError: document.querySelector('.newJson-error'),
    oldJson: document.getElementById('oldJson'),
    newJson: document.getElementById('newJson'),
    result: document.querySelector('.compare-result'),
    logo: document.querySelector('.header__logo')
}

const ShowLoginForm = () => {
    elements.loginLink.addEventListener('click', () => {
        elements.loginForm.style.display = 'flex';
        elements.loginLink.style.display = 'none';
        elements.startPage.style.display = 'none';
    });
}

const ValidateLogin = (value) => {
    if (!value.trim()) {
        elements.loginError.textContent = 'Required Field';
        elements.loginError.style.display = 'block';
        return false;
    }

    if (value !== 'Ivan') {
        elements.loginError.textContent = 'Incorrect login';
        elements.loginError.style.display = 'block';
        return false;
    }

    elements.loginError.style.display = 'none';
    return true;
}

const Login = () => {
    elements.loginForm.addEventListener('submit', (e) => {
        e.preventDefault();
        let value = elements.loginInput.value;

        if (ValidateLogin(value)) {
            elements.loginForm.style.display = 'none';
            elements.startPage.style.display = 'block';
            elements.user.style.display = 'grid';
            elements.startLink.style.display = 'block';
            sessionStorage.setItem('loggedIn', 'true');
        }
    })
}

const ShowCompare = () => {
    elements.startLink.addEventListener('click', () => {
        elements.startLink.style.display = 'none';
        elements.startPage.style.display = 'none';
        elements.compare.style.display = 'flex';
    })
}

const NavigateHome = () => {
    elements.logo.addEventListener('click', () => {
        if (sessionStorage.getItem('loggedIn') === 'true') {
            elements.startPage.style.display = 'block';
            elements.user.style.display = 'grid';
            elements.loginForm.style.display = 'none';
            elements.loginLink.style.display = 'none';
            elements.startLink.style.display = 'block';
        } else {
            elements.startPage.style.display = 'block';
            elements.user.style.display = 'none';
            elements.loginForm.style.display = 'none';
            elements.loginLink.style.display = 'block';
        }
        elements.compare.style.display = 'none';
    })
}


const LogOut = () => {
    elements.logOut.addEventListener('click', () => {
        sessionStorage.setItem('loggedIn', 'false');
        elements.loginLink.style.display = 'block';
        elements.user.style.display = 'none';
        elements.startLink.style.display = 'none';
    })
}
const ValidateJSON = (json) => {
    if (!json.trim()) {
        return 'Field is required';
    }
    try {
        JSON.parse(json)
        return null;
    } catch (error) {
        return 'Invalid JSON';
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

ShowLoginForm();
Login();
LogOut();
NavigateHome();
ShowCompare();
CompareJSON();