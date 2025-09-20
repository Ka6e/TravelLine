"use strict";

import {Auth} from "./Auth.js"
import { Compare } from "./Compare.js";
import { Navigation } from "./Navigation.js";

const main = () => {
    Auth.ShowLoginForm();
    Auth.Login();
    Auth.LogOut();
    Navigation.NavigateHome();
    Compare.ShowCompare();
    Compare.CompareJSON();
    Compare.AttachJsonValidation();
}

main();