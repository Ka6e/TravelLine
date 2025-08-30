"use strict";

import { elements } from "./Elements.js";

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

export const Navigation = { NavigateHome };